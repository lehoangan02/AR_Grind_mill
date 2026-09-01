# Khoa — Plan hoàn thiện hệ thống Xay gạo, Vo gạo và Nấu cơm

> Ngày lập: 2026-08-31
> Nguồn: audit `2026_08_31_work.md`, Git, code, Unity scene serialization và Unity CLI tests.
> Trạng thái hiện tại: **logic gameplay và scene wiring cốt lõi đã được củng cố, nhưng full-cycle XR trên kính và presentation hoàn chỉnh vẫn chưa được chứng minh**.

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
- [x] Không thể bỏ qua bước vo gạo, nhóm lửa, đậy nắp hoặc đong đúng nguyên liệu.
- [x] Không thể nhân vô hạn gạo hoặc bát cơm từ một mẻ.
- [ ] Scene không còn reference bắt buộc bị `null` và không dựa vào primitive fallback trong bản hoàn thiện.
- [ ] EditMode, PlayMode, scene validation và build mục tiêu đều pass.
- [ ] Có PlayMode test đi qua collider/trigger/XR interaction thật, không chỉ gọi helper method.
- [ ] Đã QA thủ công trên kính VR/thiết bị đích về reach, grab, snap, haptic, text và hiệu năng.
- [x] Work report phản ánh đúng commit, số test, giới hạn kiểm chứng và các việc còn mở.

## 4. P0 — Blocker làm đứt gameplay flow

### 4.1. Sửa đường nạp thóc vật lý vào cối

Hiện trạng:

- Integrator tạo `PaddyHopper` bằng `Cylinder` nhưng tìm `BoxCollider`; `hopperTrigger` trong scene đang `null`.
- `GrindMillStation.OnTriggerEnter()` nằm trên object cha không có collider/Rigidbody phù hợp để nhận callback từ phễu.
- Input đang nhận diện bằng chuỗi tên `Basket`, `Rice`, `Paddy`, không xác nhận loại vật phẩm hoặc trạng thái đầy.
- Chưa có transaction tiêu thụ thóc an toàn khi cối nhận nguyên liệu.

Việc cần làm:

- [x] Tạo hopper trigger riêng có collider `isTrigger = true`, gắn receiver script đúng object nhận callback.
- [x] Dùng component/interface rõ ràng cho nguồn thóc; không dùng tên GameObject làm điều kiện chính.
- [x] Chỉ nhận giỏ/bó thóc hợp lệ và còn nguyên liệu.
- [x] Chỉ tiêu thụ đầu vào sau khi cối xác nhận đã nhận mẻ thành công.
- [x] Không nhận thêm thóc khi đang `ReadyToGrind` hoặc `Grinding`.
- [x] Quy định rõ khi nào được bắt đầu mẻ mới sau `Completed` và sau khi người chơi lấy output.
- [x] Bảo vệ `CompleteMilling()` để một mẻ chỉ sinh đúng một output.

Acceptance tests:

- [x] Thả đúng giỏ thóc vào hopper làm cối chuyển `Empty -> ReadyToGrind` và trừ nguyên liệu đúng một lần (domain/transaction test; physics trigger PlayMode vẫn ở mục 8.2).
- [x] Gạo trắng, giỏ rỗng và object chỉ có tên chứa `Rice` không nạp được cối.
- [x] Hai collider của cùng một giỏ không làm nạp hai lần.
- [x] Gọi hoàn thành lặp lại không sinh thêm output.

### 4.2. Tạo thao tác lấy gạo đã vo ra khỏi thau

Hiện trạng:

- `TakeOutWashedRice()` chỉ là public method; không có XR interaction nào gọi nó.
- Quest chuyển sang bước nhóm bếp ngay khi `WashedRiceReady`, trước khi vật phẩm gạo đã vo thực sự được lấy ra.

Việc cần làm:

- [x] Chọn interaction thực tế: muôi chuyển gạo XR, Grip để cầm và Trigger để lấy từ thau.
- [x] Tạo đúng một `WhiteRiceItem` có `isWashed = true` và giữ đúng lượng gạo của mẻ.
- [x] Không cho lấy gạo khi chưa đạt ngưỡng sạch hoặc chưa chắt hết nước.
- [x] Sau khi lấy, reset thau đầy đủ: gạo, nước, wash progress, visual và state.
- [x] Chỉ chuyển quest sang bước bếp khi output gạo đã vo thực sự tồn tại hoặc đã được chuyển vào nồi.

