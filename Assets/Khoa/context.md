# Khoa Farming System — Context hiện tại

> Cập nhật: 2026-08-25 (GMT+7)
>
> Branch kiểm tra: `VR`
>
> Người thực hiện chuỗi commit gần đây: Chris-KH

## 1. Phạm vi đã đối chiếu

Trạng thái này được lập từ `now_plan.md`, code/prefab trong `Assets/Khoa/`, scene chính
`Assets/Scenes/Grind mill v1.0 Scene.unity`, lịch sử Git của Chris-KH và kết quả chạy bằng Unity CLI.

Chuỗi commit ngày 2026-08-21 cho thấy Chris-KH đã lần lượt làm nền tảng trồng/gặt,
visual đất và nước, van tưới, trâu bừa, sân phơi, máy tuốt, thời tiết/mái che,
tích hợp giỏ, mót lúa, particle/audio helper, test và tài liệu. Commit tài liệu gần
nhất trước đợt sửa này là `b8537728`.

## 2. Trạng thái đã xác nhận

### Code và prefab

- `CropPlot`: FSM `Empty -> Tilled -> Occupied`; thao tác gameplay đi qua nông cụ có
  tag `Plow`, `Seed`, `Fertilizer`, `Water`, `Sickle`. Generic XR Select bị tắt mặc
  định để không bỏ qua nông cụ.
- `RicePlant`: 5 trạng thái, ngưỡng đúng là 25% / 60% / 90%; thiếu nước thì ngừng
  lớn và chết sau thời gian cấu hình.
- Visual ruộng: đất đổi màu theo độ ẩm; lớp nước hiện ở 35% khi có lúa và 70% khi
  đất trống/đã bừa.
- `SluiceGate`: tưới các plot đã nối; nếu một scene khác chưa gán danh sách, `Start()`
  tự quét plot gần đó trong bán kính cấu hình. Scene lớn được tưới theo tick 0,1
  giây thay vì quét toàn bộ grid mỗi rendered frame. `openAmount` 0..1 lấy từ góc
  cần gạt và nhân trực tiếp vào lưu lượng nước.
- `SluiceGateLever`: handle XR Grab quay quanh pivot cố định từ 90° đến 45°. XRI
  không được phép track position/rotation/scale của handle, nên người chơi có thể
  kéo cần nhưng không thể giật nó rời khỏi cống. Thả gần endpoint sẽ snap.
- `BuffaloPlowAttachment`: gắn dưới object có `BuffaloRider`, xới plot qua trigger
  mà không sửa `BuffaloRider.cs`. Lưỡi bừa tự bảo đảm có trigger collider và
  kinematic Rigidbody, nên physics callback hoạt động ngay cả khi plot và trâu đều
  không có Rigidbody.
- `RiceDryingYard`, `FarmingWeatherSystem`, `RiceShelterZone`: phơi nắng, làm ướt
  lại khi mưa và bảo vệ bó lúa trong vùng mái che.
- `RiceThresher`: chỉ nhận bó lúa khô. Đây là giao dịch an toàn: bó lúa chỉ bị tiêu
  thụ sau khi `RiceThresherBasketReceiver` xác nhận một giỏ vật lý hoặc giỏ inventory
  đã nhận thóc. Không có đầu ra thì bó lúa được giữ nguyên.
- `GleanedRiceStalk`: đủ 3 bông sẽ sinh một bó lúa gần vị trí bông cuối cùng; không
  tự gắn bó vào tay. Bộ đếm static được reset khi bắt đầu play session mới.
- Prefab máy tuốt không còn missing script; GUID của receiver đã được sửa đúng.
- `Plot_Prefab` đặt `SpawnPoint` tại mặt trên collider, không còn sinh cây/bó lúa
  từ giữa thể tích đất.

### Scene chính

Scene chính hiện có một playable farming slice được Unity tạo và lưu. Grid production
đã chốt **100 x 100**, gồm đúng **10.000 plot** tại root
`Farm_Grid_Production_100x100`. Grid dùng tâm cũ `(9.9, 100, -204.4)`, spacing
0,08 m và lấy mẫu Terrain 5 x 5 trên mỗi footprint:

- mỗi plot giữ nguyên position/rotation đã map theo Terrain;
- `Apply Main Scene Integration` không xóa, thu nhỏ, làm phẳng hay đổi cao độ grid;
  nếu scene chính đang mở và có thay đổi chưa lưu, tool dùng trực tiếp scene đó thay
  vì mở lại rồi làm mất grid vừa generate;
- đúng một van tưới nối đủ mọi plot trong grid hiện tại;
- van có đúng một physical lever, XR Grab riêng và kinematic Rigidbody;
- đúng một sân phơi, máy tuốt, giỏ thóc vật lý, weather system và shelter zone;
- đúng một lưỡi bừa gắn vào object có `BuffaloRider`;
- `BuffaloRider` đã được nối đủ Left Select, Right Select và Left Move từ XRI Default
  Input Actions;
- van, sân phơi, máy tuốt và giỏ output được đặt theo mặt Terrain tại vị trí của
  chính chúng, không lấy cao độ mặt nước làm mặt đất;
- integration luôn tạo giỏ output riêng dưới `Khoa_Farming_Runtime_Setup`, không
  chiếm và di chuyển giỏ của hệ thống khác trong scene;
- particle nước, hơi phơi, hạt thóc và bùn đã được nối vào component tương ứng.

### Cảnh quan cây trên Terrain

Vegetation generator v2 đã thay thuật toán jittered-grid cũ bằng plan deterministic:

- bốn Terrain có tổng **20.999** cây trang trí, lần lượt 5.304 / 5.149 / 5.350 /
  5.196 instance;
