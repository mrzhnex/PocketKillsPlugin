using EXILED;

namespace PocketKillsPlugin
{
     public class MainSettings : Plugin
     {
        public SetEvents SetEvents { get; set; }
        public override string getName => nameof(PocketKillsPlugin);

        public override void OnEnable()
        {
            SetEvents = new SetEvents();
            Events.PocketDimEscapedEvent += SetEvents.OnPocketDimensionExit;
            Events.SetClassEvent += SetEvents.OnSetEvent;
            Events.UsedMedicalItemEvent += SetEvents.OnMedicalItem;
            Events.RemoteAdminCommandEvent += SetEvents.OnRemoteAdminCommand;
            Log.Info(getName + " on");
        }

        public override void OnDisable()
        {
            Events.PocketDimEscapedEvent -= SetEvents.OnPocketDimensionExit;
            Events.SetClassEvent -= SetEvents.OnSetEvent;
            Events.UsedMedicalItemEvent -= SetEvents.OnMedicalItem;
            Events.RemoteAdminCommandEvent -= SetEvents.OnRemoteAdminCommand;
            Log.Info(getName + " off");
        }

        public override void OnReload() { }
     }
}