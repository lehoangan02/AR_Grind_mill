# 📋 Khoa Farming System — Context & Status Report
> **Cập nhật lần cuối:** 2026-08-21 17:26 (GMT+7)  
> **Branch:** VR → origin/VR  
> **Commit mới nhất:** 5c2afc99  
> **Author:** Chris-KH <klowgamervn@gmail.com>

---

## 🗂️ Cấu Trúc Thư Mục Assets/Khoa/

`
Assets/Khoa/
├── Prefabs/
│   ├── Plot_Prefab.prefab              ← Ô đất ruộng (Soil PBR + WaterSurface con)
│   ├── Rice_Prefab.prefab              ← Cây lúa mẫu
│   ├── Rice_Bundle_Prefab.prefab       ← Bó lúa sau gặt (XRGrabInteractable)
│   ├── Sluice_Gate_Prefab.prefab       ← Van nước kênh mương (XR Interactable)
│   ├── Rice_Drying_Yard_Prefab.prefab  ← Sân phơi lúa gạch PBR
│   └── Rice_Thresher_Prefab.prefab     ← Cối tuốt lúa (kèm RiceThresherBasketReceiver)
├── ScriptableObjects/
│   └── Rice_Data.asset                 ← CropData config cho lúa
├── Scripts/
│   ├── Farming/                        ← Namespace: Khoa.Farming
│   │   ├── CropData.cs                 ← ScriptableObject thông số cây trồng
│   │   ├── CropPlot.cs                 ← Ô đất ruộng (Empty → Tilled → Occupied, đổi màu theo nước)
│   │   ├── RicePlant.cs                ← Cây lúa (5 giai đoạn tăng trưởng)
│   │   ├── RiceBundleItem.cs           ← Bó lúa vật lý (XR Grab, phơi khô, che mưa)
│   │   ├── SluiceGate.cs               ← Van nước kênh mương (tưới đồng loạt)
│   │   ├── BuffaloPlowAttachment.cs    ← Lưỡi bừa gắn trâu (tự xới đất)
│   │   ├── RiceDryingYard.cs           ← Sân phơi lúa (phơi nắng + cơ chế mưa ướt)
│   │   ├── RiceThresher.cs             ← Cối tuốt lúa (tách hạt thóc + rơm rạ)
│   │   ├── FarmingWeatherSystem.cs     ← Quản lý thời tiết Nắng / Mưa / Âm u
│   │   ├── RiceShelterZone.cs          ← Khu vực có mái che bảo vệ lúa khi mưa
│   │   └── RiceThresherBasketReceiver.cs ← Nạp thóc vào Giỏ lúa (RiceBasket) & Túi đồ (Inventory)
│   └── Editor/                         ← Namespace: Khoa.Farming.Editor (Editor tools)
│       ├── FarmingSetupEditor.cs        ← Menu tạo Prefab cho toàn bộ hệ thống
│       ├── FarmingTestKitCreator.cs     ← Menu tạo bộ đồ nghề test VR
│       └── PlotGridGenerator.cs         ← Menu tạo lưới ô ruộng tự động theo Terrain
├── Tests/EditMode/
│   ├── FarmingLogicTests.cs             ← 5 test cases cơ bản
│   └── FarmingExtendedTests.cs          ← 9 test cases mở rộng (Weather, Shelter, Basket Receiver)
└── context.md                           ← (File này)
`

---

## ✅ Những Gì ĐÃ LÀM ĐƯỢC

### 1. Hệ Thống Trồng Lúa Cơ Bản
- **CropPlot**: Ô đất 3 trạng thái (Empty → Tilled → Occupied), nhận va chạm nông cụ VR.
- **RicePlant**: Cây lúa 5 giai đoạn (Seedling → Growing → Maturing → ReadyToHarvest → Dead), bón phân tăng tốc, héo khi cạn nước.
- **RiceBundleItem**: Bó lúa VR cầm nắm được, có drynessProgress, isDry, isSheltered.

### 2. Dynamic Soil & Moisture Visuals
- CropPlot đổi màu đất mượt mà Color.Lerp(dryColor, wetColor, currentMoisture).
- Váng nước (waterSurfaceMesh) tự bật khi ruộng ngập nước.
- Prefab đã gán PBR Soil.mat.

### 3. Sluice Gate & Irrigation
- SluiceGate.cs: Cần gạt mở/đóng van nước VR, tưới đồng loạt các ô ruộng kết nối.
- Đã tạo sẵn Sluice_Gate_Prefab.prefab.

### 4. Buffalo Plowing
- BuffaloPlowAttachment.cs: Gắn vào sau trâu, tự xới đất khi đi qua.
- **KHÔNG sửa code BuffaloRider.cs của đồng đội** (0% xung đột).

### 5. Rice Drying Yard & Weather Integration
- RiceDryingYard.cs: Sân phơi tăng độ khô khi trời nắng.
- **Tích hợp thời tiết**: Khi trời mưa (WeatherType.Rainy), sân phơi dừng phơi và làm giảm độ khô lúa nếu không được che chắn.
- Đã tạo sẵn Rice_Drying_Yard_Prefab.prefab.

### 6. Farming Weather System & Shelter Zone (Mới)
- FarmingWeatherSystem.cs: Quản lý Sunny, Rainy, Overcast, hỗ trợ auto cycle hoặc đổi thủ công, phát event OnWeatherChanged.
- RiceShelterZone.cs: Khu vực có mái che (Hiên nhà, kho lúa), bảo vệ bó lúa khỏi mưa bão.

