# WORK.md

Suggested implementation order for the empty stub methods in `Assets/_Project/Scripts/` (see `CLAUDE.md`/`ARCHITECTURE.md`). Ordered so each phase only depends on things already implemented in an earlier phase. Skip/defer items marked **(optional)**.

## Phase 0 — Persistence keys (blocks everything that saves/loads)

1. `KeySave.cs` — assign literal string values to `Level`, `Shield`, `Hair`, `OldNumClick`, `Gold`, `Gem`, `HighScore` (currently `null`). Every `PlayerPrefs` call elsewhere depends on these.
2. `AutoDestroyG.Start` / `AutoDestroyG.DestroyG` — trivial timed self-destroy coroutine; VFX prefabs (`EFDamage`, `EFBossDie`) likely need this working early.

## Phase 1 — Singletons + boot load

3. `GameControl.Instance` (fix the getter to return the backing field) and `GameControl.Awake` (assign the backing field to `this`).
4. `PlayerControl.Instance` + `PlayerControl.Awake` (same pattern).
5. `SoundManager.Instance` + `SoundManager.Awake` (same pattern), then `PlayAudio`, `PlayClick`, `PlayHit`, `PlayDie`.
6. `GameControl.GetGold`, `GetGem`, `GetLevel`, `GetOldNumClick`, `GetHideScore`, `GetShield` — load from `PlayerPrefs` using the `KeySave` keys, with sane defaults for first run.
7. `GameControl.Start` — call the loaders above and populate the HUD (`txtGold`, `txtGem`, `txtLevel`, `txtHighScore`) with loaded values.

## Phase 2 — Currency + tap-level feedback loop

8. `GameControl.BonuesGold` / `BonuesGem` — add to `Gold`/`Gem`, refresh `txtGold`/`txtGem`, persist via `PlayerPrefs`.
9. `GameControl.GetNumClick` / `ChangeNumClick` / `SetRateClick` — click counter and per-click reward scaling.
10. `GameControl.NextLevel` — level up, recompute `CriticalRate`/`CriticalDamage`, refresh `txtLevel`.

## Phase 3 — Tap-to-attack core loop

11. `GameControl.OnMouseDown2` — tap input entry point; call `PlayerControl.SetAnim`, `ChangeNumClick`, `AddBullet`.
12. `PlayerControl.SetAnim`.
13. `BulletControl.Start` / `OnEnable` / `Update` / `MoveRight` / `AutoDestroy` / `SetValues`.
14. `GameControl.AddBullet` — spawn `Bullet`, configure via `BulletControl.SetValues` using current damage/crit stats.
15. `txtDamageControl.SetInfor` / `AddForce` / `AutoDestroy`, then `GameControl.AddtxtDamage`.
16. `GameControl.AddEFDamage` (depends on Phase 0 item 2).

## Phase 4 — Enemies and bosses

17. `Enemy.Start` / `Update` / `RandomSprite` / `MoveLeft` — spawn-time visuals and idle/move behavior.
18. `Enemy.SetValues` / `OnTriggerEnter2D` / `OneHit` / `SetHealthBar` / `CheckDie` — hit-and-death loop; `CheckDie` should call back into `GameControl.BonuesGold`/`BonuesScore`.
19. `GameControl.AddEnemy` — spawn `PrefabEnemy`, call `Enemy.SetValues`; wire spawn cadence into `GameControl.Update` via `timeAddEnemy`.
20. `BossTraining.Start` / `Update` / `OnTriggerEnter2D` / `OneHit` / `SetAnim` / `SetHealthBar` / `CheckDie` / `RandomSprite` — mirror Enemy, using `imHealth` for the boss health bar.
21. `GameControl.AddNewBoss` — spawn `BossTraining`, gate with `isTraining`/`BossTraining.isAddnewBoss` so only one boss exists at a time.

## Phase 5 — Shop (weapons + shield)

22. `ItemControl.SetInfor` / `ClickItem`.
23. `GameControl.ClearAllChildren`.
24. `GameControl.AddItemWeaponds` / `AddItemShield` — populate `ParentWeaponds`/`ParentShield` with `Item` instances from `ListSpriteWeapons`/`ListSpriteShield`.
25. `GameControl.ClickbtWeaponds` / `ClickbtShield` / `CloseItem` — panel open/close.
26. `GameControl.NextShield` / `BuyItemShield` — spend gold, advance shield tier, persist, refresh `PlayerControl.SetShield`.
27. `PlayerControl.SetWeaponds` / `GetWeaponds` / `SetShield` / `GetShield`, then `PlayerControl.Start` calling both `Get*` methods to restore equipped visuals on boot.

## Phase 6 — Hero summons

28. `HeroKameControl.Start` / `Update` / `AddBullet` / `SetAnim` / `AutoHide` / `AutoDestroy`.
29. `HeroMagicControl` — same six methods, mirrored.
30. `GameControl.AddHeroesKame` / `AddHeroesMagic` / `ShowbtKame` / `ShowbtMagic` — unlock buttons appearing after a delay, then spawning the hero.
31. `GameControl.AddHeroesIron` — note: no `HeroIronControl` script exists yet; this phase item needs a new hero-control script authored first, or should be treated as out of scope until one is added.

## Phase 7 — Endless mode + game over

32. `GameControl.StartEndless` — reset `Score`/`startHealth`, switch `isTraining` off, start enemy-walk spawn loop.
33. `GameControl.OnTriggerEnter2D` (player-side) — enemy reaching the player reduces `startHealth`.
34. `GameControl.BonuesScore` — update `Score`/`txtScore`, persist `txtHighScore`/`KeySave.HighScore` if beaten.
35. `GameControl.EndGame` / `ClickCloseEndGame` — show `panelEndGame` + `txtPopUpScore`, then close/reset back to training mode.

## Phase 8 — Ads (do last; needs real store/app IDs configured)

36. `AdsManager.SettupInfor` / `InitUnity` / `CreateAdRequest`.
37. `RequestInterstitial` / `ShowInterstital` / `ShowAdmobInterstitial` / `Interstitial_OnAdOpening` / `Interstitial_OnAdClosed`.
38. `RequestRewardBasedVideo` / `ShowRewardAdmob` / `HandleRewardBasedVideoRewarded`.
39. `RequestBanner` / `ShowBaner`.
40. `ShowUnityAdsReward` / `ShowUnityAds5s` / `ShowRewardVideoUnity` / `ShowVIdeoADSunity` / `CheckLoadRewardUNITY`.
41. `AdsManager.BonuesVideosADS` / `Delaytime` / public dispatch (`ShowRewardVideo`, `ShowFull`) — branch on `yourTypeADS`, then grant the reward via `GameControl.BonuesGold`/`BonuesGem`/`GetShield` on completion.

## Phase 9 — Optional / defer unless specifically requested

- `Cmh` (screenshot/frame-capture utility — unrelated to gameplay).
- `UICanvasManager`, `PEButtonScript`, `ButtonTypes`, `ParticleEffectsLibrary`, `ETFXSceneManager`, `ETFXProjectileScript`, `PEDestoryTimed` — EpicToonFX demo-scene UI, not referenced by `GameControl` or `Main.unity`'s actual game loop.
