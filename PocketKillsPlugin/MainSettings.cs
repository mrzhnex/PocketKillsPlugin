using Exiled.API.Features;

namespace PocketKillsPlugin
{
     public class MainSettings : Plugin<Config>
     {
        public SetEvents SetEvents { get; set; }
        public override string Name => nameof(PocketKillsPlugin);

        public override void OnEnabled()
        {
            SetEvents = new SetEvents();
            Exiled.Events.Handlers.Player.EscapingPocketDimension += SetEvents.OnEscapingPocketDimension;
            Exiled.Events.Handlers.Player.MedicalItemUsed += SetEvents.OnMedicalItemUsed;
            Exiled.Events.Handlers.Player.ChangingRole += SetEvents.OnChangingRole;
            Exiled.Events.Handlers.Server.SendingRemoteAdminCommand += SetEvents.OnSendingRemoteAdminCommand;
            Log.Info(Name + " on");
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.EscapingPocketDimension -= SetEvents.OnEscapingPocketDimension;
            Exiled.Events.Handlers.Player.MedicalItemUsed -= SetEvents.OnMedicalItemUsed;
            Exiled.Events.Handlers.Player.ChangingRole -= SetEvents.OnChangingRole;
            Exiled.Events.Handlers.Server.SendingRemoteAdminCommand -= SetEvents.OnSendingRemoteAdminCommand;
            Log.Info(Name + " off");
        }
     }
}