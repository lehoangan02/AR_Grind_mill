# Khoa Farming System — Context hiện tại

> Cập nhật: 2026-08-21 (GMT+7)
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
  tự quét plot gần đó trong bán kính cấu hình.
- `BuffaloPlowAttachment`: gắn dưới object có `BuffaloRider`, xới plot qua trigger
  mà không sửa `BuffaloRider.cs`.
- `RiceDryingYard`, `FarmingWeatherSystem`, `RiceShelterZone`: phơi nắng, làm ướt
  lại khi mưa và bảo vệ bó lúa trong vùng mái che.
- `RiceThresher`: chỉ nhận bó lúa khô. Đây là giao dịch an toàn: bó lúa chỉ bị tiêu
  thụ sau khi `RiceThresherBasketReceiver` xác nhận một giỏ vật lý hoặc giỏ inventory
  đã nhận thóc. Không có đầu ra thì bó lúa được giữ nguyên.
- `GleanedRiceStalk`: đủ 3 bông sẽ sinh một bó lúa gần vị trí bông cuối cùng; không
  tự gắn bó vào tay. Bộ đếm static được reset khi bắt đầu play session mới.
- Prefab máy tuốt không còn missing script; GUID của receiver đã được sửa đúng.

### Scene chính

Scene chính hiện có một playable farming slice được Unity tạo và lưu. Grid hiện tại
là bản 80 x 80 do designer generate để thử. Bản sinh trước khi sửa seam có 6.320
plot vì thiếu một cột tại ranh giới Terrain; generate lại bằng tool mới sẽ đủ 6.400.
Kích thước production vẫn có thể generate lại 100 x 100:

- mỗi plot giữ nguyên position/rotation đã map theo Terrain;
- `Apply Main Scene Integration` không xóa, thu nhỏ, làm phẳng hay đổi cao độ grid;
- đúng một van tưới nối đủ mọi plot trong grid hiện tại;
- đúng một sân phơi, máy tuốt, giỏ thóc vật lý, weather system và shelter zone;
- đúng một lưỡi bừa gắn vào object có `BuffaloRider`;
- particle nước, hơi phơi, hạt thóc và bùn đã được nối vào component tương ứng.

Tool tái tạo/cập nhật setup: `Khoa/Farming/Apply Main Scene Integration`, hoặc:

```powershell
unity run . -- -executeMethod Khoa.Farming.Editor.FarmingSceneIntegrator.ApplyMainSceneSetup
```

## 3. Kiểm thử đã chạy bằng Unity CLI

Ngày 2026-08-21:

- EditMode `Khoa.Farming.Tests`: **30/30 passed**.
- PlayMode `Khoa.Farming.PlayModeTests`: **2/2 passed**.
- Regression riêng gồm kiểm tra prefab, FSM, ngưỡng tăng trưởng, transaction máy
  tuốt, reset mót lúa, wiring scene, bảo toàn transform và terrain clearance:
  **13/13 passed**.

PlayMode hiện kiểm tra hai đường runtime quan trọng: van tự tìm plot và tưới theo
frame; sân phơi nhận bó lúa qua trigger rồi tăng độ khô.

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

## 5. Chưa được coi là hoàn tất

- Cần QA trực tiếp bằng kính VR cho cảm giác cầm/ném, vùng trigger, tầm với và vị
  trí station; automated tests không thay thế được kiểm tra ergonomics.
- Lever của van hiện là tương tác chọn/grip để toggle và cập nhật góc hiển thị;
  chưa phải cần gạt vật lý liên tục có joint/angle constraint.
- Quest/NPC dẫn đường, UI hướng dẫn, save/load tiến độ và audio clip thực tế chưa
  nằm trong farming slice này.
- Theo `now_plan.md`, bếp + vo/nấu cơm, chèo thuyền/câu cá và NPC nhắc nhiệm vụ vẫn
  là công việc riêng chưa được hệ thống Khoa triển khai.

## 6. Quy tắc tích hợp

- Runtime chính nằm trong assembly `Khoa.Farming`; editor tool và tests có assembly
  riêng.
- Kết nối với `RiceBasketController`, inventory và `BuffaloRider` dùng tra cứu type/
  reflection để tránh hard reference giữa assembly. Điều này giảm compile coupling
  nhưng vẫn cần regression test nếu code của team đổi tên field, type hoặc method.
- Khi đổi prefab hoặc scene, luôn chạy cả EditMode và PlayMode bằng Unity CLI trước
  khi cập nhật trạng thái trong tài liệu.
