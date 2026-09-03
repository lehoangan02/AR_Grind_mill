using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Khoa.Farming;

namespace Khoa.Farming.Tests
{
    [TestFixture]
    public class BarnManureAndCompostTests
    {
        private GameObject testRoot;

        [SetUp]
        public void SetUp()
        {
            testRoot = new GameObject("BarnCompost_TestRoot");
            CleanupOrphanedTestObjects();
        }

        [TearDown]
        public void TearDown()
        {
            if (testRoot != null)
            {
                Object.DestroyImmediate(testRoot);
            }
            CleanupOrphanedTestObjects();
        }

        private void CleanupOrphanedTestObjects()
        {
            foreach (var item in Object.FindObjectsByType<MatureFertilizerItem>(FindObjectsSortMode.None))
            {
                if (item != null) Object.DestroyImmediate(item.gameObject);
            }
            foreach (var item in Object.FindObjectsByType<ManureItem>(FindObjectsSortMode.None))
            {
                if (item != null) Object.DestroyImmediate(item.gameObject);
            }
        }

        [Test]
        public void Test_BarnManureSource_SpawnsInitialPile_AndRespectsMaxCapacity()
        {
            GameObject barnGO = new GameObject("Barn_Source");
            barnGO.transform.SetParent(testRoot.transform);
            BarnManureSource source = barnGO.AddComponent<BarnManureSource>();
            source.animalType = BarnAnimalType.Cow;
            source.maxUncollected = 2;

            Assert.AreEqual(0, source.ActivePileCount);

            // Sinh đống thứ 1
            ManureItem pile1 = source.SpawnManure();
            Assert.IsNotNull(pile1);
            Assert.AreEqual(1, source.ActivePileCount);
            Assert.AreEqual(BarnAnimalType.Cow, pile1.sourceAnimal);

            // Sinh đống thứ 2
            ManureItem pile2 = source.SpawnManure();
            Assert.IsNotNull(pile2);
            Assert.AreEqual(2, source.ActivePileCount);

            // Sinh đống thứ 3 -> Quá dung lượng max 2 đống -> Phải trả về null
            ManureItem pile3 = source.SpawnManure();
            Assert.IsNull(pile3);
            Assert.AreEqual(2, source.ActivePileCount);
        }

        [Test]
        public void Test_ManureItem_TryScoop_AtomicTransaction_PreventsDuplicate()
        {
            GameObject pileGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pileGO.transform.SetParent(testRoot.transform);
            ManureItem item = pileGO.AddComponent<ManureItem>();

            Assert.IsFalse(item.IsScooped);

            // Xúc lần đầu -> Thành công
            bool firstScoop = item.TryScoop(out float amount1);
            Assert.IsTrue(firstScoop);
            Assert.AreEqual(1f, amount1);
            Assert.IsTrue(item.IsScooped);

            // Xúc lần thứ 2 (giả lập collider thứ 2 va chạm cùng lúc) -> Thất bại
            bool secondScoop = item.TryScoop(out float amount2);
            Assert.IsFalse(secondScoop);
            Assert.AreEqual(0f, amount2);
        }

        [Test]
        public void Test_ManureShovel_ScoopAndDepositFlow()
        {
            // Tạo xẻng
            GameObject shovelGO = new GameObject("Shovel");
            shovelGO.transform.SetParent(testRoot.transform);
            shovelGO.AddComponent<Rigidbody>();
            shovelGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            ManureShovel shovel = shovelGO.AddComponent<ManureShovel>();

            // Tạo đống phân tươi
            GameObject manureGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            manureGO.transform.SetParent(testRoot.transform);
            ManureItem manure = manureGO.AddComponent<ManureItem>();

            // Tạo đống ủ
            GameObject compostGO = new GameObject("Compost");
            compostGO.transform.SetParent(testRoot.transform);
            CompostPile compost = compostGO.AddComponent<CompostPile>();
            compost.requiredPortions = 3;

            Assert.IsFalse(shovel.IsFull);
            Assert.AreEqual(CompostState.Empty, compost.CurrentState);

            // Xúc phân vào xẻng
            bool scoopSuccess = shovel.ScoopFrom(manure);
            Assert.IsTrue(scoopSuccess);
            Assert.IsTrue(shovel.IsFull);
            Assert.IsTrue(manure.IsScooped);

            // Không thể xúc thêm khi xẻng đã đầy
            GameObject manure2GO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            manure2GO.transform.SetParent(testRoot.transform);
            ManureItem manure2 = manure2GO.AddComponent<ManureItem>();
            bool scoopAgain = shovel.ScoopFrom(manure2);
            Assert.IsFalse(scoopAgain);

            // Đổ phân từ xẻng vào đống ủ
            bool depositSuccess = shovel.DepositTo(compost);
            Assert.IsTrue(depositSuccess);
            Assert.IsFalse(shovel.IsFull);
            Assert.AreEqual(1, compost.CurrentPortions);
            Assert.AreEqual(CompostState.Filling, compost.CurrentState);
        }