### 7. Rice Thresher & Giỏ Lúa / Inventory Integration (Mới)
- RiceThresher.cs: Cối tuốt lúa, từ chối lúa ướt, tuốt lúa khô sinh thóc + rơm rạ.
- RiceThresherBasketReceiver.cs: Tự động tìm RiceBasketController gần cối hoặc trong InventoryController của người chơi để nạp đầy thóc vàng (SetFull(true)).
- Đã tạo sẵn Rice_Thresher_Prefab.prefab.

### 8. Editor Tools
- **Menu Khoa/Farming/Setup Farming Prefabs**: Tạo/cập nhật đầy đủ 6 Prefabs.
- **Menu Khoa/Tạo Bộ Công Cụ Nông Nghiệp (Test)**: Spawn bộ đồ nghề VR test.
- **Menu Khoa/Farming/Generate Plot Grid**: Tạo lưới ô ruộng tự động trên Terrain.

---

## 🧪 Trạng Thái Kiểm Thử

### Unit Tests (EditMode) — 14/14 PASSED (100%) ✅
| # | Test Case | Mô tả | Kết quả |
|---|-----------|-------|---------|
| 1 | Test_CropPlot_InitialState_IsEmpty | Khởi tạo ô đất | ✅ |
| 2 | Test_CropPlot_Plow_TransitionsToTilled | Xới đất Empty → Tilled | ✅ |
| 3 | Test_RiceBundleItem_AddDryness_CalculatesCorrectly | Phơi khô bó lúa | ✅ |
| 4 | Test_RicePlant_Fertilize_SetsFlag | Bón phân | ✅ |
| 5 | Test_RicePlant_Water_ClampsAtMaxWater | Giới hạn nước tưới | ✅ |
| 6 | Test_CropPlot_WaterPlot_IncreasesMoisture | Độ ẩm đất tăng khi tưới | ✅ |
| 7 | Test_SluiceGate_OpenClose_And_IrrigatesPlots | Mở/đóng van nước | ✅ |
| 8 | Test_BuffaloPlowAttachment_PlowsEmptyPlot | Trâu bừa tự xới đất | ✅ |
| 9 | Test_RiceDryingYard_DriesBundleToCompletion | Sân phơi làm khô bó lúa | ✅ |
| 10 | Test_RiceThresher_RejectsWet_AcceptsDryBundle | Cối tuốt từ chối lúa ướt, tuốt lúa khô | ✅ |
| 11 | Test_FarmingWeatherSystem_StateTransition | Chuyển đổi thời tiết Nắng/Mưa/Âm u | ✅ |
| 12 | Test_RiceDryingYard_RainDecay_WhenNotSheltered | Lúa phơi ngoài mưa bị giảm độ khô | ✅ |
| 13 | Test_RiceShelterZone_ProtectsBundleFromRain | Nhà kho che chở lúa an toàn khi mưa | ✅ |
| 14 | Test_RiceThresherBasketReceiver_ComponentSetup | Cấu hình bộ nhận thóc vào Giỏ lúa | ✅ |

### Lệnh chạy test:
`ash
unity test --mode EditMode --output test-results.xml
`

---

## ❌ Những Gì CHƯA LÀM (Cho Các Buổi Tiếp Theo)

### 1. Gameplay Mechanics Còn Lại (Theo now_plan.md)
- [ ] **Thêm Nhà Bếp & Cơ Chế Vo Gạo - Nấu Cơm** *(Task của Khoa - Dòng 29, 59, 103)*:
  - Dựng khu vực bếp bên phải nhà chính.
  - Tương tác: Lấy gạo từ cối xay (GrindMillController) -> Cho vào nồi -> Vo gạo -> Nấu cơm.
- [ ] **Cơ Chế Mót Lúa** *(Dòng 91)*: Nhặt những bông lúa rơi vãi trên ruộng sau khi gặt.
- [ ] **Chèo thuyền, câu cá VR** *(Dòng 57, 93-99)*: Chưa bắt đầu.
- [ ] **NPC nhắc nhiệm vụ** *(Dòng 67)*: Chưa bắt đầu.

### 2. Assets 3D & Audio Polish
- [ ] Thay model placeholder bằng 3D mesh thật (Lưỡi bừa, van nước, sân phơi, cối tuốt, cây lúa 4 giai đoạn).
- [ ] Gán AudioClip thật (tiếng tưới nước, tiếng mưa rơi, tiếng cối tuốt lúa, tiếng xới đất).
- [ ] Gán ParticleFX thật (mưa rơi, nước chảy kênh, bụi bừa đất, hạt thóc bắn).

---

## ⚠️ Lưu Ý Kỹ Thuật & Tương Thích

1. **Assembly Separation**:
   - Runtime scripts nằm trong Khoa.Farming.asmdef.
   - Kết nối với RiceBasketController & InventoryController (thuộc Assembly-CSharp) thông qua Reflection / Type Lookup an toàn, không tạo hard-dependency.
2. **Không Sửa File Đồng Đội**:
   - Assets/MyFolder/Scripts/ và Assets/Scripts/BuffaloRider.cs giữ nguyên 100%.

---

## 🔗 Lịch Sử Git Commits (Nhánh VR)

| Commit | Mô Tả |
|--------|-------|
| 5c2afc99 | test: add unit tests for weather, rain decay, shelter protection, and basket receiver (14/14 passed) |
| ddbc647 | feat: connect RiceThresher output with RiceBasket and Inventory |
| 8fd1be14 | feat: add weather system and rain decay mechanics with shelter zones |
| 6999ee4 | feat: generate complete prefabs for SluiceGate, DryingYard, and Thresher |
| 048d827 | docs: add Khoa farming system context & status report for future sessions |
| 157b999b | fix: update FarmingSetupEditor with prefab generators, fix cross-assembly, update Plot_Prefab with Soil material |
