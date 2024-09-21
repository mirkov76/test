using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace test.Content.Rarities
{
	public class TestRarity : ModRarity
	{
		public override Color RarityColor => new(200, 215, 230);

		public override int GetPrefixedRarity(int offset, float valueMult) {
			if (offset > 0) { // If the offset is 1 or 2 (a positive modifier).
				return ModContent.RarityType<TestHigherTierRarity>(); // Make the rarity of items that have this rarity with a positive modifier the higher tier one.
			}

			return Type; // no 'lower' tier to go to, so return the type of this rarity.
		}
	}
}
