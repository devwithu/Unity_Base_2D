# ARCHITECTURE.md

Inferred architecture of `Assets/_Project/Scripts/`, based on reading class/field/method **names and signatures** — the method bodies are empty stubs (see `CLAUDE.md`), so everything below is the *intended* design reconstructed from the API surface, not confirmed running behavior. Cross-check against prefab/scene Inspector wiring before implementing.

## Genre

Tap-to-attack idle RPG with two modes: a "training" mode (tap the target to gain click-levels, buy gear) and an "endless" mode (enemies walk toward the player, survival/score run). Monetized with rewarded/interstitial ads.

## System map

```
GameControl (God object / scene director)
 ├─ drives: tap input → damage number → enemy HP → gold/gem/score
 ├─ owns: currency, level, crit stats, shield stat
 ├─ spawns: PrefabEnemy → Enemy, BossTraining, Bullet → BulletControl,
 │          txtDamage → txtDamageControl, EFDamage/EFBossDie (VFX),
 │          HeroesKame → HeroKameControl, HeroesMagic → HeroMagicControl
 ├─ populates shop panels: Item → ItemControl (weapons / shield tabs)
 └─ reads/writes persistence via KeySave key names (PlayerPrefs, inferred)

PlayerControl        — player sprite/animator, equips weapon+shield sprite tier
Enemy / BossTraining — HP, hit reaction, death → reports to GameControl
BulletControl        — projectile fired by GameControl.AddBullet
HeroKameControl /
HeroMagicControl     — optional "hero helper" summons, each fires its own bullet
ItemControl          — one row in a shop list (weapon or shield tier)
txtDamageControl     — floating damage-number popup
SoundManager         — one-shot SFX player (click/hit/die)
AdsManager           — AdMob + legacy Unity Ads wrapper, grants bonuses on reward
KeySave              — PlayerPrefs key-name constants (values currently unset — see WORK.md)
```

## GameControl (`GameControl.cs`)

Central hub; almost every other script reports back to it or is spawned by it. Holds all mutable game state as public/private fields with no wrapping "model" class — treat `GameControl` itself as the save-game/state object.

**State groups:**
- Currency: `Gold`, `Gem` (+ `txtGold`/`txtGem` HUD text)
- Tap-leveling: `numClick`, `tempNumClick`, `Level`, `CriticalRate`, `CriticalDamage`, `Shield` (+ `txtLevel`, `txtNumClick`, `imgnumClick`)
- Endless mode: `Score`, `startHealth`, `isTraining` (mode switch), `timeAddEnemy` (spawn cadence) (+ `txtScore`, `txtHighScore`, `panelEndGame`, `txtPopUpScore`)
- Shop: `PanelWeaponds`/`ParentWeaponds`, `PanelShield`/`ParentShield`, `btWeaponds`, `btShield`, `btCloseItem`, `ListSpriteWeapons`, `ListSpriteShield`
- Heroes: `HeroesMagic`, `HeroesKame`, `imIron` (Iron hero has a sprite reference but **no `HeroIronControl` script exists** — treat Iron as unimplemented/locked), `btHeroesKame`, `btHeroMagic`, `btHeroesIron`
- Prefab refs: `Player`, `Bullet`, `txtDamage`, `EFDamage`, `EFBossDie`, `BossTraining`, `Item`, `PrefabEnemy`, `ListSpriteBullets`

**Method groups (by inferred responsibility):**
| Group | Methods |
|---|---|
| Lifecycle | `Awake`, `Start`, `Update` |
| Persistence load | `GetGold`, `GetGem`, `GetLevel`, `GetOldNumClick`, `GetHideScore`, `GetShield` |
| Currency mutation | `BonuesGold`, `BonuesGem` |
| Tap-level loop | `GetNumClick`, `ChangeNumClick`, `SetRateClick`, `NextLevel`, `OnMouseDown2` |
| Combat spawn/feedback | `AddBullet`, `AddtxtDamage`, `AddEFDamage`, `AddEnemy`, `AddNewBoss` |
| Shop (weapons) | `AddItemWeaponds`, `ClickbtWeaponds` |
| Shop (shield) | `AddItemShield`, `ClickbtShield`, `NextShield`, `BuyItemShield` |
| Shop (shared) | `ClearAllChildren`, `CloseItem` |
| Heroes | `AddHeroesMagic`, `AddHeroesKame`, `AddHeroesIron`, `ShowbtMagic`, `ShowbtKame` |
| Endless mode | `StartEndless`, `BonuesScore`, `OnTriggerEnter2D`, `EndGame`, `ClickCloseEndGame` |

## Combat actors

