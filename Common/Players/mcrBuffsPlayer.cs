using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mcraria.Common.Players
{
    public class mcrBuffsPlayer : ModPlayer
    {
        /* Buffs */
        public bool HasAbsorptionBuff;
        public bool HasResitanceBuff;

        /* Buffs level */
        public int AbsorptionLevel;

        /* Debuffs */
        public bool HasUndyingTotemDebuff;

        public override void ResetEffects()
        {
            /* Buffs */
            HasAbsorptionBuff = false;
            HasResitanceBuff = false;

            /* Buffs level */
            AbsorptionLevel = 0;

            /* Debuffs */
            HasUndyingTotemDebuff = false;
        }

        public bool CanGetAbsorptionBuff(int level)
        {
            if (HasAbsorptionBuff)
            {
                if (AbsorptionLevel < level)
                {
                    return true;
                }

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}