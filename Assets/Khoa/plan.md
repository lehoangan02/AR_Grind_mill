# Khoa — Plan hoàn thiện hệ thống Xay gạo, Vo gạo và Nấu cơm

> Ngày lập: 2026-08-31
> Nguồn: audit `2026_08_31_work.md`, Git, code, Unity scene serialization và Unity CLI tests.
> Trạng thái hiện tại: **prototype logic đã compile và test được, nhưng gameplay XR end-to-end chưa hoàn thành**.

## 1. Mục tiêu

Hoàn thiện chuỗi gameplay vật lý liên tục:

`Thóc sau tuốt -> nạp cối -> quay cối -> gạo trắng -> múc nước -> vo và chắt -> lấy gạo đã vo -> nhóm bếp -> đong gạo/nước -> đậy nắp -> nấu -> mở nắp và xới cơm`.

Không đánh dấu `100%` chỉ vì unit test pass. Chỉ hoàn thành khi người chơi có thể thực hiện toàn bộ chuỗi bằng XR interaction trong scene chính, không cần gọi trực tiếp hàm gameplay từ Inspector, test hoặc code hỗ trợ.

## 2. Quy tắc phạm vi công việc của Khoa

- Code, prefab, material, audio, particle, test và editor tool do Khoa sở hữu phải ưu tiên đặt trong `Assets/Khoa/`.
- Được phép chỉnh sửa ngoài `Assets/Khoa/` khi cần tích hợp thật sự, ví dụ:
  - scene chính của game;
  - adapter tương thích với hệ thống cũ;
  - prefab hoặc cấu hình chung mà scene đang sử dụng;
  - assembly/package/config bắt buộc để hệ thống của Khoa hoạt động.
- Mỗi thay đổi ngoài `Assets/Khoa/` phải:
  - có lý do tích hợp rõ ràng;
  - giữ diff nhỏ nhất có thể;
  - không chiếm ownership hoặc làm hỏng hệ thống của thành viên khác;
  - được liệt kê trong commit hoặc báo cáo bàn giao;
  - có regression test hoặc bước kiểm tra tương ứng.
- Chỉnh scene chính là ngoại lệ hợp lệ. Sửa code team khác cũng có thể hợp lệ, nhưng chỉ khi adapter trong `Assets/Khoa` không giải quyết được hoặc API bên ngoài bắt buộc phải thay đổi.

## 3. Definition of Done

Hệ thống chỉ được ghi `100%` khi đạt đủ tất cả điều kiện sau:

- [ ] Chuỗi gameplay hoàn thành được bằng tay XR trong scene chính, không gọi trực tiếp các hàm `Complete...()`.
- [ ] Mỗi bước có action, feedback và kết quả rõ ràng; quest guide không đi trước trạng thái gameplay thật.
- [ ] Không thể bỏ qua bước vo gạo, nhóm lửa, đậy nắp hoặc đong đúng nguyên liệu.
- [ ] Không thể nhân vô hạn gạo hoặc bát cơm từ một mẻ.
- [ ] Scene không còn reference bắt buộc bị `null` và không dựa vào primitive fallback trong bản hoàn thiện.
- [ ] EditMode, PlayMode, scene validation và build mục tiêu đều pass.
- [ ] Có PlayMode test đi qua collider/trigger/XR interaction thật, không chỉ gọi helper method.
- [ ] Đã QA thủ công trên kính VR/thiết bị đích về reach, grab, snap, haptic, text và hiệu năng.
- [ ] Work report phản ánh đúng commit, số test, giới hạn kiểm chứng và các việc còn mở.

## 4. P0 — Blocker làm đứt gameplay flow

### 4.1. Sửa đường nạp thóc vật lý vào cối

Hiện trạng:

- Integrator tạo `PaddyHopper` bằng `Cylinder` nhưng tìm `BoxCollider`; `hopperTrigger` trong scene đang `null`.
- `GrindMillStation.OnTriggerEnter()` nằm trên object cha không có collider/Rigidbody phù hợp để nhận callback từ phễu.
- Input đang nhận diện bằng chuỗi tên `Basket`, `Rice`, `Paddy`, không xác nhận loại vật phẩm hoặc trạng thái đầy.
- Chưa có transaction tiêu thụ thóc an toàn khi cối nhận nguyên liệu.

Việc cần làm:

