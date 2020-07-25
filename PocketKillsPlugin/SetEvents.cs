using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace PocketKillsPlugin
{
    public class SetEvents
    {
        internal void OnSendingRemoteAdminCommand(SendingRemoteAdminCommandEventArgs ev)
        {
            if (ev.Name.ToLower() != "rot")
                return;
            ev.IsAllowed = false;
            if (ev.Arguments.Count != 3)
            {
                ev.Sender.RemoteAdminMessage("Out of args. " + GetUsage());
                return;
            }

            Player player = Player.Get(ev.Arguments[0]);
            if (player == null)
            {
                ev.Sender.RemoteAdminMessage("Player not found");
                return;
            }

            if (ev.Arguments[2].ToLower() == "add")
            {
                if (player.GameObject.GetComponent<PocketKillsComponent>())
                {
                    ev.Sender.RemoteAdminMessage("Player " + player.Nickname + " is already have rot component");
                    return;
                }
                else
                {
                    PocketKillsComponent pocketKillsComponent = player.GameObject.AddComponent<PocketKillsComponent>();
                    pocketKillsComponent.player = player;
                    pocketKillsComponent.Damage = 1;
                    pocketKillsComponent.EventTime = 5;
                    ev.Sender.RemoteAdminMessage("Add rot component to " + player.Nickname);
                    return;
                }
            }
            else if (ev.Arguments[2].ToLower() == "remove")
            {
                if (player.GameObject.GetComponent<PocketKillsComponent>())
                {
                    UnityEngine.Object.Destroy(player.GameObject.GetComponent<PocketKillsComponent>());
                    ev.Sender.RemoteAdminMessage("Remove rot component from " + player.Nickname);
                    return;
                }
                else
                {
                    ev.Sender.RemoteAdminMessage("Player " + player.Nickname + " do not have rot component");
                    return;
                }
            }
            else
            {
                ev.Sender.RemoteAdminMessage("Wrong args. " + GetUsage());
                return;
            }

        }

        internal void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.Player.GameObject.GetComponent<PocketKillsComponent>())
            {
                UnityEngine.Object.Destroy(ev.Player.GameObject.GetComponent<PocketKillsComponent>());
            }
        }

        internal void OnMedicalItemUsed(UsedMedicalItemEventArgs ev)
        {
            if (ev.Item == ItemType.SCP500 && ev.Player.GameObject.GetComponent<PocketKillsComponent>())
            {
                UnityEngine.Object.Destroy(ev.Player.GameObject.GetComponent<PocketKillsComponent>());
            }
        }

        internal void OnEscapingPocketDimension(EscapingPocketDimensionEventArgs ev)
        {
            if (ev.Player.GameObject.GetComponent<PocketKillsComponent>() == null)
            {
                PocketKillsComponent pocketKillsComponent = ev.Player.GameObject.AddComponent<PocketKillsComponent>();
                pocketKillsComponent.player = ev.Player;
                pocketKillsComponent.Damage = 1;
                pocketKillsComponent.EventTime = 5;
            }
        }

        private string GetUsage()
        {
            return "Usage: rot <id/nickname> add | rot <id/nickname> remove";
        }
    }
}