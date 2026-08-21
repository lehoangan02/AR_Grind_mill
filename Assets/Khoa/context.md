# 📋 Khoa Farming System — Context & Status Report
> **Cập nhật lần cuối:** 2026-08-21 17:43 (GMT+7)  
> **Branch:** VR → origin/VR  
> **Commit mới nhất:** d3c7c89  
> **Author:** Chris-KH <klowgamervn@gmail.com>

---

## 🗂️ Cấu Trúc Thư Mục Assets/Khoa/

`
Assets/Khoa/
├── Prefabs/
│   ├── Plot_Prefab.prefab                ← Ô đất ruộng (PBR Soil + WaterSurface con + Glean Stalk Spawn)
│   ├── Rice_Prefab.prefab                ← Cây lúa mẫu (Mesh 3D RicePlant.obj)
│   ├── Rice_Bundle_Prefab.prefab         ← Bó lúa sau gặt (XRGrabInteractable)
│   ├── Gleaned_Rice_Stalk_Prefab.prefab  ← Bông lúa mót rơi vãi trên ruộng (XRGrabInteractable)
│   ├── Sluice_Gate_Prefab.prefab         ← Van nước kênh mương (XR Interactable)
│   ├── Rice_Drying_Yard_Prefab.prefab    ← Sân phơi lúa gạch PBR
│   └── Rice_Thresher_Prefab.prefab       ← Cối tuốt lúa (kèm RiceThresherBasketReceiver)
├── ScriptableObjects/
│   └── Rice_Data.asset                   ← CropData config cho lúa
├── Scripts/
│   ├── Farming/                          ← Namespace: Khoa.Farming
│   │   ├── CropData.cs                   ← ScriptableObject thông số cây trồng
│   │   ├── CropPlot.cs                   ← Ô đất ruộng (Empty → Tilled → Occupied, sinh bông lúa mót khi gặt)
│   │   ├── RicePlant.cs                  ← Cây lúa (5 giai đoạn tăng trưởng)
│   │   ├── RiceBundleItem.cs             ← Bó lúa vật lý (XR Grab, phơi khô, che mưa)
│   │   ├── GleanedRiceStalk.cs           ← Bông lúa mót (cúi nhặt trong VR, gom 3 bông ghép thành Bó Lúa)
│   │   ├── SluiceGate.cs                 ← Van nước kênh mương (tưới đồng loạt)
│   │   ├── BuffaloPlowAttachment.cs      ← Lưỡi bừa gắn trâu (tự xới đất)
│   │   ├── RiceDryingYard.cs             ← Sân phơi lúa (phơi nắng + cơ chế mưa ướt)
│   │   ├── RiceThresher.cs               ← Cối tuốt lúa (tách hạt thóc + rơm rạ)
│   │   ├── FarmingWeatherSystem.cs       ← Quản lý thời tiết Nắng / Mưa / Âm u
│   │   ├── RiceShelterZone.cs            ← Khu vực có mái che bảo vệ lúa khi mưa
│   │   ├── RiceThresherBasketReceiver.cs ← Nạp thóc vào Giỏ lúa (RiceBasket) & Túi đồ (Inventory)
│   │   ├── FarmingParticleFactory.cs     ← Factory tạo Particle Systems (Nước chảy, Hơi nước, Bụi bùn, Lúa vàng)
│   │   └── FarmingAudioFXHelper.cs       ← Helper phát 3D Spatial Audio chuẩn VR
│   └── Editor/                           ← Namespace: Khoa.Farming.Editor (Editor tools)
│       ├── FarmingSetupEditor.cs          ← Menu tạo đầy đủ 7 Prefabs
│       ├── FarmingTestKitCreator.cs       ← Menu tạo bộ đồ nghề test VR
│       └── PlotGridGenerator.cs           ← Menu tạo lưới ô ruộng tự động theo Terrain
├── Tests/EditMode/
│   ├── FarmingLogicTests.cs               ← 5 test cases cơ bản
│   └── FarmingExtendedTests.cs            ← 12 test cases mở rộng (Weather, Shelter, Thresher, Gleaning, Particle Factory)
├── README.md                             ← Cẩm nang hướng dẫn sử dụng cho các bạn trong nhóm
└── context.md                             ← (File này - lưu context kỹ thuật chi tiết)
`