- [ ] Tạo hopper trigger riêng có collider `isTrigger = true`, gắn receiver script đúng object nhận callback.
- [ ] Dùng component/interface rõ ràng cho nguồn thóc; không dùng tên GameObject làm điều kiện chính.
- [ ] Chỉ nhận giỏ/bó thóc hợp lệ và còn nguyên liệu.
- [ ] Chỉ tiêu thụ đầu vào sau khi cối xác nhận đã nhận mẻ thành công.
- [ ] Không nhận thêm thóc khi đang `ReadyToGrind` hoặc `Grinding`.
- [ ] Quy định rõ khi nào được bắt đầu mẻ mới sau `Completed` và sau khi người chơi lấy output.
- [ ] Bảo vệ `CompleteMilling()` để một mẻ chỉ sinh đúng một output.

Acceptance tests:

- [ ] Thả đúng giỏ thóc vào hopper làm cối chuyển `Empty -> ReadyToGrind` và trừ nguyên liệu đúng một lần.
- [ ] Gạo trắng, giỏ rỗng và object chỉ có tên chứa `Rice` không nạp được cối.
- [ ] Hai collider của cùng một giỏ không làm nạp hai lần.
- [ ] Gọi hoàn thành lặp lại không sinh thêm output.

### 4.2. Tạo thao tác lấy gạo đã vo ra khỏi thau

Hiện trạng:

- `TakeOutWashedRice()` chỉ là public method; không có XR interaction nào gọi nó.
- Quest chuyển sang bước nhóm bếp ngay khi `WashedRiceReady`, trước khi vật phẩm gạo đã vo thực sự được lấy ra.

Việc cần làm:

- [ ] Chọn interaction thực tế: nhấc rá/thau để đổ sang nồi, dùng dụng cụ xúc, hoặc spawn/snap một phần gạo đã vo sau khi chắt.
- [ ] Tạo đúng một `WhiteRiceItem` có `isWashed = true` và giữ đúng lượng gạo của mẻ.
- [ ] Không cho lấy gạo khi chưa đạt ngưỡng sạch hoặc chưa chắt hết nước.
- [ ] Sau khi lấy, reset thau đầy đủ: gạo, nước, wash progress, visual và state.
- [ ] Chỉ chuyển quest sang bước bếp khi output gạo đã vo thực sự tồn tại hoặc đã được chuyển vào nồi.

Acceptance tests:

- [ ] Người chơi hoàn thành thao tác bằng XR mà không gọi `TakeOutWashedRice()` từ test/helper.
- [ ] Một mẻ chỉ tạo một output.
- [ ] Gạo chưa vo hoặc chưa chắt không thể trở thành `isWashed = true`.

### 4.3. Tạo thao tác xới cơm thật và giới hạn output

Hiện trạng:

- `ServeRiceBowl()` không được nối với XR interaction, dụng cụ hoặc trigger.
- Có thể gọi lặp để sinh vô hạn bát; nồi không giảm khẩu phần và không đổi state.

Việc cần làm:

- [ ] Chọn interaction: muôi xới XR, vùng scoop, hoặc select action có animation rõ ràng.
- [ ] Thêm số khẩu phần còn lại hoặc quy tắc một nồi/một bát.
- [x] Mỗi thao tác hợp lệ chỉ sinh đúng một bát và trừ hết khẩu phần của mẻ một-bát hiện tại.
- [x] Không cho xới khi nắp còn đóng, cơm chưa chín hoặc nồi đã hết.
- [ ] Quest chỉ hoàn tất khi bát cơm thật được tạo từ thao tác của người chơi.

Acceptance tests:

- [ ] Xới bằng interaction thật tạo đúng output.
- [x] Không thể sinh vô hạn bát.
- [x] Burnt rice tạo output/feedback đúng thiết kế, không báo là cơm trắng ngon.

## 5. P1 — Sửa invariants và FSM gameplay

### 5.1. Vo gạo phải dựa trên chuyển động thật

- [ ] Thay cộng tiến độ một lần trong `OnTriggerEnter()` bằng theo dõi tay/dụng cụ khi nằm trong vùng vo.
- [ ] Chỉ tăng tiến độ khi có quỹ đạo, khoảng cách và vận tốc hợp lệ; ưu tiên nhận diện chuyển động vòng/cọ xát thay vì đứng yên.
- [ ] Có cooldown/rate limit để nhiều collider ngón tay không nhân tiến độ.
- [ ] Chốt một ngưỡng sạch duy nhất; hiện comment/UI hướng tới 100% nhưng logic chấp nhận 60%.
- [ ] Cho phép vo nhiều nước nếu thiết kế yêu cầu, đồng thời không reset sai tiến độ.
- [ ] Visual độ đục phải khớp với wash progress thật.

