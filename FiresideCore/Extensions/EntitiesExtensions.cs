using FiresideCore.Entities;
using FiresideCore.Entities.Archetypes;
using FiresideCore.Entities.Realisations;

namespace FiresideCore.Extensions
{
    /// <summary>
    /// Extension methods for all entities.
    /// </summary>
    public static class EntitiesExtensions
    {
        /// <summary>
        /// Convert entity into the actor.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Entity as actor</returns>
        public static Actor AsActor(this Entity e)
        {
            return e as Actor;
        }
        
        /// <summary>
        /// Convert actor into the card.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Actor as card</returns>
        public static Card AsCard(this Actor a)
        {
            return a as Card;
        }
        
        /// <summary>
        /// Convert actor into the unit.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Actor as unit</returns>
        public static Unit AsUnit(this Actor a)
        {
            return a as Unit;
        }
    }
}