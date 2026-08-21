# 📋 Khoa Farming System — Context & Status Report
> **Cập nhật lần cuối:** 2026-08-21 13:21 (GMT+7)  
> **Branch:** `VR` → `origin/VR`  
> **Commit mới nhất:** `157b999b`  
> **Author:** Chris-KH <klowgamervn@gmail.com>

---

## 🗂️ Cấu Trúc Thư Mục `Assets/Khoa/`

```
Assets/Khoa/
├── Prefabs/
│   ├── Plot_Prefab.prefab        ← Ô đất ruộng (có Soil PBR material + WaterSurface con)
│   ├── Rice_Prefab.prefab        ← Cây lúa mẫu
│   └── Rice_Bundle_Prefab.prefab ← Bó lúa sau gặt (XRGrabInteractable)
├── ScriptableObjects/
│   └── Rice_Data.asset           ← CropData config cho lúa
├── Scripts/
│   ├── Farming/                  ← Namespace: Khoa.Farming
│   │   ├── CropData.cs           ← ScriptableObject định nghĩa thông số cây trồng
│   │   ├── CropPlot.cs           ← Ô đất ruộng (Empty → Tilled → Occupied, đổi màu theo nước)
│   │   ├── RicePlant.cs          ← Cây lúa (Seedling → Growing → Maturing → ReadyToHarvest → Dead)
│   │   ├── RiceBundleItem.cs     ← Bó lúa vật lý (XR Grab, phơi khô, tuốt hạt)
│   │   ├── SluiceGate.cs         ← Van nước kênh mương (tưới đồng loạt các plot kết nối)
│   │   ├── BuffaloPlowAttachment.cs ← Lưỡi bừa gắn trâu (tự xới đất khi đi qua)
│   │   ├── RiceDryingYard.cs     ← Sân phơi lúa (tăng drynessProgress theo nắng)
│   │   └── RiceThresher.cs       ← Cối tuốt lúa (tách hạt thóc + rơm rạ)
│   └── Editor/                   ← Namespace: Khoa.Farming.Editor (Editor-only tools)
│       ├── FarmingSetupEditor.cs  ← Menu tạo Prefab cho toàn bộ hệ thống
│       ├── FarmingTestKitCreator.cs ← Menu tạo bộ đồ nghề test VR (Cuốc, Mạ, Phân, Bình tưới, Liềm)
│       └── PlotGridGenerator.cs   ← Menu tạo lưới ô ruộng tự động theo Terrain
├── Tests/EditMode/
│   ├── FarmingLogicTests.cs       ← 5 test cases cơ bản
│   └── FarmingExtendedTests.cs    ← 5 test cases mở rộng (4 feature mới)
└── context.md                     ← (File này)
```

---

## ✅ Những Gì ĐÃ LÀM ĐƯỢC

### 1. Hệ Thống Trồng Lúa Cơ Bản (Feature 1 & 4)
- **CropPlot**: Ô đất 3 trạng thái (`Empty` → `Tilled` → `Occupied`).
  - Nhận va chạm với nông cụ theo Tag (`Plow`, `Seed`, `Fertilizer`, `Water`, `Sickle`).
  - Tự spawn `RicePlant` khi cấy và `RiceBundleItem` khi gặt.
- **RicePlant**: Cây lúa 5 giai đoạn (`Seedling` → `Growing` → `Maturing` → `ReadyToHarvest` → `Dead`).
  - Tự động mất nước theo thời gian, chết nếu cạn quá lâu.
  - Hỗ trợ bón phân tăng tốc, organic scaling lớn dần.
  - Hỗ trợ Model 3D cho từng giai đoạn (kéo thả vào Inspector).
- **RiceBundleItem**: Bó lúa VR cầm nắm được (XRGrabInteractable), có `drynessProgress` và `grainAmount`.
- **CropData (ScriptableObject)**: Config chung cho cây trồng (`timeToHarvest`, `maxWater`, `waterDepletionRate`...).