Acceptance tests:

- [ ] Người chơi hoàn thành thao tác bằng XR mà không gọi `TakeOutWashedRice()` từ test/helper.
- [x] Một mẻ chỉ tạo một output.
- [x] Gạo chưa vo hoặc chưa chắt không thể trở thành `isWashed = true`.

### 4.3. Tạo thao tác xới cơm thật và giới hạn output

Hiện trạng:

- `ServeRiceBowl()` không được nối với XR interaction, dụng cụ hoặc trigger.
- Có thể gọi lặp để sinh vô hạn bát; nồi không giảm khẩu phần và không đổi state.

Việc cần làm:

- [x] Chọn interaction: muôi xới XR, Grip để cầm và Trigger/Activate để xới.
- [x] Thêm số khẩu phần còn lại hoặc quy tắc một nồi/một bát.
- [x] Mỗi thao tác hợp lệ chỉ sinh đúng một bát và trừ hết khẩu phần của mẻ một-bát hiện tại.
- [x] Không cho xới khi nắp còn đóng, cơm chưa chín hoặc nồi đã hết.
- [x] Quest chỉ hoàn tất khi bát cơm thật được tạo từ thao tác của người chơi.

Acceptance tests:

- [ ] Xới bằng interaction thật tạo đúng output.
- [x] Không thể sinh vô hạn bát.
- [x] Burnt rice tạo output/feedback đúng thiết kế, không báo là cơm trắng ngon.

## 5. P1 — Sửa invariants và FSM gameplay

### 5.1. Vo gạo phải dựa trên chuyển động thật

- [x] Thay cộng tiến độ một lần trong `OnTriggerEnter()` bằng theo dõi dụng cụ khi nằm trong vùng vo.
- [x] Chỉ tăng tiến độ khi có bán kính, bước góc và khoảng thời gian mẫu hợp lệ; đứng yên không tăng.
- [x] Có rate limit theo sample time/angle để callback trùng không nhân tiến độ.
- [x] Chốt ngưỡng sạch duy nhất là 100%.
- [x] Cho phép thêm nước vo tiếp mà không reset sai tiến độ.
- [x] Visual độ đục khớp với wash progress thật.

### 5.2. Gáo nước và định lượng nước

- [x] Dùng spout/pour origin và hướng rót theo local transform, không dùng sphere cố định theo `Vector3.down`.
- [x] Chỉ trừ nước khi target hợp lệ nhận được nước.
- [x] Nếu rót trượt, phát pour FX/sound, làm rỗng gáo, phát `OnWaterSpilled` và không phát `OnWaterPoured`/không cộng nước cho target.
- [x] Thay nhận diện nguồn nước bằng `WaterSource`; không dựa vào tên `Water` hoặc `Jar`.
- [x] Giới hạn dung tích của thau/nồi, không cho cộng nước vô hạn hoặc amount âm.
- [x] Thống nhất ngưỡng nước tối thiểu ở cả hai thứ tự thêm nguyên liệu: `1.0`.

### 5.3. Nồi phải chỉ nhận gạo đã vo

- [x] `CookingPot.AddRice()` từ chối `rice.isWashed == false`.
- [x] Không phá hủy vật phẩm đầu vào khi transaction bị từ chối.
- [x] Quy định recipe một mẻ: đúng `10` phần gạo đã vo với `1.0` nước (tolerance `0.05` chỉ cho sai số float); sai lượng gạo/nước bị từ chối mà không tiêu thụ input.
- [x] Xử lý thiếu nước, thừa nước và nhiều mẻ: thiếu nước giữ `HasRice`, thừa nước bị từ chối toàn phần, không nhận hai batch cùng lúc, mẻ mới chỉ bắt đầu sau khi xới/reset.

### 5.4. Nắp nồi phải có ý nghĩa gameplay

- [x] Cooking loop kiểm tra `isLidClosed`; nồi chỉ tăng cooking timer khi nắp đóng.
- [x] Mở nắp khi đang sôi tạm dừng cooking progress và boiling FX/audio.
- [x] Chỉ snap khi nắp đúng orientation, đúng khoảng cách và đúng snap point độc lập của nồi.
- [ ] Thực hiện rung/nảy nắp khi sôi bằng visual/animation an toàn, không phá physics hoặc gây rung camera.
- [x] Không cho xới khi nắp còn đóng.

### 5.5. Heat source, nấu chín và cháy khét

