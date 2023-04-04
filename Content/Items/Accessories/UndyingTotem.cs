using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace mcraria.Content.Items.Accessories
{
    public class UndyingTotem : ModItem
    {
        public static readonly int Cooldown = 2 * 60 * 60;
        public static readonly int ImmunityDuration = 3 * 60;

        public static readonly int AbsorptionDuration = 5 * 60;
        public static readonly int RenerationDuration = 15 * 60;
        public static readonly int FireResistanceDuration = 15 * 60;

        public static SoundStyle ActivationSound;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Totem of Undying");
            Tooltip.SetDefault("Save you from death once every 2 minutes");

            ActivationSound = new SoundStyle($"{nameof(mcraria)}/Assets/Sounds/Items/Accessories/UndyingTotem");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LifeCrystal, 2)
                .AddIngredient(ItemID.Diamond, 2)
                .AddIngredient(ItemID.Emerald, 8)
                .AddIngredient(ItemID.GoldBar, 20)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<Common.Players.mcrAccessoriesPlayer>().HasUndyingTotem = true;
        }
    }
}