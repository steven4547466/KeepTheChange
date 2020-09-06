using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Scp914;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTheChange.Handlers
{
    public class Scp914
    {
        public Dictionary<ItemType, int> onRough = new Dictionary<ItemType, int>();
        public Dictionary<ItemType, int> onCoarse = new Dictionary<ItemType, int>();
        public Dictionary<ItemType, int> onOneOne = new Dictionary<ItemType, int>();
        public Dictionary<ItemType, int> onFine = new Dictionary<ItemType, int>();
        public Dictionary<ItemType, int> onVeryFine = new Dictionary<ItemType, int>();
        Random rnd = new Random();

        // This code physically hurts me what was I thinking? Oh well.
        public void Init()
        {
            if (!KeepTheChange.Instance.Config.Enable914Upgrades) return;
            var rough = KeepTheChange.Instance.Config.PossibilitiesOnRough.ToList();
            rough.Sort((x, y) => y.Value.CompareTo(x.Value));
            Dictionary<ItemType, int> onRoughCopy = rough.ToDictionary(x => x.Key, x => x.Value);
            int sum = 0;
            foreach (var item in onRoughCopy)
            {
                sum += item.Value;
                onRough.Add(item.Key, sum);
            }

            var coarse = KeepTheChange.Instance.Config.PossibilitiesOnCoarse.ToList();
            coarse.Sort((x, y) => y.Value.CompareTo(x.Value));
            Dictionary<ItemType, int> onCoarseCopy = coarse.ToDictionary(x => x.Key, x => x.Value);
            sum = 0;
            foreach (var item in onCoarseCopy)
            {
                sum += item.Value;
                onCoarse.Add(item.Key, sum);
            }

            var oneone = KeepTheChange.Instance.Config.PossibilitiesOnOneOne.ToList();
            oneone.Sort((x, y) => y.Value.CompareTo(x.Value));
            Dictionary<ItemType, int> onOneOneCopy = oneone.ToDictionary(x => x.Key, x => x.Value);
            sum = 0;
            foreach (var item in onOneOneCopy)
            {
                sum += item.Value;
                onOneOne.Add(item.Key, sum);
            }

            var fine = KeepTheChange.Instance.Config.PossibilitiesOnFine.ToList();
            fine.Sort((x, y) => y.Value.CompareTo(x.Value));
            Dictionary<ItemType, int> onFineCopy = fine.ToDictionary(x => x.Key, x => x.Value);
            sum = 0;
            foreach(var item in onFineCopy) {
                sum += item.Value;
                onFine.Add(item.Key, sum);
            }

            var veryFine = KeepTheChange.Instance.Config.PossibilitiesOnVeryFine.ToList();
            veryFine.Sort((x, y) => y.Value.CompareTo(x.Value));
            Dictionary<ItemType, int> onVeryFineCopy = fine.ToDictionary(x => x.Key, x => x.Value);
            sum = 0;
            foreach (var item in onVeryFineCopy)
            {
                sum += item.Value;
                onVeryFine.Add(item.Key, sum);
            }
        }
        public void OnUpgradingItems(UpgradingItemsEventArgs ev)
        {
            if (!KeepTheChange.Instance.Config.Enable914Upgrades) return;
            foreach (Exiled.API.Features.Player player in ev.Players)
            {
                while (player.Inventory.items.Any(item => item.id == ItemType.Coin))
                {
                    int num = rnd.Next(100);
                    int i = player.Inventory.items.FindIndex(item => item.id == ItemType.Coin);
                    switch (ev.KnobSetting)
                    {
                        case Scp914Knob.Rough:
                            InventoryChanges(onRough, player, num, i);
                            break;

                        case Scp914Knob.Coarse:
                            InventoryChanges(onCoarse, player, num, i);
                            break;

                        case Scp914Knob.OneToOne:
                            InventoryChanges(onOneOne, player, num, i);
                            break;

                        case Scp914Knob.Fine:
                            InventoryChanges(onFine, player, num, i);
                            break;

                        case Scp914Knob.VeryFine:
                            InventoryChanges(onVeryFine, player, num, i);
                            break;
                    }
                }
            }
        }

        public void InventoryChanges(Dictionary<ItemType, int> items, Exiled.API.Features.Player player, int num, int i)
        {
            foreach (var possibility in items)
            {
                if (num < possibility.Value)
                {
                    if (possibility.Key != ItemType.None)
                    {
                        Log.Debug($"Turning coin into {possibility.Key} number: {num}", KeepTheChange.Instance.Config.Debug);
                        player.Inventory.items.RemoveAt(i);
                        if(possibility.Key == ItemType.Coin)
                        {
                            Timing.CallDelayed(0.2f, () => // prevents the while loop running forever if it makes a coin.
                            {
                                player.Inventory.AddNewItem(possibility.Key); 
                            });
                        }else player.Inventory.AddNewItem(possibility.Key);
                    }
                    else
                    {
                        Log.Debug($"ItemType was none", KeepTheChange.Instance.Config.Debug);
                        player.Inventory.items.RemoveAt(i);
                    }
                    break;
                }
            }
        }
    }
}