- [x] Nồi chỉ nhận nhiệt từ `WoodStove` đang cháy; không dùng tên object chứa `Stove` để bật nhiệt.
- [x] Theo dõi nhiều collider contact ổn định; một child collider exit không tắt nhiệt nếu collider khác vẫn tiếp xúc.
- [x] Cho phép tạm dừng/tiếp tục khi nhấc nồi khỏi bếp.
- [x] Sửa FSM để `Cooked -> Burnt` thực sự có thể xảy ra khi tiếp tục đun.
- [x] Bảo vệ `CompleteCooking()` và `BurnRice()` khỏi transition sai state.
- [x] Reset gạo, nước, timer và state sau khi xới hết mẻ một-bát hiện tại.

### 5.6. Củi và que diêm

- [x] `WoodStove.Ignite()` yêu cầu match khác null và đang cháy.
- [x] Không cho que diêm tự bén chỉ vì chạm object có tên `Table` hoặc `Stove`.
- [x] Tạo `MatchStriker` riêng và yêu cầu vận tốc quẹt tối thiểu.
- [x] Thả que diêm chưa cháy vào bếp không thể nhóm lửa.
- [x] Que diêm không bị tiêu thụ ngay khi nhóm bếp; nó tự tàn theo `burnDuration`.
- [x] Thêm củi khi bếp đang cháy cộng fuel/count trong giới hạn và cập nhật visual.

## 6. P1 — XR interaction, physics và UX

### 6.1. Cần quay cối

- [x] Scene validator kiểm tra `XRGrabInteractable`, collider và reference của handle trên setup sinh thật.
- [x] Handle tắt track position/rotation/scale nên tay không kéo cần rời pivot.
- [x] Giới hạn mỗi sample tối đa 45 độ để chặn spike tracking.
- [x] Thiết kế hiện tại cho quay hai chiều đều xay.
- [x] Haptic tỷ lệ tốc độ, giới hạn 0.5 amplitude và 10 Hz trong code (mức thiết bị thật vẫn cần QA).
- [ ] Keyboard simulator không được che giấu lỗi XR path.

### 6.2. Grab/snap và vật lý vật phẩm

- [ ] Kiểm tra mass, collision mode, interpolation và throw behavior trên thiết bị đích.
- [ ] Kiểm tra nested Rigidbody của nồi/nắp và parenting khi grab/release.
- [ ] Thêm snap zones rõ cho nồi trên bếp, nắp trên nồi và các dụng cụ nếu gameplay yêu cầu.
- [ ] Không để vật phẩm rơi xuyên Terrain/bàn/bếp hoặc spawn chồng collider.
- [ ] Kiểm tra kích thước theo world scale `1 Unity unit = 1 m` và tầm với tay người chơi.

### 6.3. Quest guide

- [x] Quest tiến theo state/output event thật của các hệ thống gameplay.
- [x] Không bỏ qua bước lấy gạo đã vo, đậy nắp hoặc xới cơm.
- [x] Billboard yaw-follow camera/player.
- [ ] Kiểm tra font, emoji, fallback font, kích thước và occlusion trên kính VR.
- [x] Có feedback lỗi trên quest guide cho sai/chưa vo nguyên liệu, thiếu/thừa nước, chưa có củi, diêm chưa cháy, nắp chưa đậy và rót nước trượt; không chỉ ghi Console.

## 7. P1 — Scene, prefab, asset, FX và audio

Hiện scene đang thiếu nhiều reference và dùng primitive fallback. Cần hoàn thiện:

- [ ] `GrindMillStation`: đã có white-rice prefab, output point, chaff particle và grinding clip; còn thiếu completion sound riêng.
- [ ] `WaterDipper`: đã có water surface, pour origin/FX; còn thiếu scoop/pour sound phù hợp.
- [ ] `RiceWashingPot`: đã có rice visual, water property block và drain FX; còn thiếu wash/drain sound phù hợp.
- [ ] `WoodStove`: đã có fire/smoke particle, light; còn thiếu ember art và ignition/fire audio phù hợp.
- [ ] `CookingPot`: đã có water visual, steam FX, bowl prefab; còn thiếu bộ material raw/cooked/burnt và boiling/cooked audio.
- [ ] `PotLid`: open/close audio và boiling-rattle feedback.
- [ ] `MatchItem`: striker, flame FX và strike sound.
- [ ] `CookedRiceBowl`: đã có prefab và burnt color rõ bằng property block; còn thiếu steam FX/art bát hoàn chỉnh.
- [ ] Thay primitive bằng prefab/art phù hợp; fallback chỉ dành cho debug và phải báo warning rõ.
- [ ] AudioSource không để `playOnAwake` nếu không có clip hợp lệ; cấu hình 3D rolloff phù hợp.
- [ ] Kiểm tra vị trí khu bếp theo địa hình và nhà sàn thật, không chỉ dựa vào tọa độ hardcode và `Terrain.activeTerrain`.