### 2. Dynamic Soil & Moisture Visuals (Mới)
- `CropPlot` đổi màu đất mượt mà theo tỷ lệ nước: `Color.Lerp(dryColor, wetColor, currentMoisture)`.
- Lớp váng nước (`waterSurfaceMesh`) tự bật khi ruộng ngập nước (≥35% nếu có cây, ≥70% nếu chưa).
- Tối ưu 0 GC Allocations bằng `MaterialPropertyBlock`.
- `Plot_Prefab.prefab` đã gán PBR `Soil.mat` (từ `ALP_Assets/NikolayFedorov`) và con `WaterSurface` (Quad).

### 3. Sluice Gate & Irrigation (Mới)
- `SluiceGate.cs`: Cần gạt mở/đóng van nước VR.
- Khi mở van → cấp nước liên tục mỗi frame cho toàn bộ `connectedPlots`.
- Hỗ trợ `AutoFindNearbyPlots(radius)` tự kết nối ô ruộng lân cận.
- Hỗ trợ particle (dòng nước) và AudioSource (tiếng nước chảy).

### 4. Buffalo Plowing (Mới)
- `BuffaloPlowAttachment.cs`: Gắn vào sau trâu, Trigger Collider tag `"Plow"`.
- Khi trâu đi qua `CropPlot.Empty` → tự động `PlowPlot()` thành `Tilled`.
- **KHÔNG sửa code `BuffaloRider.cs` của đồng đội** (0% xung đột).

### 5. Rice Drying Yard (Mới)
- `RiceDryingYard.cs`: Vùng sân phơi (Box Trigger).
- Tự động tăng `drynessProgress` cho các `RiceBundleItem` nằm trên sân khi `isSunny = true`.
- Khi đạt 100% → `isDry = true`, fire event `OnBundleDriedComplete`.

### 6. Rice Thresher (Mới)
- `RiceThresher.cs`: Cối tuốt lúa (Box Trigger).
- Từ chối bó lúa còn ướt (`isDry == false`).
- Bó lúa khô → tuốt ra `grainAmount * grainYieldMultiplier` hạt thóc, spawn `strawPrefab` rơm rạ.
- Fire event `OnRiceThreshed(int grains)` → kết nối với Inventory/GrindMill.

### 7. Editor Tools
- **Menu `Khoa/Farming/Setup Farming Prefabs`**: Tạo/cập nhật tất cả Prefab (Plot, Rice, Bundle, SluiceGate, DryingYard, Thresher).
- **Menu `Khoa/Tạo Bộ Công Cụ Nông Nghiệp (Test)`**: Spawn bộ đồ nghề VR test (Cuốc, Mạ, Phân, Bình tưới, Liềm) với XRGrabInteractable.
- **Menu `Khoa/Farming/Generate Plot Grid`**: Tạo lưới ô ruộng tự động trên Terrain (Raycast bám mặt đất).

### 8. Assembly Definitions
- `Khoa.Farming.asmdef` → Runtime scripts (`Assets/Khoa/Scripts/Farming/`)
- `Khoa.Farming.Editor.asmdef` → Editor tools (`Assets/Khoa/Scripts/Editor/`)
- `Khoa.Farming.Tests.asmdef` → Unit tests (`Assets/Khoa/Tests/EditMode/`)

### 9. Dọn Rác Dự Án
- Xoá 57 `.DS_Store`, 7 `mono_crash.*.json`, `fix_rice.py`, thư mục tạm.
- Cập nhật `.gitignore` chặn vĩnh viễn `.DS_Store`, `*.slnx`, `mono_crash.*.json`, `test-results.xml`.

---

## 🧪 Trạng Thái Kiểm Thử