### 5.2. Gáo nước và định lượng nước

- [ ] Dùng spout/pour origin và hướng rót theo local transform, không dùng sphere cố định theo `Vector3.down`.
- [ ] Chỉ trừ nước khi target hợp lệ nhận được nước.
- [ ] Nếu rót trượt, thể hiện nước đổ ra đất nhưng không báo target đã nhận.
- [ ] Thay nhận diện nguồn nước bằng component/tag/layer cụ thể; không dựa vào tên `Water` hoặc `Jar`.
- [ ] Giới hạn dung tích của thau/nồi, không cho cộng nước vô hạn hoặc amount âm.
- [x] Thống nhất ngưỡng nước tối thiểu ở cả hai thứ tự thêm nguyên liệu: `1.0`.

### 5.3. Nồi phải chỉ nhận gạo đã vo

- [x] `CookingPot.AddRice()` từ chối `rice.isWashed == false`.
- [x] Không phá hủy vật phẩm đầu vào khi transaction bị từ chối.
- [ ] Quy định lượng gạo/nước hợp lệ theo ratio, không chỉ kiểm tra một ngưỡng nước độc lập.
- [ ] Xử lý thiếu nước, thừa nước và nhiều mẻ theo requirement gameplay.

### 5.4. Nắp nồi phải có ý nghĩa gameplay

- [x] Cooking loop kiểm tra `isLidClosed`; nồi chỉ tăng cooking timer khi nắp đóng.
- [x] Mở nắp khi đang sôi tạm dừng cooking progress và boiling FX/audio.
- [ ] Chỉ snap khi nắp đúng orientation và đúng nồi; xử lý thả/giật ổn định với XR Grab.
- [ ] Thực hiện rung/nảy nắp khi sôi bằng visual/animation an toàn, không phá physics hoặc gây rung camera.
- [x] Không cho xới khi nắp còn đóng.

### 5.5. Heat source, nấu chín và cháy khét

- [ ] Nồi chỉ nhận nhiệt từ `WoodStove` đang cháy; không dùng tên object chứa `Stove` để bật nhiệt.
- [ ] Theo dõi nhiều collider contact ổn định; một child collider exit không được tắt nhiệt nếu nồi vẫn nằm trên bếp.
- [ ] Cho phép tạm dừng/tiếp tục khi nhấc nồi khỏi bếp theo requirement.
- [x] Sửa FSM để `Cooked -> Burnt` thực sự có thể xảy ra khi tiếp tục đun.
- [x] Bảo vệ `CompleteCooking()` và `BurnRice()` khỏi transition sai state.
- [x] Reset gạo, nước, timer và state sau khi xới hết mẻ một-bát hiện tại.

### 5.6. Củi và que diêm

- [ ] `WoodStove.Ignite()` phải yêu cầu match khác null, đang cháy và còn hiệu lực.
- [ ] Không cho que diêm tự bén chỉ vì chạm object có tên `Table` hoặc `Stove`.
- [ ] Tạo striker/matchbox riêng và yêu cầu vận tốc/quỹ đạo quẹt tối thiểu.
- [ ] Bảo đảm callback order không làm việc thả que diêm chưa cháy vào bếp trở thành nhóm lửa ngẫu nhiên.
- [ ] Chốt việc que diêm có bị tiêu thụ sau khi nhóm bếp hay không.
- [ ] Quy định thêm củi khi bếp đang cháy và cập nhật count/fuel/visual nhất quán.

## 6. P1 — XR interaction, physics và UX

### 6.1. Cần quay cối

- [ ] Kiểm tra `XRGrabInteractable`, Rigidbody, collider và attach point trên setup thật.
- [ ] Xác nhận tay người chơi không kéo cần rời khỏi pivot; chỉ xoay quanh trục cối.
- [ ] Giới hạn spike tiến độ khi attach point đi qua góc `-180/180` hoặc tracking giật.
- [ ] Chốt có cho quay hai chiều đều xay hay chỉ một chiều.
- [ ] Haptic tỷ lệ với tốc độ nhưng có giới hạn tần suất/biên độ phù hợp thiết bị.
- [ ] Keyboard simulator không được che giấu lỗi XR path.

### 6.2. Grab/snap và vật lý vật phẩm

