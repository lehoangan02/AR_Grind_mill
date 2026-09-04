using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Nhà máy tạo hiệu ứng hạt (Particle Systems) tự động cho hệ thống Nông Nghiệp.
    /// Tạo ra các hiệu ứng: Nước chảy, Hơi nước phơi lúa, Hạt thóc bắn ra khi tuốt, Bụi bùn khi trâu bừa, Lấp lánh khi mót lúa.
    /// Hoàn toàn sử dụng Unity modern ParticleSystem API (không deprecated).
    /// </summary>
    public static class FarmingParticleFactory
    {
        public static ParticleSystem CreateWaterFlowFX(Transform parent)
        {
            GameObject go = new GameObject("WaterFlow_ParticleFX");
            if (parent != null) go.transform.SetParent(parent, false);

            ParticleSystem ps = go.AddComponent<ParticleSystem>();
            var main = ps.main;
            main.startLifetime = 0.8f;
            main.startSpeed = 2.5f;
            main.startSize = 0.08f;
            main.startColor = new Color(0.3f, 0.65f, 0.95f, 0.7f);
            main.simulationSpace = ParticleSystemSimulationSpace.World;
            main.maxParticles = 80;
            main.playOnAwake = false;

            var emission = ps.emission;
            emission.rateOverTime = 25f;

            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Cone;
            shape.angle = 15f;
            shape.radius = 0.1f;

            return ps;
        }

        public static ParticleSystem CreateSteamFX(Transform parent)
        {
            GameObject go = new GameObject("Steam_ParticleFX");
            if (parent != null) go.transform.SetParent(parent, false);

            ParticleSystem ps = go.AddComponent<ParticleSystem>();
            var main = ps.main;
            main.startLifetime = 2.0f;
            main.startSpeed = 0.4f;
            main.startSize = 0.35f;
            main.startColor = new Color(1f, 1f, 1f, 0.3f);
            main.simulationSpace = ParticleSystemSimulationSpace.World;
            main.maxParticles = 60;
            main.playOnAwake = false;

            var emission = ps.emission;
            emission.rateOverTime = 12f;

            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Box;
            shape.scale = new Vector3(4f, 0.1f, 4f);

            return ps;
        }

        public static ParticleSystem CreateGrainBurstFX(Transform parent)
        {
            GameObject go = new GameObject("GrainBurst_ParticleFX");
            if (parent != null) go.transform.SetParent(parent, false);

            ParticleSystem ps = go.AddComponent<ParticleSystem>();
            var main = ps.main;
            main.startLifetime = 1.0f;
            main.startSpeed = 3.0f;
            main.startSize = 0.05f;
            main.startColor = new Color(0.95f, 0.8f, 0.2f, 1.0f); // Vàng hạt thóc
            main.gravityModifier = 1.2f;
            main.simulationSpace = ParticleSystemSimulationSpace.World;
            main.maxParticles = 100;
            main.playOnAwake = false;

            var emission = ps.emission;
            emission.rateOverTime = 40f;

            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Cone;
            shape.angle = 35f;
            shape.radius = 0.15f;

            return ps;
        }

        public static ParticleSystem CreateMudDustFX(Transform parent)
        {
            GameObject go = new GameObject("MudDust_ParticleFX");
            if (parent != null) go.transform.SetParent(parent, false);

            ParticleSystem ps = go.AddComponent<ParticleSystem>();
            var main = ps.main;
            main.startLifetime = 0.7f;
            main.startSpeed = 1.2f;
            main.startSize = 0.12f;
            main.startColor = new Color(0.35f, 0.22f, 0.12f, 0.6f); // Nâu bùn đất
            main.simulationSpace = ParticleSystemSimulationSpace.World;
            main.maxParticles = 40;
            main.playOnAwake = false;

            var emission = ps.emission;
            emission.rateOverTime = 15f;

            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Sphere;
            shape.radius = 0.25f;

            return ps;
        }

        public static ParticleSystem CreateSparkleFX(Transform parent)
        {
            GameObject go = new GameObject("GleanSparkle_ParticleFX");
            if (parent != null) go.transform.SetParent(parent, false);

            ParticleSystem ps = go.AddComponent<ParticleSystem>();
            var main = ps.main;
            main.startLifetime = 0.6f;
            main.startSpeed = 1.5f;
            main.startSize = 0.08f;
            main.startColor = new Color(1.0f, 0.9f, 0.3f, 1.0f); // Vàng óng ánh
            main.simulationSpace = ParticleSystemSimulationSpace.World;
            main.maxParticles = 30;
            main.playOnAwake = false;

            var emission = ps.emission;
            emission.rateOverTime = 0f;
            emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0f, 15) });

            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Sphere;
            shape.radius = 0.1f;

            return ps;
        }
    }
}