Scene validation bắt buộc:

- [x] Đúng một setup root trong scene.
- [x] Không có missing MonoBehaviour (đã loại một component mất script trên `Pause canvas`, giữ các Canvas component còn lại).
- [x] Validator kiểm tra prefab/component output, pour origin, washed-rice output, pot/lid, FX và toàn bộ reference của quest guide; lượt integrator gần nhất pass.
- [x] Hopper/source/wash/stove trigger và collider bắt buộc được generator cấu hình, validator kiểm tra reference.
- [ ] Không spawn dưới Terrain hoặc bên trong collider khác.
- [x] Chạy integrator lặp lại giữ đúng một setup root; chỉ thay root do tool sở hữu và sửa đúng missing component đã audit.

## 8. P1 — Nâng chất lượng automated tests

### 8.1. EditMode

- [ ] Thêm test cho mọi state transition hợp lệ và không hợp lệ.
- [x] Test raw rice bị nồi từ chối và vật phẩm không bị phá hủy.
- [x] Test water threshold nhất quán.
- [x] Test lid requirement.
- [x] Test `Cooked -> Burnt` reachable.
- [x] Test một mẻ xay chỉ sinh một rice output.
- [x] Test một mẻ nấu không thể sinh bowl vô hạn.
- [x] Test amount âm, null input, duplicate source/collider và completion gọi sai state.
- [x] Test quest từ chối skip và backward transition; event đến sai thứ tự không thể đưa guide đi trước gameplay.

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

- [x] Test domain-flow đã đổi tên, không còn tự nhận là end-to-end XR.
- [x] Ghi rõ bằng chứng: full suite gần nhất trước review là EditMode `96/96`, PlayMode `12/12`; sau review chỉ chạy các nhóm bị ảnh hưởng thay vì chạy lại toàn bộ.
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

- [x] Loại bỏ nhận diện gameplay dựa vào `GameObject.name` ở hopper, nguồn nước, match và heat source.
- [ ] Giảm public mutable state; dùng API transition có validation và property chỉ đọc khi phù hợp.
- [ ] Phân tách input/interaction, domain state và presentation/FX để test đúng lớp.
- [x] Quest và vật phẩm subscribe/unsubscribe event đối xứng theo enable/disable hoặc destroy.
- [x] Required functional reference fail validation trước khi save scene.
- [x] Production scene được nối white-rice/bowl prefab; fallback chỉ còn là guard debug trong runtime code.
- [x] Cập nhật `2026_08_31_work.md`: bỏ tuyên bố 100% cho đến khi đạt Definition of Done.
- [x] Phân biệt số full-suite cũ với targeted runs mới, không cộng gộp thành tuyên bố full-suite giả.
- [x] Sửa danh sách commit; bỏ commit `refactor(physics): polish VR lid parenting...` không tồn tại.
- [x] Ghi rõ file ngoài `Assets/Khoa` đã chỉnh: scene chính và work report, vì tích hợp/đính chính bằng chứng.

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

## 12. Cập nhật bằng chứng 2026-09-01

