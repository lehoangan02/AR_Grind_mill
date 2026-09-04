using Khoa.Farming.Mounting;
using Khoa.Farming.Boating;
using NUnit.Framework;
using UnityEngine;

namespace Khoa.Farming.Tests
{
    public class XRMountCoordinatorTests
    {
        [Test]
        public void SameRig_CannotBeClaimedByBoatAndBuffaloAtOnce()
        {
            GameObject rig = new GameObject("Test XR Rig");
            GameObject boat = new GameObject("Boat");
            GameObject buffalo = new GameObject("Buffalo");
            try
            {
                Assert.That(XRMountCoordinator.TryAcquire(rig, boat), Is.True);
                Assert.That(XRMountCoordinator.TryAcquire(rig, buffalo), Is.False);
                XRMountCoordinator.Release(rig, boat);
                Assert.That(XRMountCoordinator.TryAcquire(rig, buffalo), Is.True);
            }
            finally
            {
                XRMountCoordinator.Release(rig, boat);
                XRMountCoordinator.Release(rig, buffalo);
                Object.DestroyImmediate(rig);
                Object.DestroyImmediate(boat);
                Object.DestroyImmediate(buffalo);
            }
        }

        [Test]
        public void WaterVolume_PreservesConfiguredSurface_AndRejectsPointsOutsideRiver()
        {
            GameObject water = new GameObject("Test River Volume");
            try
            {
                water.transform.position = new Vector3(30f, 98.9f, 15f);
                BoxCollider box = water.AddComponent<BoxCollider>();
                box.size = new Vector3(120f, 6f, 80f);
                box.center = new Vector3(0f, -3f, 0f);
                WaterSurfaceVolume volume = water.AddComponent<WaterSurfaceVolume>();

                Assert.That(volume.waterSurfaceY, Is.EqualTo(98.9f).Within(0.001f));
                Assert.That(volume.IsPointSubmerged(new Vector3(-14.5f, 98.5f, 12.5f), out _), Is.True);
                Assert.That(volume.IsPointSubmerged(new Vector3(-40f, 98.5f, 12.5f), out _), Is.False);
            }
            finally
            {
                Object.DestroyImmediate(water);
            }
        }
    }
}