        [Test]
        public void Test_CompostPile_RequiresThreePortions_AndTransitionsToComposting()
        {
            GameObject compostGO = new GameObject("Compost");
            compostGO.transform.SetParent(testRoot.transform);
            CompostPile compost = compostGO.AddComponent<CompostPile>();
            compost.requiredPortions = 3;
            compost.compostDuration = 90f;

            GameObject shovelGO = new GameObject("Shovel");
            shovelGO.transform.SetParent(testRoot.transform);
            shovelGO.AddComponent<Rigidbody>();
            shovelGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            ManureShovel shovel = shovelGO.AddComponent<ManureShovel>();

            // Phần 1
            shovel.SetFull(true);
            Assert.IsTrue(compost.TryDepositManure(shovel));
            Assert.AreEqual(CompostState.Filling, compost.CurrentState);
            Assert.AreEqual(1, compost.CurrentPortions);

            // Phần 2
            shovel.SetFull(true);
            Assert.IsTrue(compost.TryDepositManure(shovel));
            Assert.AreEqual(CompostState.Filling, compost.CurrentState);
            Assert.AreEqual(2, compost.CurrentPortions);

            // Phần 3 -> Chuyển sang Composting
            shovel.SetFull(true);
            Assert.IsTrue(compost.TryDepositManure(shovel));
            Assert.AreEqual(CompostState.Composting, compost.CurrentState);
            Assert.AreEqual(3, compost.CurrentPortions);
            Assert.AreEqual(90f, compost.CompostTimer);

            // Không cho nạp thêm khi đang Composting
            shovel.SetFull(true);
            Assert.IsFalse(compost.TryDepositManure(shovel));
        }

        [Test]
        public void Test_CompostPile_CompleteComposting_SpawnsThreeMatureFertilizers()
        {
            GameObject compostGO = new GameObject("Compost");
            compostGO.transform.SetParent(testRoot.transform);
            CompostPile compost = compostGO.AddComponent<CompostPile>();
            compost.requiredPortions = 3;
            compost.compostDuration = 90f;

            // Nạp đủ 3 phần
            GameObject shovelGO = new GameObject("Shovel");
            shovelGO.transform.SetParent(testRoot.transform);
            shovelGO.AddComponent<Rigidbody>();
            shovelGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            ManureShovel shovel = shovelGO.AddComponent<ManureShovel>();

            for (int i = 0; i < 3; i++)
            {
                shovel.SetFull(true);
                compost.TryDepositManure(shovel);
            }

            Assert.AreEqual(CompostState.Composting, compost.CurrentState);

            // Hoàn tất ủ
            compost.CompleteComposting();
            Assert.AreEqual(CompostState.Ready, compost.CurrentState);

            // Kiểm tra số lượng phân hoai tạo ra
            MatureFertilizerItem[] outputs = Object.FindObjectsByType<MatureFertilizerItem>(FindObjectsSortMode.None);
            Assert.AreEqual(3, outputs.Length);
        }

        [Test]
        public void Test_CropPlot_TryApplyFertilizer_Tilled_AndGrowthMultiplier()
        {
            GameObject plotGO = new GameObject("Test_CropPlot");
            plotGO.transform.SetParent(testRoot.transform);
            CropPlot plot = plotGO.AddComponent<CropPlot>();
            plot.PlowPlot();

            Assert.AreEqual(PlotState.Tilled, plot.currentState);
            Assert.IsFalse(plot.hasFertilizerApplied);

            // Tạo phân hoai mục
            GameObject fertGO = new GameObject("Fertilizer_Item");
            fertGO.transform.SetParent(testRoot.transform);
            fertGO.AddComponent<Rigidbody>();
            fertGO.AddComponent<BoxCollider>();
            MatureFertilizerItem fertItem = fertGO.AddComponent<MatureFertilizerItem>();

            // Bón vào ruộng đã cày -> Thành công
            bool applied = fertItem.TryApplyTo(plot);
            Assert.IsTrue(applied);
            Assert.IsTrue(plot.hasFertilizerApplied);
            Assert.IsTrue(fertItem.IsConsumed);

            // Bón lần thứ 2 vào cùng 1 ô -> Không stack, trả về false
            GameObject fert2GO = new GameObject("Fertilizer_Item_2");
            fert2GO.transform.SetParent(testRoot.transform);
            fert2GO.AddComponent<Rigidbody>();
            fert2GO.AddComponent<BoxCollider>();
            MatureFertilizerItem fertItem2 = fert2GO.AddComponent<MatureFertilizerItem>();

            bool appliedAgain = fertItem2.TryApplyTo(plot);
            Assert.IsFalse(appliedAgain);
            Assert.IsFalse(fertItem2.IsConsumed);
        }

