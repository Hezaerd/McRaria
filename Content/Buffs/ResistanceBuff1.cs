using Terraria;
using Terraria.ModLoader;

namespace mcraria.Content.Buffs
{
    public class ResistanceBuff1 : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Resistance");
            Description.SetDefault("Reduce incoming damage by 20%");
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<Common.Players.mcrBuffsPlayer>().HasResitanceBuff = true;

            player.endurance += 0.2f;
        }
    }
}