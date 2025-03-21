using Exiled.API.Features;
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
            if (Plugin.Instance.Config.WhiteList.Contains(ev.Door.Type))
                return;
            string interactablepart = ev.Collider.ToString();
            ev.CanInteract = Plugin.Instance.Config.InteractablePart.Any(x => x.Contains(interactablepart));
        }
    }
}