        [Test]
        public void Test_MatureFertilizerItem_AppliedDirectlyToRicePlant_ConsumesItemAndFertilizesPlant()
        {
            GameObject plotGO = new GameObject("Test_CropPlot_Occupied");
            plotGO.transform.SetParent(testRoot.transform);
            CropPlot plot = plotGO.AddComponent<CropPlot>();
            plot.currentState = PlotState.Occupied;

            // Tạo cây lúa
            GameObject riceGO = new GameObject("Test_RicePlant");
            riceGO.transform.SetParent(testRoot.transform);
            BoxCollider riceCol = riceGO.AddComponent<BoxCollider>();
            riceCol.isTrigger = true;
            RicePlant plant = riceGO.AddComponent<RicePlant>();
            plant.Initialize(plot);
            typeof(CropPlot).GetField("currentCrop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(plot, plant);

            Assert.IsFalse(plant.hasFertilizer);

            // Tạo phân hoai mục
            GameObject fertGO = new GameObject("MatureFertilizer");
            fertGO.transform.SetParent(testRoot.transform);
            fertGO.AddComponent<Rigidbody>();
            BoxCollider fertCol = fertGO.AddComponent<BoxCollider>();
            fertCol.isTrigger = true;
            MatureFertilizerItem fertItem = fertGO.AddComponent<MatureFertilizerItem>();

            // Giả lập va chạm trực tiếp giữa bao phân và thân cây lúa
            System.Reflection.MethodInfo handleCollision = typeof(MatureFertilizerItem).GetMethod("HandleCollision",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.IsNotNull(handleCollision);
            handleCollision.Invoke(fertItem, new object[] { riceCol });

            // Xác nhận cây lúa được bón phân VÀ bao phân đã bị tiêu thụ
            Assert.IsTrue(plant.hasFertilizer, "Cây lúa phải được bật cờ bón phân!");
            Assert.IsTrue(fertItem.IsConsumed, "Bao phân phải bị tiêu thụ sau khi bón vào cây lúa!");
        }

        [Test]
        public void Test_CompostPile_ResetsToEmpty_WhenAllOutputsCleared_AllowsNewBatch()
        {
            GameObject compostGO = new GameObject("Test_CompostPile");
            compostGO.transform.SetParent(testRoot.transform);
            CompostPile compost = compostGO.AddComponent<CompostPile>();
            compost.requiredPortions = 3;
            compost.compostDuration = 90f;

            GameObject shovelGO = new GameObject("Shovel");
            shovelGO.transform.SetParent(testRoot.transform);
            shovelGO.AddComponent<Rigidbody>();
            shovelGO.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            ManureShovel shovel = shovelGO.AddComponent<ManureShovel>();

            // Nạp đủ 3 phần phân để chuyển sang Composting
            for (int i = 0; i < 3; i++)
            {
                shovel.SetFull(true);
                compost.TryDepositManure(shovel);
            }
            Assert.AreEqual(CompostState.Composting, compost.CurrentState);

            // Hoàn thành ủ -> Ready
            compost.CompleteComposting();
            Assert.AreEqual(CompostState.Ready, compost.CurrentState);

            // Tìm và dọn sạch các bao phân vừa sinh ra
            MatureFertilizerItem[] outputs = Object.FindObjectsByType<MatureFertilizerItem>(FindObjectsSortMode.None);
            Assert.AreEqual(3, outputs.Length);
            for (int i = 0; i < outputs.Length; i++)
            {
                Object.DestroyImmediate(outputs[i].gameObject);
            }

            // Gọi kiểm tra dọn sạch
            compost.CheckAndResetIfOutputsCleared();

            // Xác nhận đống ủ đã quay về Empty và sẵn sàng nhận phân mới
            Assert.AreEqual(CompostState.Empty, compost.CurrentState);
            Assert.AreEqual(0, compost.CurrentPortions);

            // Thử nạp mẻ phân mới
            shovel.SetFull(true);
            bool depositNewBatch = compost.TryDepositManure(shovel);
            Assert.IsTrue(depositNewBatch, "Đống ủ sau khi reset phải nhận phân cho mẻ mới!");
            Assert.AreEqual(1, compost.CurrentPortions);
            Assert.AreEqual(CompostState.Filling, compost.CurrentState);
        }
    }
}
