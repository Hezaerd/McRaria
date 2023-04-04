using Terraria;
using Terraria.ModLoader;

using mcraria.Common.Players;

namespace mcraria.Content.Buffs
{
    public class AbsorptionBuff4 : ModBuff
    {
        public static readonly int Absorption = 160;

        private bool hasHealed = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Absorption");
            Description.SetDefault("Increased maximum health.");
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<mcrBuffsPlayer>().HasAbsorptionBuff = true;
            player.GetModPlayer<mcrBuffsPlayer>().AbsorptionLevel = 4;

            player.statLifeMax2 += Absorption;

            if (!hasHealed)
            {
                player.Heal(Absorption);
                player.HealEffect(Absorption);

                hasHealed = true;
            }

            if (player.buffTime[buffIndex] <= 0)
            {
                if (player.statLife - Absorption <= 0)
                    player.statLife = 1;
                else
                    player.statLife -= Absorption;

                hasHealed = false;
            }
        }
    }
}