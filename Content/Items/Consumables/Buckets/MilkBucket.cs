using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mcraria.Content.Items.Consumables.Buckets
{
    public class MilkBucket : ModItem
    {
        private readonly int WellFedDuration = 10 * 60 * 60;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Milk Bucket");
            Tooltip.SetDefault("Remove all negatives effects");
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(16, 16, BuffID.WellFed, WellFedDuration, true);

            Item.value = Item.sellPrice(silver: 2);
            Item.rare = ItemRarityID.Blue;
        }

        public override void OnConsumeItem(Player player)
        {
            player.QuickSpawnItem(Item.GetSource_NaturalSpawn(), ItemID.EmptyBucket);

            // Get all player buffs
            for (int i = 0; i < player.CountBuffs(); ++i)
            {
                // Remove all negative effects
                if (Main.debuff[player.buffType[i]])
                {
                    player.DelBuff(i);
                    i--;
                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.EmptyBucket, 1)
                .AddIngredient(ItemID.MilkCarton, 1)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}