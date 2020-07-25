using Exiled.API.Features;
using UnityEngine;

namespace PocketKillsPlugin
{
    public class PocketKillsComponent : MonoBehaviour
    {
        public void Update()
        {
            if (TimeLeft > EventTime)
            {
                player.ReferenceHub.playerStats.HurtPlayer(new PlayerStats.HitInfo(Damage, player.Nickname, DamageTypes.Scp106, player.Id), gameObject);
                TimeLeft = 0f;
            }
            TimeLeft += Time.deltaTime;
        }

        public Player player { get; set; }
        
        public float EventTime { get; set; }

        public int Damage { get; set; }

        private float TimeLeft { get; set; }
    }
}