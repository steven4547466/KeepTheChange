using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KeepTheChange.Handlers
{
    public class Player
    {
        System.Random rnd = new System.Random();
        Dictionary<byte, List<byte>> openedLockers = new Dictionary<byte, List<byte>>();
        int lockersOpened = 0;
        public void OnInteractingLocker(InteractingLockerEventArgs ev)
        {
            if (!KeepTheChange.Instance.Config.SpawnCoins) return;
            if (KeepTheChange.Instance.server.spawnedCoins >= KeepTheChange.Instance.Config.MaxCoins) return;
            lockersOpened++;
            if (lockersOpened % 2 == 0) return; // For some reason it's called twice so we just disregard every 2nd call. I'll remove this once it's fixed
            if (openedLockers.ContainsKey(ev.LockerId) && openedLockers[ev.LockerId].Contains(ev.ChamberId)) return;
            if (!openedLockers.ContainsKey(ev.LockerId)) openedLockers.Add(ev.LockerId, new List<byte>() { ev.ChamberId });
            else openedLockers[ev.LockerId].Add(ev.ChamberId);
            int coinsToSpawn = Mathf.Clamp(rnd.Next(0, KeepTheChange.Instance.Config.MaxCoinsInLocker), 0, KeepTheChange.Instance.Config.MaxCoins - KeepTheChange.Instance.server.spawnedCoins);
            for (int i = 0; i < coinsToSpawn; i++)
            {
                Vector3 pos = new Vector3(ev.Chamber.spawnpoint.position.x, ev.Locker.gameObject.position.y + rnd.Next(-1, 2), ev.Chamber.spawnpoint.position.z);
                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 1f, pos, Quaternion.Euler(90, rnd.Next(361), rnd.Next(361)));
                Log.Debug($"Spawned coin in locker at pos ({pos.x}, {pos.y}, {pos.z})", KeepTheChange.Instance.Config.Debug);
            }
        }
    }
}
