# AR Grind Mill — GitHub Copilot Instructions

## Project Context
This is a **Unity AR / VR** project themed around Western Vietnam rural life (Đồng bằng sông Cửu Long / Miền Tây sông nước).
- **Core Mechanics**: Rice farming (bừa đất, cấy lúa, mở van nước kênh rạch, bón phân, gặt lúa, phơi lúa, tuốt lúa), VR rowing/boating (chèo thuyền), fishing (câu cá lóc), cooking rice (vo gạo nấu cơm), and companion NPC guides.
- **Tech Stack**:
  - Unity 6 / Unity LTS
  - Universal Render Pipeline (URP) & Shader Graph
  - Unity XR Interaction Toolkit (Hands tracking & VR controllers)
  - AR Foundation (ARCore Android / ARKit iOS) & OpenXR (Meta Quest VR)
  - Unity Input System (New Input System)
  - Modern C# architecture (State machines, Object pooling, Event-driven)

## Agent Skills Reference
When generating code, designing systems, or debugging for this project, always follow the best practices specified in the local skills located under .github/skills/ (and .agents/skills/):

1. **Unity C# & Architecture (.github/skills/unity-developer/SKILL.md)**:
   - Zero-allocation per frame in Update(): Avoid Instantiate/Destroy, LINQ, and string concatenation in hot paths.
   - Use Object Pooling for recurring objects (rice grains, fish, particles, water splashes).
   - Use State Machines for Quest & Game Loops.
   - Use URP Shader Graph and optimized shaders for water and terrain.

2. **VR/AR & XR Interaction (.github/skills/game-development-vr-ar/SKILL.md)**:
   - Follow VR Comfort Principles (anti-motion sickness for boating and locomotion).
   - Maintain Strict Frame Budget (90 FPS on Meta Quest / 60 FPS on mobile AR).
   - Support both Direct Hand Tracking and Controller Interactors via XR Interaction Toolkit.

3. **Spatial 3D UI (.github/skills/design-spatial/SKILL.md)**:
   - Implement World-Space Canvas and Bubble/Diegetic UI (e.g. Pause Bubble, 3D interaction triggers).

4. **Game Design & Gameplay Loops (.github/skills/game-development-game-design/SKILL.md)**:
   - Follow clear task flows and trigger-based NPC interactions (Ông Sáu, Bà Tư, đứa nhỏ nhắc việc).

5. **Audio & 3D Spatial Sound (.github/skills/game-development-game-audio/SKILL.md)**:
   - Implement 3D spatial audio for ambient nature, water canals, animals, and gameplay SFX.

6. **Systematic Debugging & Performance (.github/skills/systematic-debugging/SKILL.md)**:
   - Provide evidence-based debugging, root-cause tracing for Unity/Mono crashes, and profile CPU/GPU bottlenecks.