---

## ✅ Những Gì ĐÃ LÀM ĐƯỢC

### 1. Hệ Thống Trồng & Gặt Lúa Hoàn Chỉnh
- **CropPlot**: Ô đất 3 trạng thái (Empty → Tilled → Occupied), nhận va chạm nông cụ VR.
- **RicePlant**: Cây lúa 5 giai đoạn (Seedling → Growing → Maturing → ReadyToHarvest → Dead), bón phân tăng tốc, héo khi cạn nước.
- **RiceBundleItem**: Bó lúa VR cầm nắm được, có drynessProgress, isDry, isSheltered.

### 2. Cơ Chế Mót Lúa (Rice Gleaning System - Mới)
- **GleanedRiceStalk.cs**: Bông lúa rơi vãi trên ruộng bùn sau khi gặt.
- Người chơi cúi xuống nhặt bằng tay VR (XRGrabInteractable).
- Khi gom đủ 3 bông lúa mót → **Tự động bó lại thành 1 Bó Lúa (RiceBundleItem) hoàn chỉnh trên tay người chơi**!
- Phát hiệu ứng lấp lánh (GleanSparkle_ParticleFX) và âm thanh nhặt lúa.
- Đã tạo sẵn Gleaned_Rice_Stalk_Prefab.prefab.

### 3. Dynamic Soil & Moisture Visuals
- CropPlot đổi màu đất mượt mà Color.Lerp(dryColor, wetColor, currentMoisture).
- Váng nước (waterSurfaceMesh) tự bật khi ruộng ngập nước.
- Prefab đã gán PBR Soil.mat.

### 4. Sluice Gate & Irrigation
- SluiceGate.cs: Cần gạt mở/đóng van nước VR, tưới đồng loạt các ô ruộng kết nối.
- Đã tạo sẵn Sluice_Gate_Prefab.prefab.

### 5. Buffalo Plowing
- BuffaloPlowAttachment.cs: Gắn vào sau trâu, tự xới đất khi đi qua.
- **KHÔNG sửa code BuffaloRider.cs của đồng đội** (0% xung đột).

### 6. Rice Drying Yard & Weather Integration
- RiceDryingYard.cs: Sân phơi tăng độ khô khi trời nắng.
- **Tích hợp thời tiết**: Khi trời mưa (WeatherType.Rainy), sân phơi dừng phơi và làm giảm độ khô lúa nếu không được che chắn.
- Đã tạo sẵn Rice_Drying_Yard_Prefab.prefab.

### 7. Farming Weather System & Shelter Zone
- FarmingWeatherSystem.cs: Quản lý Sunny, Rainy, Overcast, hỗ trợ auto cycle hoặc đổi thủ công, phát event OnWeatherChanged.
- RiceShelterZone.cs: Khu vực có mái che (Hiên nhà, kho lúa), bảo vệ bó lúa khỏi mưa bão.

### 8. Rice Thresher & Giỏ Lúa / Inventory Integration
- RiceThresher.cs: Cối tuốt lúa, từ chối lúa ướt, tuốt lúa khô sinh thóc + rơm rạ.
- RiceThresherBasketReceiver.cs: Tự động tìm RiceBasketController gần cối hoặc trong InventoryController của người chơi để nạp đầy thóc vàng (SetFull(true)).
- Đã tạo sẵn Rice_Thresher_Prefab.prefab.

