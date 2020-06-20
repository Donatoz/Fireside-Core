using FiresideCore.Entities.Realisations;

namespace FiresideCore.Runtime.States
{
    /// <summary>
    /// Current game state.
    /// Includes information about all creatures, heroes, cards, decks, etc...
    /// </summary>
    public struct GameState
    {
        public static GameState Current = new GameState();
        
        /// <summary>
        /// All cards in current match (both players).
        /// </summary>
        public StateContainer<Card>[] Cards;
        /// <summary>
        /// All units in current match (both players).
        /// </summary>
        public StateContainer<Unit>[] Units;
        /// <summary>
        /// Player-controlled hero.
        /// </summary>
        public StateContainer<Hero> Player;
        /// <summary>
        /// Enemy-controlled hero.
        /// </summary>
        public StateContainer<Hero> Enemy;
    }
}