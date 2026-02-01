using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;
using NorthwoodLib;
using System;
using System.Linq;

namespace RolePlayDoorInteraction
{
    public class EventHandlers
    {
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            Config config = Plugin.Instance.Config;
            Log.Debug($"DoorType: {ev.Door.Type}");

            if (config.WhiteListDoor.Contains(ev.Door.Type))
                return;

            RoomType currentRoom = ev.Player?.CurrentRoom?.Type ?? RoomType.Unknown;
            Log.Debug($"CurrentRoom: {currentRoom}");
            if (config.WhiteListRoom.Contains(currentRoom))
                return;

            string interactablepart = ev.Collider.ToString();
            Log.Debug("Interactablepart:" + interactablepart);
            if (config.InteractablePart.Any(interactablepart.Contains))
                return;

            ev.CanInteract = false;
            Log.Debug("InteractDisabled");
        }
    }
}