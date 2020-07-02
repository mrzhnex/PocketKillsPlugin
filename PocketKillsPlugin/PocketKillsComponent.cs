using EXILED.Extensions;
using UnityEngine;

namespace PocketKillsPlugin
{
    // Token: 0x02000002 RID: 2
    public class PocketKillsComponent : MonoBehaviour
    {
        public void Update()
        {
            if (this.timeLeft > this.eventTime)
            {
                this.player.playerStats.HurtPlayer(new PlayerStats.HitInfo(damage, player.GetNickname(), DamageTypes.Scp106, player.GetPlayerId()), gameObject);
                this.timeLeft = 0f;
            }
            this.timeLeft += Time.deltaTime;
        }

        // Token: 0x04000001 RID: 1
        public ReferenceHub player;
        

        // Token: 0x04000003 RID: 3
        public float eventTime;

        // Token: 0x04000004 RID: 4
        public int damage;

        // Token: 0x04000005 RID: 5
        private float timeLeft;
    }
}