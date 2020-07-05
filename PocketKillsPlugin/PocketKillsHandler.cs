using EXILED;
using EXILED.Extensions;
using System;

namespace PocketKillsPlugin
{
    internal class PocketKillsHandler
    {
        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (ev.Player.gameObject.GetComponent<PocketKillsComponent>())
            {
                UnityEngine.Object.Destroy(ev.Player.gameObject.GetComponent<PocketKillsComponent>());
            }
        }

        public void OnPocketDimensionExit(PocketDimEscapedEvent ev)
        {
            if (ev.Player.gameObject.GetComponent<PocketKillsComponent>() == null)
            {
                PocketKillsComponent pocketKillsComponent = ev.Player.gameObject.AddComponent<PocketKillsComponent>();
                pocketKillsComponent.player = ev.Player;
                pocketKillsComponent.damage = 1;
                pocketKillsComponent.eventTime = 5;
            }
        }

        internal void OnRemoteAdminCommand(ref RACommandEvent ev)
        {
            string[] args = ev.Command.Split(' ');
            if (args.Length == 0 || args[0].ToLower() != "rot")
                return;

            if (args.Length != 3)
            {
                ev.Sender.RAMessage("Out of args. " + GetUsage());
                return;
            }

            ReferenceHub referenceHub = Player.GetPlayer(args[1]);
            if (referenceHub == null)
            {
                ev.Sender.RAMessage("Player not found");
                return;
            }

            if (args[2].ToLower() == "add")
            {
                if (referenceHub.gameObject.GetComponent<PocketKillsComponent>())
                {
                    ev.Sender.RAMessage("Player " + referenceHub.nicknameSync.Network_myNickSync + " is already have rot component");
                    return;
                }
                else
                {
                    PocketKillsComponent pocketKillsComponent = referenceHub.gameObject.AddComponent<PocketKillsComponent>();
                    pocketKillsComponent.player = referenceHub;
                    pocketKillsComponent.damage = 1;
                    pocketKillsComponent.eventTime = 5;
                    ev.Sender.RAMessage("Add rot component to " + referenceHub.nicknameSync.Network_myNickSync);
                    return;
                }
            }
            else if (args[2].ToLower() == "remove")
            {
                if (referenceHub.gameObject.GetComponent<PocketKillsComponent>())
                {
                    UnityEngine.Object.Destroy(referenceHub.gameObject.GetComponent<PocketKillsComponent>());
                    ev.Sender.RAMessage("Remove rot component from " + referenceHub.nicknameSync.Network_myNickSync);
                    return;
                }
                else
                {
                    ev.Sender.RAMessage("Player " + referenceHub.nicknameSync.Network_myNickSync + " do not have rot component");
                    return;
                }
            }
            else
            {
                ev.Sender.RAMessage("Wrong args. " + GetUsage());
                return;
            }

        }

        private string GetUsage()
        {
            return "Usage: rot <id/nickname> add | rot <id/nickname> remove";
        }

        internal void OnMedicalItem(UsedMedicalItemEvent ev)
        {
            if (ev.ItemType == ItemType.SCP500 && ev.Player.gameObject.GetComponent<PocketKillsComponent>())
            {
                UnityEngine.Object.Destroy(ev.Player.gameObject.GetComponent<PocketKillsComponent>());
            }
        }

        internal void OnSetEvent(SetClassEvent ev)
        {
            if (ev.Player.gameObject.GetComponent<PocketKillsComponent>())
            {
                UnityEngine.Object.Destroy(ev.Player.gameObject.GetComponent<PocketKillsComponent>());
            }
        }
    }
}