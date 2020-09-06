This plugin spawns a configurable random amount of coins in the light containment zone for people to find. It will also randomly spawn coins in lockers until it hits the configurable max coins. It also adds upgrade paths to 914 to coins that are fully configurable.

You can always find the latest stable dll file [here](https://github.com/steven4547466/KeepTheChange/releases/latest). This plugin requires EXILED, which you can find [here](https://github.com/galaxy119/EXILED).

## Config options

- Debug (false) - Enable debug logs.

- SpawnCoins (true) - Enables coin spawning (if you only want the upgrades for coins, turn this off).
- Enable914Upgrades (true) - Enables 914 upgrades for coins. This exists for compatibility reasons.

- MinCoins (10) - The minimum amount of coins that will spawn (the amout of coins randomly spawned in rooms).
- MaxCoins (30) - The maximum amount of coins that will spawn (the max is a random number between the min and max value. The amount of coins that could be in lockers is equal to RandomMax - MinCoins.).
- MaxCoinsInLocker (2) - The max number of coins in one locker division.

These next options are the upgrade paths, it doesn't matter what order you put them in, or what items you use, but the end value must add to 100. If it doesn't, it could error. Default values are not shown.

- PossibilitiesOnRough - The coins possible outcomes on rough.
- PossibilitiesOnCoarse - The coins possible outcomes on coarse.
- PossibilitiesOnOneOne - The coins possible outcomes on one to one.
- PossibilitiesOnFine - The coins possible outcomes on fine.
- PossibilitiesOnVeryFine - The coins possible outcomes on very fine.

### Item types

There are many item types, so here they are.

- KeycardJanitor
- KeycardScientist
- KeycardScientistMajor
- KeycardZoneManager
- KeycardGuard
- KeycardSeniorGuard
- KeycardContainmentEngineer
- KeycardNTFLieutenant
- KeycardNTFCommander
- KeycardFacilityManager
- KeycardChaosInsurgency
- KeycardO5
- Radio
- GunCOM15
- Medkit
- Flashlight
- MicroHID
- SCP500
- SCP207
- WeaponManagerTablet
- GunE11SR
- GunProject90
- Ammo556
- GunMP7
- GunLogicer
- GrenadeFrag
- GrenadeFlash
- Disarmer
- Ammo762
- Ammo9mm
- GunUSP
- SCP018
- SCP268
- Adrenaline
- Painkillers
- Coin
- None