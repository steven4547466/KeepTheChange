using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KeepTheChange.Handlers
{
    public class Server
    {
        public int numCoins;
        public int spawnedCoins;
        System.Random rnd = new System.Random();
        public void OnRoundStarted()
        {
            if (!KeepTheChange.Instance.Config.SpawnCoins || KeepTheChange.Instance.player == null) return;
            KeepTheChange.Instance.player.openedLockers = new Dictionary<byte, List<byte>>();
            KeepTheChange.Instance.player.lockersOpened = 0;
            numCoins = rnd.Next(KeepTheChange.Instance.Config.MinCoins, KeepTheChange.Instance.Config.MaxCoins);
            spawnedCoins = 0;
            List<Room> rooms = Map.Rooms.Where(r => r.Zone == ZoneType.LightContainment).ToList();
            for(int i = 0; i < KeepTheChange.Instance.Config.MinCoins; i++)
            {
                Room room = rooms[rnd.Next(rooms.Count)];
                int maxX = 6;
                int maxZ = 6;
                if(room.Type == RoomType.LczPlants || room.Type == RoomType.LczAirlock || room.Type == RoomType.LczCrossing || room.Type == RoomType.LczCurve)
                {
                    maxX = 2;
                    maxZ = 2;
                }
                if(room.Position == null)
                {
                    i--;
                    continue;
                }
                Vector3 pos = room.Position + new Vector3((float)rnd.Next(-maxX, maxX), 3, (float)rnd.Next(-maxZ, maxZ));
                Exiled.API.Extensions.Item.Spawn(ItemType.Coin, 1f, pos, Quaternion.Euler(90, rnd.Next(361), rnd.Next(361)));
                Log.Debug($"Spawned coin in room: {room.Name} at pos ({pos.x}, {pos.y}, {pos.z})", KeepTheChange.Instance.Config.Debug);
                spawnedCoins++;
            }
        }
    }
}
