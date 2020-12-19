using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace KeepTheChange
{
    public class KeepTheChange : Plugin<Config>
    {
        private static readonly Lazy<KeepTheChange> LazyInstance = new Lazy<KeepTheChange>(() => new KeepTheChange());
        public static KeepTheChange Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        public override string Name { get; } = "KeepTheChange";
        public override string Author { get; } = "Steven4547466";
        public override Version Version { get; } = new Version(1, 0, 3);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 2);
        public override string Prefix { get; } = "KeepTheChange";

        private KeepTheChange() { }

        public Handlers.Server server { get; set; }
        public Handlers.Scp914 scp914 { get; set; }
        public Handlers.Player player { get; set; }

        public override void OnEnabled()
        {
            if (KeepTheChange.Instance.Config.IsEnabled == false) return;
            base.OnEnabled();
            Log.Info("KeepTheChange enabled.");
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Log.Info("KeepTheChange disabled.");
            UnregisterEvents();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
            Log.Info("KeepTheChange reloading.");
        }

        public void RegisterEvents()
        {
            if (KeepTheChange.Instance.Config.SpawnCoins)
            {
                server = new Handlers.Server();
                Server.RoundStarted += server.OnRoundStarted;

                player = new Handlers.Player();
                Player.InteractingLocker += player.OnInteractingLocker;
            }
            else
            {
                server = null;
                player = null;
            }

            if (KeepTheChange.Instance.Config.Enable914Upgrades)
            {
                scp914 = new Handlers.Scp914();
                scp914.Init();
                Exiled.Events.Handlers.Scp914.UpgradingItems += scp914.OnUpgradingItems;
            }else
            {
                scp914 = null;
            }
        }

        public void UnregisterEvents()
        {
            Log.Info("Events unregistered");
            if (KeepTheChange.Instance.Config.SpawnCoins)
            {
                Server.RoundStarted -= server.OnRoundStarted;
                server = null;

                Player.InteractingLocker -= player.OnInteractingLocker;
                player = null;
            }

            if (KeepTheChange.Instance.Config.Enable914Upgrades)
            {
                Exiled.Events.Handlers.Scp914.UpgradingItems -= scp914.OnUpgradingItems;
                scp914 = null;
            }

        }
    }
}
