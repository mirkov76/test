using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace test.Content.Pets.Bloquesito
{
	public class BloquesitoPetProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 1;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.DirtiestBlock); // Copy the stats of the Zephyr Fish

			AIType = ProjectileID.DirtiestBlock; // Mimic as the Zephyr Fish during AI.
		}

		public override bool PreAI() {
			Player player = Main.player[Projectile.owner];

			player.petFlagDirtiestBlock = false; // Relic from AIType

			return true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];

			// Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<BloquesitoPetBuff>())) {
				Projectile.timeLeft = 2;
			}
		}
	}
}