### Unit Tests (EditMode) — 10/10 PASSED ✅
| # | Test Case | Mô tả | Kết quả |
|---|-----------|-------|---------|
| 1 | `Test_CropPlot_InitialState_IsEmpty` | Khởi tạo ô đất | ✅ |
| 2 | `Test_CropPlot_Plow_TransitionsToTilled` | Xới đất Empty → Tilled | ✅ |
| 3 | `Test_RiceBundleItem_AddDryness_CalculatesCorrectly` | Phơi khô bó lúa | ✅ |
| 4 | `Test_RicePlant_Fertilize_SetsFlag` | Bón phân | ✅ |
| 5 | `Test_RicePlant_Water_ClampsAtMaxWater` | Giới hạn nước tưới | ✅ |
| 6 | `Test_CropPlot_WaterPlot_IncreasesMoisture` | Độ ẩm đất tăng khi tưới | ✅ |
| 7 | `Test_SluiceGate_OpenClose_And_IrrigatesPlots` | Mở/đóng van nước | ✅ |
| 8 | `Test_BuffaloPlowAttachment_PlowsEmptyPlot` | Trâu bừa tự xới đất | ✅ |
| 9 | `Test_RiceDryingYard_DriesBundleToCompletion` | Sân phơi làm khô bó lúa | ✅ |
| 10 | `Test_RiceThresher_RejectsWet_AcceptsDryBundle` | Cối tuốt từ chối lúa ướt, tuốt lúa khô | ✅ |

### Chạy test bằng lệnh:
```bash
unity test --mode EditMode --output test-results.xml
```

### Chưa test trong VR thực tế:
- Chưa đeo kính VR để test cầm nắm, tương tác tay thật.
- Chưa test trong Scene chính (`Grind mill v1.0 Scene`) với terrain thật.
- Chưa test hiệu ứng particle (nước, bụi đất, hơi nước, hạt thóc).
- Chưa test âm thanh (cần gán AudioClip/AudioSource trong Inspector).

---

## ❌ Những Gì CHƯA LÀM

### Gameplay Mechanics Chưa Code
- [ ] **Trời mưa / Thay đổi thời tiết**: `RiceDryingYard.isSunny` hiện là biến thủ công, chưa có hệ thống thời tiết tự động.
- [ ] **Cối xay gạo kết nối**: `RiceThresher.OnRiceThreshed` fire event ra hạt thóc, nhưng chưa kết nối vật lý vào `RiceBasketController` / `GrindMillController` của đồng đội.
- [ ] **Rơm rạ (Straw)**: `RiceThresher.strawPrefab` chưa có Prefab rơm rạ thực tế.
- [ ] **Mót lúa**: Chưa có mechanic mót lúa rơi vãi sau khi gặt.
- [ ] **Vo gạo, nấu cơm**: Chưa bắt đầu.
- [ ] **Chèo thuyền, câu cá**: Chưa bắt đầu.
- [ ] **NPC đi cùng nhắc nhiệm vụ**: Chưa bắt đầu.
- [ ] **Quest system / Game flow**: Chưa có hệ thống quest chain nối các bước lại.

### Asset Chưa Có
- [ ] **Model 3D cày bừa / lưỡi bừa** thật (đang dùng BoxCollider placeholder).
- [ ] **Model 3D van nước kênh mương** thật (đang dùng Cube + Cylinder placeholder).
- [ ] **Model 3D sân phơi lúa** thật (đang dùng Cube phẳng placeholder).
- [ ] **Model 3D cối tuốt lúa** thật (đang dùng Cube placeholder).
- [ ] **Model 3D cây lúa 4 giai đoạn**: Có slot trong Inspector (`modelSeedling`, `modelGrowing`, `modelMaturing`, `modelReady`) nhưng chưa gán model thật.
- [ ] **Hiệu ứng Particle**: `plowDustParticles`, `steamParticleFX`, `grainParticleFX`, `waterFlowParticles` chưa gán.
- [ ] **Âm thanh**: Chưa có audio clip cho tưới nước, cày đất, tuốt lúa, gặt lúa.