- [ ] Kiểm tra mass, collision mode, interpolation và throw behavior trên thiết bị đích.
- [ ] Kiểm tra nested Rigidbody của nồi/nắp và parenting khi grab/release.
- [ ] Thêm snap zones rõ cho nồi trên bếp, nắp trên nồi và các dụng cụ nếu gameplay yêu cầu.
- [ ] Không để vật phẩm rơi xuyên Terrain/bàn/bếp hoặc spawn chồng collider.
- [ ] Kiểm tra kích thước theo world scale `1 Unity unit = 1 m` và tầm với tay người chơi.

### 6.3. Quest guide

- [ ] Quest chỉ tiến khi điều kiện gameplay thật đã hoàn thành, không chỉ dựa vào helper event có thể gọi trực tiếp.
- [ ] Không bỏ qua bước lấy gạo đã vo, đậy nắp hoặc xới cơm.
- [ ] Billboard luôn hướng về camera/player hoặc có vị trí dễ đọc trong khu bếp.
- [ ] Kiểm tra font, emoji, fallback font, kích thước và occlusion trên kính VR.
- [ ] Có feedback lỗi: sai nguyên liệu, thiếu nước, chưa vo sạch, chưa có củi, diêm chưa cháy, nắp chưa đậy.

## 7. P1 — Scene, prefab, asset, FX và audio

Hiện scene đang thiếu nhiều reference và dùng primitive fallback. Cần hoàn thiện:

- [ ] `GrindMillStation`: white-rice prefab, rice output point, chaff particle, grinding loop, completion sound.
- [ ] `WaterDipper`: water surface, pour origin/FX, scoop sound, pour sound.
- [ ] `RiceWashingPot`: rice visual, water material hỗ trợ property block, drain FX, wash sound, drain sound.
- [ ] `WoodStove`: fire particle, smoke particle, ember/firewood visual, ignition sound, looping fire audio.
- [ ] `CookingPot`: water visual, steam FX, raw/cooked/burnt materials, boiling/cooked audio, bowl prefab.
- [ ] `PotLid`: open/close audio và boiling-rattle feedback.
- [ ] `MatchItem`: striker, flame FX và strike sound.
- [ ] `CookedRiceBowl`: prefab hoàn chỉnh, steam FX và burnt variant nếu cần.
- [ ] Thay primitive bằng prefab/art phù hợp; fallback chỉ dành cho debug và phải báo warning rõ.
- [ ] AudioSource không để `playOnAwake` nếu không có clip hợp lệ; cấu hình 3D rolloff phù hợp.
- [ ] Kiểm tra vị trí khu bếp theo địa hình và nhà sàn thật, không chỉ dựa vào tọa độ hardcode và `Terrain.activeTerrain`.

Scene validation bắt buộc:

- [ ] Đúng một setup root trong scene.
- [ ] Không có missing MonoBehaviour.
- [ ] Tất cả required reference khác null.
- [ ] Trigger/collider/layer matrix đúng.
- [ ] Không spawn dưới Terrain hoặc bên trong collider khác.
- [ ] Chạy lại integrator cho kết quả idempotent và không xóa object do designer sở hữu.

## 8. P1 — Nâng chất lượng automated tests

### 8.1. EditMode

- [ ] Thêm test cho mọi state transition hợp lệ và không hợp lệ.
- [x] Test raw rice bị nồi từ chối và vật phẩm không bị phá hủy.
- [x] Test water threshold nhất quán.
- [x] Test lid requirement.
- [x] Test `Cooked -> Burnt` reachable.
- [ ] Test một mẻ xay chỉ sinh một rice output.
- [x] Test một mẻ nấu không thể sinh bowl vô hạn.
- [ ] Test amount âm, null input, duplicate collider và public method gọi sai state.
- [ ] Test quest không nhảy bước sớm.

### 8.2. PlayMode physics/integration

- [ ] Mở scene hoặc test scene chứa đúng prefab/integrator output.
- [ ] Đưa Rigidbody giỏ thóc qua hopper trigger thật.
- [ ] Xoay handle qua interaction/attach transform thay vì gọi `CompleteMilling()`.
- [ ] Rót nước qua pour origin vào collider của thau/nồi.
- [ ] Mô phỏng tay/dụng cụ chuyển động trong vùng vo.
- [ ] Đặt củi và que diêm qua trigger thật.
- [ ] Đặt/nhấc nồi trên bếp thật và chờ timer thật.
- [ ] Grab/snap/mở nắp qua XR events.
- [ ] Xới cơm qua interaction thật.
- [ ] Test full cycle không gọi trực tiếp `CompleteMilling()`, `CompleteCooking()` hoặc `SetHeatSource(true)`.

