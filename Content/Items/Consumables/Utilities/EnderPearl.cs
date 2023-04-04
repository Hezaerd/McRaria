using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace mcraria.Content.Items.Consumables.Utilities
{
    public class EnderPearl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ender Pearl");
            Tooltip.SetDefault("Teleports you at impact location");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;
            Item.damage = 0;
            Item.knockBack = 0;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Items.Weapons.EnderPearlProjectile>();
            Item.shootSpeed = 16f;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 64;
            Item.consumable = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 1)
                .Register();
        }
    }
}