### Prefab Chưa Tạo Trong Editor
- [ ] `Sluice_Gate_Prefab.prefab` — có thể tạo qua menu `Khoa/Farming/Setup Farming Prefabs`.
- [ ] `Rice_Drying_Yard_Prefab.prefab` — có thể tạo qua menu.
- [ ] `Rice_Thresher_Prefab.prefab` — có thể tạo qua menu.
- [ ] Chưa gắn `BuffaloPlowAttachment` vào con trâu trong Scene — có thể làm qua menu `Khoa/Farming/Setup Farming Prefabs` > nút "Gắn Lưỡi Bừa".

---

## ⚠️ Lưu Ý Kỹ Thuật

### Assembly References
- `Khoa.Farming.Editor.asmdef` **không reference được** đến `BuffaloRider.cs` (nằm ở `Assets/Scripts/`, không có asmdef, không có namespace).
  - Workaround: dùng `FindObjectsByType<MonoBehaviour>` + check `GetType().Name == "BuffaloRider"`.

### Xung Đột Code Đồng Đội
- **BuffaloRider.cs** (`Assets/Scripts/`): KHÔNG ĐƯỢC SỬA. Tạo component phụ trợ `BuffaloPlowAttachment.cs` gắn bên cạnh.
- **GrindMillController.cs** (`Assets/MyFolder/Scripts/Interactiable/`): KHÔNG ĐƯỢC SỬA. Kết nối qua event `RiceThresher.OnRiceThreshed`.
- **InteractableObject.cs**, **InventoryController.cs**, **SelectionController.cs**: Thuộc đồng đội, không đụng chạm.

### Texture PBR Đất Đã Có Sẵn
- **Đất tự nhiên**: `Assets/ALP_Assets/NikolayFedorov/PBR_Tiled/Textures/Other/Soil01_Base_Color.tga` + `Soil01_Normal.tga`
- **Material**: `Assets/ALP_Assets/NikolayFedorov/PBR_Tiled/OtherMaterials/Soil.mat` (GUID: `27b3b80f9b99d2d4f8ebc409cb6950d0`)
- **Đã gán vào Plot_Prefab.prefab** thay thế Default-Material.

---

## 🔗 Git Commits Liên Quan (Mới → Cũ)

| Commit | Mô Tả |
|--------|-------|
| `157b999b` | fix: Editor tool tạo Prefab cho 4 feature, fix cross-assembly, gán Soil.mat vào Plot |
| `2eaf1f53` | feat: Dynamic soil visuals, SluiceGate, BuffaloPlow, DryingYard, Thresher |
| `3005aa75` | chore: Dọn rác .DS_Store, crash dumps, cập nhật .gitignore |
| `7d623e6e` | test: Unit tests EditMode + asmdef cho Farming system |
| `2c0858f7` | feat: Feature 1 (harvest physics) & Feature 4 (multi-stage 3D rice) |
| `805b0858` | optimize: MaterialPropertyBlock, fix references, cache growth rate |

---

## 🎯 Gợi Ý Bước Tiếp Theo

1. **Mở Unity Editor** → Menu `Khoa/Farming/Setup Farming Prefabs` → Bấm tạo Prefab SluiceGate, DryingYard, Thresher.
2. **Mở Scene chính** → Kéo thả các Prefab vào vị trí phù hợp trên map.
3. **Gắn bừa vào trâu**: Menu `Khoa/Farming/Setup Farming Prefabs` → nút "Gắn Lưỡi Bừa Tự Động Vào Trâu Trong Scene".
4. **Gán Model 3D thật** cho cây lúa, van nước, sân phơi, cối tuốt (thay thế placeholder Cube/Cylinder).
5. **Gán AudioClip** cho các hiệu ứng âm thanh.
6. **Kết nối `RiceThresher.OnRiceThreshed` → `InventoryController`** để hạt thóc vào kho.
7. **Test VR thực tế** trên kính.
