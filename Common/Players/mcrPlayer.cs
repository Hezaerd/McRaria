using Terraria;
using Terraria.ModLoader;

namespace mcraria.Common.Players
{
    public class mcrPlayer : ModPlayer
    {
        public override void PostNurseHeal(NPC nurse, int health, bool removeDebuffs, int price)
        {
            if (Main.rand.Next(0, 100) == 1)
            {
                Player.QuickSpawnItem(NPC.GetSource_NaturalSpawn(),
                    ModContent.ItemType<Content.Items.Consumables.Buckets.MilkBucket>());
            }
            base.PostNurseHeal(nurse, health, removeDebuffs, price);
        }
    }
}

