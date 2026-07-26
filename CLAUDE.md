# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

Unity 2D idle/clicker RPG project ("Unity_Base_2D"). Engine version **6000.3.20f1** (Unity 6) — open with that exact editor version. Render pipeline: URP 17.3.0. Single scene: `Assets/_Project/Scenes/Main.unity`.

There is no CLI build/test pipeline (no package.json, Makefile, or CI config). All building, running, and iteration happens inside the Unity Editor. `com.unity.test-framework` is present in `Packages/manifest.json` but there are no test assemblies or test files in the project yet.

## Critical fact about this codebase

**Every script under `Assets/_Project/Scripts/` (the 24 files directly in that folder, not its subfolders) is a decompiled skeleton, not working game code.** Class names, fields, method signatures, and enums are intact, but almost every method body is empty (`{}`), and every getter/property returns a hardcoded default (`return null;`, `return false;`, `return 0`). This includes things that look like they should be real, e.g. `GameControl.Instance` and `PlayerControl.Instance` currently just `return null;` — do not assume any singleton, save system, or gameplay loop currently functions.

This means:
- Reading a script tells you the *intended shape* of a system (its public API, fields, Inspector-exposed references) but not its behavior.
- Implementing a feature almost always means filling in method bodies to match what the field/method names imply, using neighboring scripts and prefab/scene wiring (Inspector references) as the source of truth for intent.
- Don't "fix" empty methods you weren't asked to touch — treat the emptiness as the current baseline, not a bug, unless the task is specifically to implement game logic.
- See `ARCHITECTURE.md` for what each stub script is supposed to do, and `WORK.md` for a suggested implementation order.

## Vendor code — do not treat as stubs to fill in

Two subfolders under `Assets/_Project/Scripts/` are third-party SDKs bundled with the project, not part of the decompiled game logic:
- `EpicToonFX/` — Epic Toon FX asset-store VFX demo helper scripts (rotation, orbit camera, light fade, etc.).
- `GoogleMobileAds/` — the Google Mobile Ads (AdMob) Unity plugin (client interfaces, platform adapters).

Scripts directly in `Assets/_Project/Scripts/` such as `ParticleEffectsLibrary.cs`, `ETFXSceneManager.cs`, `ETFXProjectileScript.cs`, `PEButtonScript.cs`, `PEDestoryTimed.cs` are also EpicToonFX demo-scene scripts (they ended up alongside the game scripts rather than in the `EpicToonFX/` subfolder), but unlike the vendor subfolders, **these ones are also stubbed out** — treat them the same as the rest of the game scripts.

## Directory layout

- `Assets/_Project/Scripts/` — all first-party game code (stubs, see above) plus the two vendor subfolders.
- `Assets/_Project/Scenes/Main.unity` — the only scene.
- `Assets/_Project/PrefabInstance/` — gameplay prefabs (`Enemy`, `BossTraining`, `Bullet`, `BulletMagic`, `HeroKame`, `HeroesMagic`, `Item`, `txtDamage`, VFX prefabs). Prefab component wiring is often the best evidence for what a stub method should do.
- `Assets/_Project/{Sprite,Material,AnimatorController,AnimationClip,AudioClip,Font,Texture2D,ComputeShader,LightingDataAsset}` — standard per-type asset folders.
- `Assets/TextMesh Pro/` — TMP package assets.

## Domain model (for quick orientation)

This is a tap-to-attack idle RPG: a player character auto-attacks or is tapped to attack, enemies (and periodic bosses) take damage and die, gold/gems drop, currency buys weapon/shield upgrades and unlocks hero forms, and rewarded/interstitial ads (AdMob + legacy Unity Ads) gate bonuses. See `ARCHITECTURE.md` for the full system breakdown.
