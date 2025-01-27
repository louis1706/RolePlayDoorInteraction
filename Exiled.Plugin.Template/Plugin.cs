using Exiled.API.Features;
using Exiled.API.Enums;
using System;

namespace Exiled.Plugin.Template
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Name => "Exiled.Plugin.Template";
        public override string Prefix => "Exiled.Plugin.Template";
        public override string Author => "aksueikava (Watashi o yūwaku suru)";
        public override Version Version => new(1, 0, 0);
        public override Version RequiredExiledVersion => new(9, 2, 1);
        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public static Plugin Instance { get; private set; }
        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();

            Log.Debug($"{base.Name} has been enabled.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Instance = null;

            Log.Debug($"{base.Name} has been disabled.");
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            if (_handlers is not null)
                return;

            _handlers = new EventHandlers();
            Exiled.Events.Handlers.Player.Verified += _handlers.OnPlayerVerified;
        }

        private void UnregisterEvents()
        {
            if (_handlers is null)
                return;

            Exiled.Events.Handlers.Player.Verified -= _handlers.OnPlayerVerified;
            _handlers = null;
        }
    }
}