### 8.3. Báo cáo test

- [ ] Không gọi test là “end-to-end” nếu nó bỏ qua trigger/XR hoặc gọi trực tiếp transition helper.
- [x] Báo đúng số test từ XML mới nhất; mốc sau batch CookingPot là EditMode `81/81`, PlayMode `12/12`.
- [ ] Nếu tuyên bố coverage, phải sinh coverage report và ghi rõ phạm vi assembly/file.
- [ ] Test pass không được dùng thay cho QA scene/device.

## 9. P2 — Build, performance và QA thiết bị

- [ ] Build Android/Quest hoặc platform đích thành công từ clean checkout.
- [ ] Chạy full gameplay trên kính VR bằng controller thật.
- [ ] QA reach/ergonomics: cần cối, gáo, thau, nắp, củi, diêm và muôi.
- [ ] QA haptic: không quá mạnh, không spam, hoạt động đúng controller.
- [ ] QA audio 3D và mức âm lượng trong môi trường game.
- [ ] QA particle/transparent materials trên URP và thiết bị đích.
- [ ] Profile CPU, GPU, GC allocation và frame time trong scene chính.
- [ ] Xác nhận quest text đọc được, không che gameplay và không quay lưng với người chơi.
- [ ] Playtest ít nhất một người không viết code; ghi lại điểm họ bị kẹt hoặc hiểu sai.

## 10. P2 — Code quality và tài liệu

- [ ] Loại bỏ nhận diện gameplay dựa vào `GameObject.name` ở hopper, nguồn nước, match và heat source.
- [ ] Giảm public mutable state; dùng API transition có validation và property chỉ đọc khi phù hợp.
- [ ] Phân tách input/interaction, domain state và presentation/FX để test đúng lớp.
- [ ] Bảo đảm subscribe/unsubscribe event đối xứng khi object enable/disable hoặc destroy.
- [ ] Thêm warning/error rõ cho required reference bị thiếu; fail validation trước khi save scene.
- [ ] Không dùng primitive fallback im lặng trong production scene.
- [ ] Cập nhật `2026_08_31_work.md`: bỏ tuyên bố 100% cho đến khi đạt Definition of Done.
- [ ] Sửa số test 77 thành số thực tế từ lần chạy cuối.
- [ ] Sửa danh sách commit; commit `refactor(physics): polish VR lid parenting...` hiện không tồn tại với subject đã báo cáo.
- [ ] Ghi rõ những file ngoài `Assets/Khoa` đã chỉnh và lý do tích hợp.

## 11. Thứ tự triển khai đề xuất

### Phase A — Làm chuỗi gameplay đi được

1. Hopper/transaction thóc.
2. Vo gạo bằng interaction thật.
3. Lấy/chuyển gạo đã vo.
4. Match/stove/heat source.
5. Recipe, lid và cooking FSM.
6. Xới cơm hữu hạn.
7. Đồng bộ quest guide.

Exit gate: hoàn thành được full cycle trong một PlayMode integration test không gọi trực tiếp các hàm hoàn tất.

### Phase B — Hoàn thiện scene và presentation

1. Prefab/art.
2. Collider, snap zone và world scale.
3. Particle/material.
4. Audio/haptic.
5. Scene validation và idempotent integrator.

Exit gate: scene validation pass, không còn required reference null và không dùng primitive fallback trong setup chính.

### Phase C — Chứng minh chất lượng

1. Full EditMode.
2. Full PlayMode physics/integration.
3. Clean build.
4. QA kính VR.
5. Profiler và playtest.
6. Cập nhật report/commit evidence.

Exit gate: đạt toàn bộ Definition of Done; chỉ lúc đó mới ghi `100%`.

## 12. Trạng thái bằng chứng tại thời điểm lập plan

- Unity version: `6000.3.16f1`.
- EditMode sau batch CookingPot: `81/81 passed`.
- PlayMode sau batch CookingPot: `12/12 passed`.
- Các test hiện tại chưa chứng minh XR/physics end-to-end vì nhiều bước gọi trực tiếp helper/transition method.
- Scene đã có setup root và các component chính, nhưng nhiều prefab/FX/audio/material reference còn null.
- Chưa có bằng chứng QA trực tiếp trên kính VR hoặc build thiết bị đích cho chuỗi gameplay mới.
