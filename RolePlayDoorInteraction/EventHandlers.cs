using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;

namespace RolePlayDoorInteraction
{
    public class EventHandlers
    {
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (Plugin.Instance.Config.WhiteList.Contains(ev.Door.Type))
                return;

            ev.CanInteract = ev.Collider.ToString().Contains("TouchScreenPanel");
        }
    }
}