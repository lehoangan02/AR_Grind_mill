# Khoa Farming System

Hệ thống gameplay trồng lúa cho project VR `AR_Grind_mill`. Runtime nằm trong
namespace `Khoa.Farming`; scene mẫu đang dùng là
`Assets/Scenes/Grind mill v1.0 Scene.unity`.

## Bắt đầu nhanh

Scene chính đã có sẵn playable farming slice gồm grid do designer chọn, van nước,
sân phơi, máy tuốt, giỏ thóc, thời tiết, mái che và lưỡi bừa trên trâu. Grid
production đã chốt **100 x 100**, gồm đúng 10.000 plot map theo Terrain.

Cảnh quan Terrain dùng vegetation generator v2 riêng với gameplay lúa. Bản đã áp
dụng có **20.999** `TreeInstance` trên bốn Terrain; `RicePlant` và `Vegetable`
không được dùng làm cây trang trí.

Nếu scene bị merge hoặc cần tái tạo setup, mở Unity và chọn:

`Khoa > Farming > Apply Main Scene Integration`

Hoặc chạy ở thư mục project:

```powershell
unity run . -- -executeMethod Khoa.Farming.Editor.FarmingSceneIntegrator.ApplyMainSceneSetup
```

Tool giữ nguyên toàn bộ transform và kích thước grid hiện có, sau đó chỉ nối lại các
station. Nếu scene chính đang mở và có thay đổi chưa lưu (ví dụ grid vừa generate),
tool dùng ngay scene đó nên không làm mất thay đổi. Khi chạy từ scene khác đang dirty,
tool sẽ hỏi lưu; batch mode sẽ dừng an toàn.

## Luồng gameplay đã triển khai

1. Đi qua ruộng bằng trâu có lưỡi bừa, hoặc dùng tool tag `Plow`, để chuyển
   `Empty -> Tilled`.
2. Dùng mạ/tool tag `Seed` để cấy lúa (`Tilled -> Occupied`).
3. Mở cống hoặc dùng tool `Water`; dùng `Fertilizer` để tăng tốc sinh trưởng.
4. Khi lúa đạt `ReadyToHarvest` (từ 90%), dùng `Sickle` để gặt.
5. Đặt bó lúa lên sân phơi. Nắng làm khô; mưa làm giảm độ khô nếu bó không nằm
   trong `RiceShelterZone`.
6. Đưa bó đã khô 100% vào máy tuốt. Máy chỉ tiêu thụ bó khi một giỏ rỗng gần đó
   hoặc giỏ trong inventory nhận thóc thành công.
7. Nhặt các bông mót. Đủ 3 bông sẽ sinh thêm một bó ở vị trí nhặt cuối cùng.

## Tương tác VR quan trọng

- Plot không còn cho phép generic XR Select tự đổi trạng thái. Gameplay chuẩn phải
  dùng collider/tag của đúng nông cụ.
- Handle của cống dùng `XRGrabInteractable`. Khi nắm, vị trí tay được chiếu lên cung
  quay giới hạn 90° (đóng) đến 45° (mở); handle không thể bị kéo rời khỏi pivot.
- Góc cần điều khiển mức mở liên tục 0–100%. Lưu lượng tưới và âm lượng nước thay
  đổi theo đúng mức mở; thả gần hai đầu cung sẽ snap đóng/mở hoàn toàn.
- Chọn vào khung gỗ vẫn gọi `ToggleGate()` làm fallback cho desktop/test. Collider
  khung và collider handle được tách để hai interactable không tranh cùng thao tác.
- Integration nối đủ Left Select, Right Select và Left Move cho `BuffaloRider`.
- Lưỡi bừa có trigger collider cùng kinematic Rigidbody; vì vậy việc xới ruộng dùng
  đúng physics trigger thay vì chỉ hoạt động khi gọi hàm trực tiếp trong test.
- `RiceBundleItem` và `GleanedRiceStalk` dùng XR Grab; cảm giác cầm/ném cần được QA
  trên kính thật sau khi thay đổi scale hoặc collider.
- Bó lúa tạo từ mót xuất hiện trong world, không tự attach vào tay người chơi.

## Prefab chính

| Prefab | Vai trò |
|---|---|
| `Plot_Prefab` | Plot đất, visual ẩm/nước, cấy và gặt |
| `Rice_Prefab` | Cây lúa 5 trạng thái |
| `Rice_Bundle_Prefab` | Bó lúa có độ khô và lượng thóc |
| `Gleaned_Rice_Stalk_Prefab` | Bông lúa mót XR Grab |
| `Sluice_Gate_Prefab` | Cống tưới |
| `Rice_Drying_Yard_Prefab` | Sân phơi có trigger |
| `Rice_Thresher_Prefab` | Máy tuốt và receiver giỏ |

## Thông số đang dùng

| Thông số | Giá trị |
|---|---:|
| Thời gian lúa chín (`Rice_Data`) | 180 giây |
| Hệ số phân bón | 1.5x |
| Ngưỡng Growing / Maturing / Ready | 25% / 60% / 90% |
| Nước hiện khi có lúa / đất trống | 35% / 70% moisture |
| Lưu lượng cống prefab | 25 đơn vị/giây/plot |
| Nhịp cập nhật tưới | 0,1 giây |
| Tốc độ phơi | 5%/giây |
| Tốc độ ướt lại khi mưa | 8%/giây |
| Bông mót cần cho một bó | 3 |
| Bán kính tìm giỏ của máy tuốt | 2.5 m |
| Chu kỳ thời tiết ở scene chính | 120 giây |

