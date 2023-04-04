using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

using mcraria.Content.Buffs;
using mcraria.Common.Players;

namespace mcraria.Content.Items.Consumables.Foods
{
    public class EnchantedGoldenApple : ModItem
    {
        private readonly int RegenerationDuration = 20 * 60;
        private readonly int ResistanceDuration = 5 * 60 * 60;
        private readonly int AbsorptionDuration = 2 * 60 * 60;
        private readonly int FireResitanceDuration = 5 * 60 * 60;
        private readonly int WellFedDuration = 48 * 60 * 60;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Golden Apple");
            Tooltip.SetDefault("");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 60));

            ItemID.Sets.AnimatesAsSoul[Item.type] = true;

            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(251, 201, 119),
                new Color(152, 93, 95),
                new Color(174, 192, 192)
            };
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(16, 16, BuffID.WellFed3, WellFedDuration);

            Item.value = Item.sellPrice(platinum: 1, gold: 12);
            Item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Apple, 1)
                .AddIngredient(ItemID.GoldBar, 20)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<ResistanceBuff1>(), ResistanceDuration);
            player.AddBuff(BuffID.ObsidianSkin, FireResitanceDuration);
            player.AddBuff(BuffID.Regeneration, RegenerationDuration);
            if (player.GetModPlayer<mcrBuffsPlayer>().CanGetAbsorptionBuff(4))
            {
                player.ClearBuff(ModContent.BuffType<AbsorptionBuff1>());
                player.ClearBuff(ModContent.BuffType<AbsorptionBuff2>());

                player.AddBuff(ModContent.BuffType<AbsorptionBuff4>(), AbsorptionDuration);
            }
        }
    }
}