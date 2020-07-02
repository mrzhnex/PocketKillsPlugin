using EXILED;
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