using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using mcraria.Content.Buffs;
using mcraria.Common.Players;

namespace mcraria.Content.Items.Consumables.Foods
{
    public class GoldenApple : ModItem
    {
        private readonly int AbsorptionDuration = 2 * 60 * 60;
        private readonly int RegenerationDuration = 10 * 60;
        private readonly int WellFedDuration = 10 * 60 * 60;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Apple");
            Tooltip.SetDefault("");

            // TODO: Set to true when the item is animated
            //ItemID.Sets.IsFood[Item.type] = true;

            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(251, 201, 119),
                new Color(152, 93, 95),
                new Color(174, 192, 192)
            };
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(16, 16, BuffID.WellFed, WellFedDuration);

            Item.value = Item.sellPrice(silver: 11);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Apple, 1)
                .AddIngredient(ItemID.GoldBar, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(BuffID.Regeneration, RegenerationDuration);
            if (player.GetModPlayer<mcrBuffsPlayer>().CanGetAbsorptionBuff(1))
                player.AddBuff(ModContent.BuffType<AbsorptionBuff1>(), AbsorptionDuration);
        }
    }
}