- 50/52 prototype được sử dụng; hai prototype cố ý không dùng là `Vegetable` và
  `RicePlant`;
- phân bố hiện tại: tràm 5.327, nhóm tre 5.071, chanh 3.948, chuối 3.464, dừa
  1.645, palm gần-cau 1.215 và palm cluster 329;
- không nhóm nào vượt 35% tổng cây; nhóm cao nhất hiện khoảng 25,4%;
- điểm neo dùng Poisson-disc, sau đó lọc theo nước, dốc, công trình, texture đường,
  mật độ zone và khoảng cách tán theo loài;
- vùng cấm dùng bounds nhỏ của từng renderer/collider. Grid 100 x 100 vẫn dùng một
  bounds tổng riêng để tránh duyệt và index 10.000 plot;
- khoảng cách render Terrain đã giảm còn 650 m, billboard 55 m và tối đa 150 cây
  full LOD để hợp lý hơn cho VR.

Preview không ghi asset; Apply mới thay `TreeInstance` và lưu scene. `ArecaPalm` vẫn
là placeholder từ generic palm asset. Chưa có prefab cau và bạch đàn đúng loài trong
project; `Melaleuca` là tràm, không phải bạch đàn.

Tool tái tạo/cập nhật setup: `Khoa/Farming/Apply Main Scene Integration`, hoặc:

```powershell
unity run . -- -executeMethod Khoa.Farming.Editor.FarmingSceneIntegrator.ApplyMainSceneSetup
```

## 3. Kiểm thử đã chạy bằng Unity CLI

Đợt thay đổi ngày 2026-08-25 chủ động chỉ chạy test mục tiêu nhẹ:

- EditMode lever/grid: **4/4 passed**.
- Validation scene production: **1/1 passed**.
- PlayMode `Khoa.Farming.PlayModeTests`: **5/5 passed**.

PlayMode hiện kiểm tra thêm đường tưới thật: van mở 25% cấp đúng một phần tư lượng
nước so với van mở hoàn toàn. Full EditMode suite không chạy lại để tránh tốn tài
nguyên không liên quan; mốc gần nhất là 38/38 ngày 2026-08-24.

## 4. Các lỗi cũ đã sửa trong đợt audit

- Missing script trên `Rice_Thresher_Prefab` do GUID sai.
- Generic select trên plot có thể tự đi qua chuỗi bừa/cấy/gặt mà không cần tool.
- Máy tuốt hủy bó lúa dù không có giỏ nhận thóc.
- Cống ở scene mới có danh sách rỗng và không tự kết nối.
- Bộ đếm mót lúa tồn tại qua play session.
- Tài liệu ghi sai ngưỡng 33/66/100, sai điều kiện hiện nước và sai việc bó mót
  “xuất hiện trên tay”.
- Scene chính chưa tích hợp farming station và cao độ ruộng sai.
- Bản integration cũ từng ép mọi plot về cùng cao độ nước và reset rotation, làm
  mất terrain mapping; bước này đã bị xóa và có regression bảo vệ.
- Integration từng mở lại scene chính vô điều kiện nên có thể làm mất grid chưa
  lưu; nay scene chính đang mở được giữ nguyên.
- Trigger lưỡi bừa từng không chạy vì cả hai phía đều thiếu Rigidbody.
- Van từng duyệt 6.400 plot mỗi rendered frame và `RicePlant` log mỗi lần nhận nước.
- Integration từng có thể lấy nhầm giỏ của designer rồi reparent/di chuyển nó.
- Tìm `FieldWaterPlane`/`StiltHouse` từng bỏ sót object inactive.
- Hai input của `BuffaloRider` từng để null; integration nay nối đủ cả ba action.
- Tool grid mặc định 20 x 20 không khớp kích thước production; mặc định và scene
  chính nay đều đã chốt 100 x 100.
- Van cũ chỉ toggle hai trạng thái; prefab mới có physical grab handle, mức mở liên
  tục và lưu lượng tỷ lệ theo góc.

## 5. Chưa được coi là hoàn tất

- Cần QA trực tiếp bằng kính VR cho cảm giác cầm/ném, vùng trigger, tầm với, vị trí
  station và góc kéo cần. Automated tests đã xác nhận mapping, constraint, Rigidbody
  và dòng nước nhưng không thay thế được kiểm tra ergonomics bằng tay thật.
- Quest/NPC dẫn đường, UI hướng dẫn, save/load tiến độ và audio clip thực tế chưa
  nằm trong farming slice này.
- Theo `now_plan.md`, bếp + vo/nấu cơm, chèo thuyền/câu cá và NPC nhắc nhiệm vụ vẫn
  là công việc riêng chưa được hệ thống Khoa triển khai.
- Cảnh quan cây vẫn cần một vòng nhìn trực tiếp trong Scene/VR để tinh chỉnh art
  direction. Cần thay palm placeholder bằng model cau thật và bổ sung prefab bạch đàn
  trước khi coi yêu cầu đa dạng loài đã hoàn tất tuyệt đối.

## 6. Quy tắc tích hợp

- Runtime chính nằm trong assembly `Khoa.Farming`; editor tool và tests có assembly
  riêng.
- Kết nối với `RiceBasketController`, inventory và `BuffaloRider` dùng tra cứu type/
  reflection để tránh hard reference giữa assembly. Điều này giảm compile coupling
  nhưng vẫn cần regression test nếu code của team đổi tên field, type hoặc method.
- Khi đổi prefab hoặc scene, luôn chạy cả EditMode và PlayMode bằng Unity CLI trước
  khi cập nhật trạng thái trong tài liệu.
- Nếu chạy integration từ một scene khác đang dirty, bản interactive sẽ hỏi lưu;
  batch mode sẽ dừng thay vì âm thầm bỏ thay đổi của scene đó.
