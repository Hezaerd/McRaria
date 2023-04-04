using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace mcraria.Content.Projectiles.Items.Weapons
{
    public class EnderPearlProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 2;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
        }

        private void TeleportPlayer(Vector2 position)
        {
        }

        //private void TeleportPlayer(Vector2 position)
        //{
        //    Player player = Main.player[Projectile.owner];
        //    int playerWidth = player.width;
        //    int playerHeight = player.height;
        //    Vector2 newPosition = position - new Vector2(playerWidth / 2, playerHeight / 2); // Adjust position to center of player

        //    if (Collision.CanHit(player.position, player.width, player.height, newPosition, playerWidth, playerHeight))
        //    {
        //        // Check if there's enough room to teleport
        //        player.Teleport(newPosition, 1, 0);
        //    }
        //    else
        //    {
        //        // If not, move the player to the nearest safe position
        //        int xOffset = 0;
        //        int yOffset = 0;
        //        int maxOffset = 100;
        //        bool foundSafeSpot = false;

        //        while (!foundSafeSpot && maxOffset > 0)
        //        {
        //            xOffset = Main.rand.Next(-maxOffset, maxOffset + 1);
        //            yOffset = Main.rand.Next(-maxOffset, maxOffset + 1);
        //            newPosition = position - new Vector2(playerWidth / 2, playerHeight / 2) + new Vector2(xOffset, yOffset);

        //            if (Collision.CanHit(player.position, player.width, player.height, newPosition, playerWidth, playerHeight))
        //            {
        //                foundSafeSpot = true;
        //            }
        //            else
        //            {
        //                maxOffset--;
        //            }
        //        }

        //        if (foundSafeSpot)
        //        {
        //            player.Teleport(newPosition, 1, 0);
        //        }
        //        else
        //        {
        //            // If no safe spot is found, just teleport the player to the original position
        //            player.Teleport(position, 1, 0);
        //        }
        //    }
        //}

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Teleporter);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            //for (int i = 0; i < 5; i++)
            //{
            //    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Teleporter);
            //}

            //TeleportPlayer(Projectile.position);

            Player player = Main.player[Projectile.owner];

            oldVelocity.Normalize();

            Vector2 targetPos = Projectile.position - oldVelocity * 16 * 2;

            player.Teleport(targetPos);

            return true;
        }
    }
}