## Editor tools

- `Khoa/Farming/Apply Main Scene Integration`: nối station vào grid hiện có; không
  đổi position, rotation hoặc số lượng plot; station bám Terrain và dùng giỏ output
  riêng của Khoa.
- `Khoa/Farming/Setup Farming Prefabs`: tạo/cập nhật prefab farming.
- `Khoa/Tạo Bộ Công Cụ Nông Nghiệp (Test)`: sinh bộ tool test VR.
- `Khoa/Farming/Generate Plot Grid`: tạo grid 100 x 100 mặc định theo terrain. Mặc định lấy mẫu
  3 x 3 trên footprint, lấy normal trung bình rồi nâng đáy plot đủ clearance tại
  mọi điểm mẫu. `3 x 3` nghĩa là 9 điểm trên mỗi plot; `5 x 5` là 25 điểm, chính
  xác hơn nhưng generate chậm hơn. Sampling tự chuyển sang Terrain tile kế bên khi
  footprint nằm trên đường seam.
- `Khoa/Farming/Generate Production Grid 100x100`: dùng tâm ruộng hiện tại, spacing
  0,08 m và sampling 5 x 5. Tool chỉ xóa grid cũ sau khi tạo đủ 10.000 plot, sau đó
  tự chạy Main Scene Integration.
- `Khoa/Vegetation/Preview Vietnamese Countryside Plan`: tạo plan và thống kê nhưng
  không thay đổi `TerrainData`.
- `Khoa/Vegetation/Apply Vietnamese Countryside Plan`: hiện confirm rồi thay bộ cây
  trang trí trên cả bốn Terrain bằng plan deterministic đã preview.
- Menu cũ `Tools/Generate Vietnamese Countryside Landscape` chỉ còn là alias an toàn
  sang generator v2; không còn chạy thuật toán jittered-grid cũ.

Vegetation v2 dùng Poisson-disc sampling, khoảng cách riêng theo kích thước tán,
phân vùng vườn nhà / ven nước / bờ ruộng / đồng mở, vùng cấm theo từng renderer và
collider thay vì gộp một hộp lớn cho cả root. Prototype được nhận diện bằng tên asset,
không phụ thuộc index 0..51. Scale được tính từ bounds prefab và kích thước mục tiêu
theo mét.

Có thể preview hoặc apply bằng Unity CLI:

```powershell
unity run . -- -executeMethod Khoa.Farming.Editor.VietnameseCountrysideVegetatorV2.CreatePreviewReportForMainScene
unity run . -- -executeMethod Khoa.Farming.Editor.VietnameseCountrysideVegetatorV2.ApplyBatch
```

CLI preview ghi report vào `Library/KhoaReports/VietnameseVegetationPreview.txt`;
thư mục này được Unity/Git bỏ qua và không làm bẩn working tree.

`ArecaPalm` hiện là nhóm palm gần hình dáng cây cau từ asset có sẵn, chưa phải model
cau thực. Project cũng chưa có prefab bạch đàn; nhóm `Melaleuca` là tràm và không được
coi là bạch đàn. Khi có đúng asset, cần cập nhật classifier/test trước khi apply lại.

## Chạy kiểm thử

```powershell
unity test . --mode EditMode --filter Khoa.Farming.Tests --output TestResults/KhoaEditMode.xml
unity test . --mode PlayMode --filter Khoa.Farming.PlayModeTests --output TestResults/KhoaPlayMode.xml
```

Mốc xác nhận 2026-08-25 bằng Unity CLI:

- **4/4** EditMode test mục tiêu cho continuous gate, mapping góc, prefab XR và cấu hình grid;
- **1/1** validation scene production 100 x 100;
- **5/5** PlayMode farming, gồm kiểm tra tưới thực tế theo tỷ lệ mức mở.

Toàn bộ EditMode suite không chạy lại trong đợt này để tránh test nặng không liên
quan; mốc full-suite gần nhất vẫn là 38/38 ngày 2026-08-24.

## Khi có lỗi

- Plot đổi state khi chỉ bấm vào đất: kiểm tra `allowDebugSelectInteractions` phải
  tắt và `XRSimpleInteractable` trên plot không được enable ở runtime.
- Mở cống nhưng ruộng không ướt: kiểm tra `connectedPlots`; ở scene phụ có thể bật
  `autoFindNearbyPlotsOnStart` và tăng `autoFindRadius`.
- Máy tuốt không nhận bó khô: đặt giỏ `RiceBasketController` rỗng trong 2.5 m. Không
  có đầu ra hợp lệ thì máy cố ý giữ lại bó.
- Không phơi được: bó phải đi qua trigger của `RiceDryingYard`; kiểm tra collider và
  layer collision matrix.
- Sau khi code team đổi `RiceBasketController`/inventory: chạy regression vì phần
  nối này dùng reflection và phụ thuộc tên API runtime.

Xem [context.md](context.md) để biết trạng thái, giới hạn và các việc còn lại; xem
[logic.md](logic.md) để đọc đặc tả FSM và transaction chi tiết.
