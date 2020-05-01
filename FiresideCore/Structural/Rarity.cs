using System.Drawing;

namespace FiresideCore.Structural
{
    /// <summary>
    /// Represents rarity in the game (common, rare, etc...).
    /// </summary>
    public struct Rarity
    {
        #region Public_Members

        /// <summary>
        /// Name of the rarity.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// Main color of the rarity.
        /// </summary>
        public readonly Color RarityColor;

        #endregion
        
        #region Default_Rarities

        public static Rarity Common = new Rarity("Common", Color.Azure);
        public static Rarity Rare = new Rarity("Rare", Color.DodgerBlue);
        public static Rarity Epic = new Rarity("Epic", Color.BlueViolet);
        public static Rarity Legendary = new Rarity("Legendary", Color.DarkOrange);

        #endregion

        public Rarity(string name, Color color)
        {
            Name = name;
            RarityColor = color;
        }

    }
}