- Unity version: `6000.3.16f1`.
- Full-suite gần nhất trước vòng review này: EditMode `96/96 passed`; PlayMode `12/12 passed`.
- Vòng review này chỉ chạy test hẹp theo rủi ro: ba fixture mill/washing/cooking `41/41`; cooking + domain flow có `21/22` rồi test presentation lỗi được sửa và pass riêng `1/1`; cooking PlayMode `5/5`; washing `14/14`; burnt color `1/1`; heat-feedback hot path `1/1`. Không tuyên bố đây là một lần full-suite mới.
- Đã hoàn tất transaction vật lý `RiceThresher -> PaddyBatchItem -> hopper -> mill`, washing gesture theo quỹ đạo góc, local pour, typed water source/receiver, striker vận tốc, multi-collider heat, XR scoop/serve, snap nắp và quest state thực.
- Review bổ sung đã khóa recipe `10:1`, chặn duplicate rice/firewood, chặn `CompleteCooking()` bỏ qua heat/lid/timer, chặn quest skip/backward, chống re-grab output cũ reset mẻ mới, giữ overlap khi một trong nhiều collider exit, dùng prefab cho gạo đã vo, thêm spill feedback và burnt-rice color.
- Test duplicate firewood đã được viết nhưng lần Unity CLI cuối timeout 180 giây trước khi tạo report; hiện chỉ có review tĩnh cho thay đổi này, không tính là test pass.
- XRI mapping đã đối chiếu trực tiếp từ `XRI Default Input Actions`: Grip = Select/Grab, Trigger = Activate cho cả hai tay. Dev mapping được gom tại `CookingDevInputMap`: quay cối `A/Left Arrow` hoặc `D/Right Arrow/Z/Up Arrow`, lấy gạo đã vo `Q`, xới cơm `E`; test khóa cứng các phím này để tránh mapping bị lệch về sau.
- Integrator compile/chạy thành công; full scene validator pass: đúng một setup root, không Missing MonoBehaviour, output cối tuốt, output gạo đã vo và reference quest/chức năng bắt buộc đều tồn tại.
- Các test hiện tại vẫn chưa chứng minh full cycle bằng toàn bộ collider/XR event; một số PlayMode test còn kiểm tra từng cụm riêng.
- Audio/art hoàn chỉnh, lid rattle, snap nồi, full collider/XR-event cycle, Android/Quest build, profile, QA kính/controller và playtest vẫn chưa có bằng chứng. Do đó trạng thái tổng thể vẫn **chưa phải 100% Definition of Done**.

## 13. Khu Chuồng Trại và Phân Ủ Hữu Cơ

### 13.1. Chuỗi gameplay bắt buộc

- [ ] Bố trí ba khu riêng cạnh nhà sàn: chuồng trâu, chuồng bò và chuồng heo; không chắn bếp, giếng hoặc lối đi chính.
- [ ] Mỗi chuồng bắt đầu với một đống phân tươi, tái tạo sau `120 giây` kể từ khi thu gom và giữ tối đa hai đống chưa thu gom.
- [ ] Người chơi dùng Grip/XRI Select để cầm xẻng, đưa lưỡi xẻng vào phân và dùng Trigger/XRI Activate để xúc đúng một phần.
- [ ] Xẻng chỉ mang một phần; xúc/đổ là transaction atomic và không bị nhân đôi bởi nhiều collider.
- [ ] Đống ủ nhận đủ `3` phần mới chuyển từ `Filling` sang `Composting`; thời gian ủ mặc định `90 giây`.
- [ ] Phân chưa chín không thể lấy. Khi chín, đống ủ tạo đúng `3` phần phân hoai vật lý.
- [ ] Mỗi phần phân hoai chỉ bón được cho một `CropPlot` ở trạng thái `Tilled`; vật phẩm chỉ bị tiêu thụ khi bón thành công.
- [ ] Cây được cấy tiếp theo nhận hệ số tăng trưởng hiện có `1.5x`; hiệu lực không cộng dồn và kết thúc sau một vụ.
- [ ] Giữ tương thích với vật `Fertilizer` test cũ nhưng prefab gameplay chính phải dùng component typed, không chỉ dựa vào tag.

### 13.2. Kiến trúc, art và UX

- [ ] Tạo `BarnManureSource`, `ManureItem`, `ManureShovel`, `CompostPile`, `MatureFertilizerItem`, `BarnAnimalType` và `CompostState` trong module Khoa.
- [ ] API bón phân trên `CropPlot/RicePlant` trả kết quả thành công/thất bại để khóa transaction và tránh mất vật phẩm sai.
- [ ] Tái sử dụng prefab `Pigsty`, `Pig`, `Cow` và trâu hiện có; tạo wrapper/prefab chuồng thuộc `Assets/Khoa` và chỉ tham chiếu asset ngoài khi cần tích hợp.
- [ ] Trạng thái đống ủ có màu/mesh, hơi ấm nhẹ, âm thanh 3D và bảng tiến độ world-space dễ đọc trên kính.
- [ ] Feedback nói rõ xẻng rỗng, xẻng đang đầy, đống ủ thiếu nguyên liệu, phân chưa chín hoặc ruộng chưa cày.
- [ ] Dev simulator dùng `E` để xúc/đổ khi xẻng đang overlap target hợp lệ; không thay thế đường Grip + Trigger thật.
- [ ] Scene integrator idempotent dùng raycast Terrain và overlap check, không chỉ hardcode tọa độ; reject mọi scene diff reserialize diện rộng.

