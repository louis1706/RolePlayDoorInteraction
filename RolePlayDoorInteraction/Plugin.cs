using Exiled.API.Features;
using Exiled.API.Enums;
using System;

namespace RolePlayDoorInteraction
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Name => "RolePlayDoorInteraction";
        public override string Prefix => "rp_door_interaction";
        public override string Author => "Yamato";
        public override Version Version { get; } = new(1, 0, 1);
        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public static Plugin Instance { get; private set; }
        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;
            _handlers = new EventHandlers();
            Exiled.Events.Handlers.Player.InteractingDoor += _handlers.OnInteractingDoor;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.InteractingDoor -= _handlers.OnInteractingDoor;
            _handlers = null;

            base.OnDisabled();
        }
    }
}