### 9. Particle Systems & 3D Spatial Audio Helpers (Mới)
- FarmingParticleFactory.cs: Tự động tạo WaterFlowFX, SteamFX, GrainBurstFX, MudDustFX, SparkleFX (sử dụng 100% Unity modern non-deprecated API).
- FarmingAudioFXHelper.cs: Cấu hình và phát 3D Spatial Audio cho trải nghiệm VR sống động.

### 10. Editor Tools
- **Menu Khoa/Farming/Setup Farming Prefabs**: Tạo/cập nhật đầy đủ 7 Prefabs.
- **Menu Khoa/Tạo Bộ Công Cụ Nông Nghiệp (Test)**: Spawn bộ đồ nghề VR test.
- **Menu Khoa/Farming/Generate Plot Grid**: Tạo lưới ô ruộng tự động theo Terrain.

---

## 🧪 Trạng Thái Kiểm Thử

### Unit Tests (EditMode) — 17/17 PASSED (100%) ✅
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
| 15 | Test_GleanedRiceStalk_Collection_CountsAndSpawnsBundle | Nhặt đủ 3 bông lúa mót sinh ra 1 Bó Lúa | ✅ |
| 16 | Test_CropPlot_Harvest_SpawnsGleanStalks | Gặt lúa rơi vãi các bông lúa mót | ✅ |
| 17 | Test_FarmingParticleFactory_CreatesValidParticleSystems | Khởi tạo Particle Systems hợp lệ | ✅ |

### Lệnh chạy test:
`ash
unity test --mode EditMode --output test-results.xml
`

---

## ❌ Những Gì CHƯA LÀM (Cho Các Buổi Tiếp Theo)

### Gameplay Mechanics Còn Lại (Theo now_plan.md)
- [ ] **Thêm Nhà Bếp & Cơ Chế Vo Gạo - Nấu Cơm** *(Task của Khoa - Dòng 29, 59, 103)*:
  - Dựng khu vực bếp bên phải nhà chính.
  - Tương tác: Lấy gạo từ cối xay (GrindMillController) -> Cho vào nồi -> Vo gạo -> Nấu cơm.
- [ ] **Chèo thuyền, câu cá VR** *(Dòng 57, 93-99)*: Chưa bắt đầu.
- [ ] **NPC nhắc nhiệm vụ** *(Dòng 67)*: Chưa bắt đầu.

---

## ⚠️ Lưu Ý Kỹ Thuật & Tương Thích

1. **Chuẩn API Unity 6 / Modern Unity**:
   - Sử dụng FindObjectsByType<T>(FindObjectsSortMode.None).
   - Rigidbody dùng linearVelocity.
   - Particle System dùng main, mission, shape modules chuẩn.
   - Destroy bọc qua Application.isPlaying để an toàn cho cả Runtime và EditMode Tests.
2. **Không Sửa File Đồng Đội**:
   - Assets/MyFolder/Scripts/ và Assets/Scripts/BuffaloRider.cs giữ nguyên 100%.

---

## 🔗 Lịch Sử Git Commits (Nhánh VR)

| Commit | Mô Tả |
|--------|-------|
| d3c7c89 | test: add unit tests for gleaning mechanics, particle factory, and fix editmode destroy in CropPlot (17/17 passed) |
| 733d9069 | feat: update FarmingSetupEditor with gleaning prefab generator and polish prefab references |
| 565101fa | feat: add farming particle factory and audio fx helper for VR interactions |
| da66118e | feat: implement GleanedRiceStalk and crop plot gleaning spawn mechanics |
| f96c125 | docs: add comprehensive user manual and developer integration guide in Assets/Khoa/README.md |
| cdc5aaef | docs: update Khoa context.md with weather system, shelter zones, basket receiver |
| 5c2afc99 | test: add unit tests for weather, rain decay, shelter protection, and basket receiver |
| ddbc647 | feat: connect RiceThresher output with RiceBasket and Inventory |
| 8fd1be14 | feat: add weather system and rain decay mechanics with shelter zones |
| 6999ee4 | feat: generate complete prefabs for SluiceGate, DryingYard, and Thresher |
