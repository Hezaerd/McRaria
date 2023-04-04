using mcraria.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using mcraria.Content.Items.Accessories;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace mcraria.Common.Players
{
    public class mcrAccessoriesPlayer : ModPlayer
    {
        public bool HasUndyingTotem;

        public override void ResetEffects()
        {
            HasUndyingTotem = false;
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            bool HasUndyingTotemDebuff = Player.GetModPlayer<mcrBuffsPlayer>().HasUndyingTotemDebuff;

            if (HasUndyingTotem && !HasUndyingTotemDebuff)
            {
                for (int i = 0; i < 75; ++i)
                {
                    Dust dust;

                    Vector2 position = Player.position;
                    float speedX = Main.rand.Next(-1, 1);
                    float speedY = 0;

                    float scale = Main.rand.Next(70, 110) * 0.01f;

                    if (Main.rand.Next(4) == 0)
                    {
                        // Yellow
                        dust = Main.dust[Terraria.Dust.NewDust(position, 10, 10, DustID.Snow, speedX, speedY, 0, new Color(172, 172, 44), scale)];
                    }
                    else
                    {
                        // Green
                        dust = Main.dust[Terraria.Dust.NewDust(position, 10, 10, DustID.Snow, speedX, speedY, 0, new Color(43, 170, 32), scale)];
                    }

                    dust.noGravity = false;
                    dust.velocity *= 1f;
                }

                SoundEngine.PlaySound(UndyingTotem.ActivationSound, Player.position);

                Player.AddImmuneTime(ImmunityCooldownID.General, UndyingTotem.ImmunityDuration);
                Player.AddImmuneTime(ImmunityCooldownID.TileContactDamage, UndyingTotem.ImmunityDuration);

                Player.Heal(5);

                Player.AddBuff(ModContent.BuffType<UndyingTotemCooldownDebuff>(), UndyingTotem.Cooldown);
                Player.AddBuff(BuffID.Regeneration, UndyingTotem.RenerationDuration);
                Player.AddBuff(BuffID.ObsidianSkin, UndyingTotem.FireResistanceDuration);
                if (Player.GetModPlayer<mcrBuffsPlayer>().CanGetAbsorptionBuff(2))
                {
                    Player.ClearBuff(ModContent.BuffType<AbsorptionBuff1>());

                    Player.AddBuff(ModContent.BuffType<AbsorptionBuff2>(), UndyingTotem.AbsorptionDuration);
                }

                return false;
            }

            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
        }
    }
}