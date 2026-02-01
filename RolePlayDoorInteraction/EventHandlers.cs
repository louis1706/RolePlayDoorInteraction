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
            Log.Debug("DoorType:"+ ev.Door.Type);
            if (Plugin.Instance.Config.WhiteList.Contains(ev.Door.Type))
                return;
            string interactablepart = ev.Collider.ToString();
            Log.Debug("interactablepart:" + interactablepart);
            ev.CanInteract = Plugin.Instance.Config.InteractablePart.Any(interactablepart.Contains);
            Log.Debug("CanInteract:" + ev.CanInteract);
        }
    }
}