### 13.3. Kiểm thử và gate

- [ ] EditMode khóa cadence/capacity, compost FSM/timer/output, single-use fertilizer, một-vụ `1.5x` và multi-collider dedupe.
- [ ] PlayMode đi qua collider thật: xúc phân, đổ đủ ba phần, chờ ủ, lấy output và bón vào ruộng đã cày.
- [ ] Scene validator xác nhận đủ ba chuồng, động vật, nguồn phân, xẻng, compost pile, prefab output và UI reference.
- [ ] QA trên kính về tầm với, kích thước xẻng, readability, âm thanh, haptic và thao tác không gây khó chịu.

## 14. Cơ Chế Chèo Xuồng Ba Lá Bằng VR

### 14.1. Xuồng và fluid physics hybrid ổn định

- [ ] Tạo prefab xuồng Khoa-owned từ một thân thuyền đơn trong `FloatingMarket.fbx`; nếu không tách sạch được thì dùng tapered hull mesh hoàn chỉnh, không dùng primitive ở bản cuối.
- [ ] Xuồng dùng `Rigidbody`, collider đơn giản, bốn điểm nổi và `WaterSurfaceVolume`; lực nổi có damping và chạy trong `FixedUpdate`.
- [ ] Giới hạn mềm roll/pitch khoảng `10°`, tốc độ tiến `3.5 m/s`, lùi `1.2 m/s`, yaw `40°/s` và gia tốc `1.5 m/s²` để ưu tiên comfort VR.
- [ ] Hai mái chèo gắn vào oarlock bằng joint có giới hạn và mỗi mái có `XRGrabInteractable` riêng.
- [ ] Blade chỉ tạo fluid drag khi chìm trong water volume; vận tốc tương đối hướng về sau tạo lực tiến bằng `AddForceAtPosition`.
- [ ] Chèo lệch trái/phải tạo yaw đúng chiều; recovery stroke không sinh lực tiến giả; lực và tracking delta đều được clamp.
- [ ] Hai mái chèo phối hợp hoặc luân phiên được, không yêu cầu giữ Trigger trong lúc chèo.

### 14.2. Seat, input và comfort

- [ ] Trigger/XRI Activate vào ghế để lên xuồng; release một mái và Trigger vào tay vịn/dismount handle để xuống.
- [ ] Khi ngồi, tắt continuous move/turn thông thường; XR Origin theo seat anchor ổn định nhưng head tracking vẫn tự do.
- [ ] Khi xuống, phục hồi đúng locomotion trước đó và raycast một dismount point an toàn trên bờ/cầu.
- [ ] Mapping controller thật: Grip = cầm mái chèo, chuyển động tay = stroke, Trigger = mount/dismount tại interactable tương ứng.
- [ ] Dev mapping chỉ hoạt động khi ngồi: `W/S` stroke đối xứng, `A/D` stroke lệch để quay, `F` lên/xuống xuồng.
- [ ] Có splash tại blade, âm thanh nước/thân gỗ 3D, haptic tỷ lệ lực cản và hướng dẫn world-space không che tầm nhìn.

### 14.3. Scene, kiểm thử và gate

- [ ] Đặt xuồng tại bến gần cầu/mặt nước chính; xác minh tuyến nhà sàn -> chợ nổi -> khu câu cá không bị collider hoặc bờ vô hình chặn.
- [ ] Integrator tạo prefab instances, anchors và water volume idempotently; scene diff phải tối thiểu và không đổi line ending hàng loạt.
- [ ] EditMode khóa: ngoài nước không có thrust, stroke sau có thrust, stroke lệch có yaw, clamp tốc độ/nghiêng và mount/dismount phục hồi locomotion.
- [ ] PlayMode vật lý xác nhận xuồng nổi ổn định, hai mái chèo hoạt động qua grab/joint/water overlap, va chạm bờ hợp lý và XR Origin không jitter mạnh.
- [ ] Chỉ chạy targeted physics/seat/scene tests trước; không chạy lại full suite nếu thay đổi cục bộ đã compile và có kiểm chứng phù hợp.
- [ ] Chưa đánh dấu hoàn tất 100% trước khi test controller/kính thật, motion sickness, frame time Quest và full route tới chợ/NPC/khu câu cá.
