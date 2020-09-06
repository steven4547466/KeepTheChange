using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace KeepTheChange
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Enable debug logs.")]
        public bool Debug { get; set; } = false;

        [Description("Should coins spawn?")]
        public bool SpawnCoins { get; set; } = true;

        [Description("Should the upgrades for 914 be active?")]
        public bool Enable914Upgrades { get; set; } = true;

        [Description("The minimum amount of coins spawned.")]
        public int MinCoins { get; set; } = 10;

        [Description("The maximum amount of coins spawned.")]
        public int MaxCoins { get; set; } = 30;

        [Description("The maximum amount of coins that could spawn in a locker.")]
        public int MaxCoinsInLocker { get; set; } = 2;

        [Description("This can get complicated... These are the upgrade paths for the coin.\n  # It doesn't matter what items you put in here, just that in the end, they add up to 100 (100%). Any list that doesn't add to 100 could error. Use None as being destroyed.\n  # What can the coin turn into on rough?")]
        public Dictionary<ItemType, int> PossibilitiesOnRough { get; set; } = new Dictionary<ItemType, int>(){ { ItemType.None, 100 } };

        [Description("What does the coin turn into on coarse?")]
        public Dictionary<ItemType, int> PossibilitiesOnCoarse { get; set; } = new Dictionary<ItemType, int>() { { ItemType.None, 100 } };

        [Description("What does the coin turn into on 1:1?")]
        public Dictionary<ItemType, int> PossibilitiesOnOneOne { get; set; } = new Dictionary<ItemType, int>() { { ItemType.None, 50 }, { ItemType.Coin, 50} };

        [Description("What does the coin turn into on fine?")]
        public Dictionary<ItemType, int> PossibilitiesOnFine { get; set; } = new Dictionary<ItemType, int>() { 
            { ItemType.None, 5 }, 
            { ItemType.KeycardJanitor, 10 },
            { ItemType.KeycardO5, 3 },
            { ItemType.Medkit, 10 },
            { ItemType.Radio, 10 },
            { ItemType.Painkillers, 10 },
            { ItemType.WeaponManagerTablet, 10 },
            { ItemType.MicroHID, 1 },
            { ItemType.KeycardZoneManager, 8 },
            { ItemType.KeycardScientist, 10 },
            { ItemType.GunE11SR, 3 },
            { ItemType.Flashlight, 5 },
            { ItemType.GrenadeFrag, 5 },
            { ItemType.GrenadeFlash, 5 },
            { ItemType.GunMP7, 5 }
        };

        [Description("What does the coin turn into on very fine?")]
        public Dictionary<ItemType, int> PossibilitiesOnVeryFine { get; set; } = new Dictionary<ItemType, int>() { 
            { ItemType.None, 50 }, 
            { ItemType.GunE11SR, 10 },
            { ItemType.KeycardNTFCommander, 10 },
            { ItemType.GunCOM15, 10 },
            { ItemType.MicroHID, 5 },
            { ItemType.SCP500, 5 },
            { ItemType.KeycardO5, 5 },
            { ItemType.Coin, 5 }
        };
    }
}
