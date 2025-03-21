using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace RolePlayDoorInteraction
{
    public class Config : IConfig
    {
        [Description("Whether this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether debug messages should be shown in the console.")]
        public bool Debug { get; set; }

        [Description("What DoorType this plugin will not affecting.")]
        public List<DoorType> WhiteList { get; set; } = new() { DoorType.Airlock, DoorType.PrisonDoor, DoorType.HeavyBulkDoor, DoorType.Scp173Gate, DoorType.Scp173NewGate, };

        [Description("What interactable part of the door can be used.")]
        public List<string> InteractablePart { get; set; } = new() { "Button", "TouchScreenPanel" };
    }
}