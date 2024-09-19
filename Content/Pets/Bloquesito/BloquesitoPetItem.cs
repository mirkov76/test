using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace test.Content.Pets.Bloquesito
{
    public class BloquesitoPetItem : ModItem
	{
		// Names and descriptions of all ExamplePetX classes are defined using .hjson files in the Localization folder
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.DirtiestBlock); // Copy the Defaults of the Zephyr Fish Item.

			Item.shoot = ModContent.ProjectileType<BloquesitoPetProjectile>(); // "Shoot" your pet projectile.
			Item.buffType = ModContent.BuffType<BloquesitoPetBuff>(); // Apply buff upon usage of the Item.
		}

        public override bool? UseItem(Player player)
        {
			if (player.whoAmI == Main.myPlayer) {
				player.AddBuff(Item.buffType, 3600);
			}
   			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
