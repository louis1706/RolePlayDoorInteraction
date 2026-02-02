using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Roles;
using Exiled.API.Interfaces;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using NorthwoodLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RolePlayDoorInteraction
{
    public class EventHandlers
    {
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (ev.Player?.Role is not FpcRole)
                return;

            Config config = Plugin.Instance.Config;
            if (CustomRole.TryGet(ev.Player, out IReadOnlyCollection<CustomRole> customRoles))
            {
                foreach (CustomRole customrole in customRoles)
                {
                    if (config.WhiteListCustomRole.Contains(customrole.Id))
                        return;
                }
            }
            else if (config.WhiteListRole.Contains(ev.Player.Role.Type))
                return;

            Log.Debug($"DoorType: {ev.Door.Type}");

            if (config.WhiteListDoor.Contains(ev.Door.Type))
                return;

            RoomType currentRoom = ev.Player.CurrentRoom?.Type ?? RoomType.Unknown;
            Log.Debug($"CurrentRoom: {currentRoom}");
            if (config.WhiteListRoom.Contains(currentRoom))
                return;

            string interactablepart = ev.Collider?.ToString();
            Log.Debug("Interactablepart:" + interactablepart);
            if (string.IsNullOrWhiteSpace(interactablepart) || config.InteractablePart.Any(interactablepart.Contains))
                return;

            ev.CanInteract = false;
            Log.Debug("InteractDisabled");
        }
    }
}