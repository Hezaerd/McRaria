using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mcraria.Content.Buffs
{
    public class UndyingTotemCooldownDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Undying Totem Cooldown");
            Description.SetDefault("Can't use Undying Totem");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.persistentBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<Common.Players.mcrBuffsPlayer>().HasUndyingTotemDebuff = true;
        }
    }
}