- **`PlayerControl`** — holds `Anim`, `SpriteWeaponds`, `SpriteShield`. `SetWeaponds`/`SetShield` swap the equipped sprite by tier index (sourced from `GameControl.ListSpriteWeapons`/`ListSpriteShield`); `GetWeaponds`/`GetShield` restore the persisted tier on load.
- **`Enemy`** / **`BossTraining`** — parallel implementations: HP (`Health`/`maxHealth`), `Anim`, a sprite pool (`ListSpriteEnemy`/`ListSpriteBoss`) for random skinning, `OnTriggerEnter2D` (bullet hit detection), `OneHit(int)` (apply damage), `SetHealthBar` (BossTraining only has a real target — `imHealth` Image; `Enemy.SetHealthBar` has no matching field, likely a vestigial/no-op override), `CheckDie` (death → rewards), `RandomSprite`, and movement (`MoveLeft`, endless mode only). `BossTraining.isAddnewBoss` guards against double-triggering `GameControl.AddNewBoss`.
- **`BulletControl`** — generic projectile: `SetValues(Sprite, int damage, bool _CreateDamage)` configures it before firing (the `_CreateDamage` flag likely toggles whether a floating damage number spawns on impact), `MoveRight` advances it, `AutoDestroy` coroutine despawns it.
- **`HeroKameControl`** / **`HeroMagicControl`** — near-identical "hero helper" summons: fire their own bullet (`BulletMagic` via `AddBullet`), animate (`SetAnim`), and auto-hide/despawn after acting (`AutoHide` coroutine, `AutoDestroy`).
- **`txtDamageControl`** — floating combat-text popup: `SetInfor(int damage)` sets the label, `AddForce` pops it via `Rigidbody2D`, `AutoDestroy` coroutine removes it.

## Shop

- **`ItemControl`** — one row/tile in a shop panel. `SetInfor(typeItem, Sprite, int level, int cost, bool isUnlock, bool isShowBuy)` renders a tier's state (owned/locked/buyable); `ClickItem` is the buy/select handler that should call back into `GameControl`.
- **`typeItem`** enum — `ItemWeapons`, `ItemShield`, `ItemHair`. Only Weapons and Shield have panels wired in `GameControl` (`PanelWeaponds`, `PanelShield`); **Hair has no panel field**, so it's an unused/future category.

## Support systems

- **`SoundManager`** — singleton (`Instance`, currently stubbed to `return null`), one `AudioSource` (`Aud`) and three clips (`AudClick`, `AudHit`, `AudDie`) played via `PlayAudio`/`PlayClick`/`PlayHit`/`PlayDie`.
- **`KeySave`** — static `string` fields (`Level`, `Shield`, `Hair`, `OldNumClick`, `Gold`, `Gem`, `HighScore`) meant to hold PlayerPrefs key names. **They currently have no assigned literal values** (all default to `null`), so any `PlayerPrefs.GetInt(KeySave.Gold, ...)` call would fail today — this needs literals before any persistence code will work.
- **`AutoDestroyG`** — generic reusable timer: destroys its GameObject after `time` seconds via a `DestroyG` coroutine. Likely meant to be attached to `EFDamage`/`EFBossDie` VFX instances.
- **`Cmh`** — fields (`folder`, `frameRate`, `snap`, `timecheck`) suggest a frame/screenshot capture utility unrelated to gameplay; low priority.

## Ads (`AdsManager.cs`)

Wraps **two** ad networks behind one component, selected per-call via the `typeADS` enum (`Admob`, `Unity`):
- **AdMob path** (`GoogleMobileAds.Api` types: `InterstitialAd`, `RewardBasedVideoAd`, `BannerView`): `RequestInterstitial`/`ShowInterstital`/`ShowAdmobInterstitial` + `Interstitial_OnAdOpening`/`Interstitial_OnAdClosed` callbacks; `RequestRewardBasedVideo`/`ShowRewardAdmob`/`HandleRewardBasedVideoRewarded`; `RequestBanner`/`ShowBaner`; shared `CreateAdRequest()`.
- **Legacy Unity Ads path** (`UnityEngine.Advertisements`): `ShowUnityAdsReward`, `ShowUnityAds5s`, `ShowRewardVideoUnity`, `ShowVIdeoADSunity`, `CheckLoadRewardUNITY`.
- **Public dispatch entry points** meant to be called from UI/gameplay: `ShowRewardVideo()`, `ShowFull()`, `ShowRewardAdmob()`, `ShowRewardVideoUnity()` — these should branch on `yourTypeADS` to pick a network, then on reward completion call back into `GameControl` (bonus gold/gem, or extra shield via `GetShield`) via `BonuesVideosADS`/`Delaytime`.
- `numOpenLevel`, `keyBonues` (`[HideInInspector]`) look like designer-tunable gates (e.g. "only offer this ad after level N", "which bonus this ad grants").
- `MonoPInvokeCallbackAttribute` is a real (non-stub) marker attribute required for native ad SDK callbacks — nothing to implement there.

## Vendor / not part of the core loop

- `Assets/_Project/Scripts/GoogleMobileAds/` — the actual Google Mobile Ads Unity plugin source (client interfaces, platform adapters). Real SDK code, not stubbed, not to be reimplemented.
- `Assets/_Project/Scripts/EpicToonFX/` — Epic Toon FX asset-store package helper scripts (rotation, orbit camera, light fade, looping). Real vendor code.
- Root-level `ParticleEffectsLibrary.cs`, `ETFXSceneManager.cs`, `ETFXProjectileScript.cs`, `PEButtonScript.cs`, `PEDestoryTimed.cs`, and `UICanvasManager.cs`/`ButtonTypes.cs` are the **EpicToonFX demo scene's own UI/browser scripts** (particle-effect picker, numbered demo-scene loader, hover tooltips). They *are* stubbed like the game scripts, but nothing in `GameControl` references a particle-effect browser or a multi-scene demo loader — this is asset-store demo scaffolding riding along in the project, not wired into `Main.unity`'s actual game loop. Leave as low priority unless a task specifically targets it.
