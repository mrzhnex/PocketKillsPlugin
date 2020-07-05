using EXILED;

namespace PocketKillsPlugin
{
     internal class PocketKillsPlugin : Plugin
     {
        PocketKillsHandler pocketKillsHandler;
        public override string getName => "PocketKillsPlugin";

        public override void OnEnable()
        {
            pocketKillsHandler = new PocketKillsHandler();
            Events.PocketDimEscapedEvent += pocketKillsHandler.OnPocketDimensionExit;
            Events.SetClassEvent += pocketKillsHandler.OnSetEvent;
            Events.UsedMedicalItemEvent += pocketKillsHandler.OnMedicalItem;
            Events.RemoteAdminCommandEvent += pocketKillsHandler.OnRemoteAdminCommand;
            Log.Info(getName + " on");
        }

        public override void OnDisable()
        {
            Events.PocketDimEscapedEvent -= pocketKillsHandler.OnPocketDimensionExit;
            Events.SetClassEvent -= pocketKillsHandler.OnSetEvent;
            Events.UsedMedicalItemEvent -= pocketKillsHandler.OnMedicalItem;
            Events.RemoteAdminCommandEvent -= pocketKillsHandler.OnRemoteAdminCommand;
            Log.Info(getName + " off");
        }

        public override void OnReload() { }
     }
}