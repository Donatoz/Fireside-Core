using System;
using FiresideCore.Entities.Archetypes;

namespace FiresideCore.Entities.Realisations
{
    /// <summary>
    /// Represents player-controlled actor.
    /// Hero is special sort of card, which acts like main actor controllable by player.
    /// Hero's death means that one of the players has won (this one, whose hero is alive).
    /// </summary>
    public class Hero : Actor
    {
        protected Hero(Hero source) : base(source)
        {
            
        }
        
        public override void Initialize(int id)
        {
            throw new NotImplementedException();
        }

        public override Entity Clone()
        {
            throw new NotImplementedException();
        }

        public override bool CanBePlayed()
        {
            throw new NotImplementedException();
        }

        public override Action OnSelected { get; }
    }
}