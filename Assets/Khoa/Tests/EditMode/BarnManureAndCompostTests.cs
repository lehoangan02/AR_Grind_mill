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
        }

        [TearDown]
        public void TearDown()
        {
            if (testRoot != null)
            {
                Object.DestroyImmediate(testRoot);
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
    }
}
