using System;
using Fireside_Core.Entities.Archetypes;

namespace Fireside_Core.Entities.Realisations
{
    /// <summary>
    /// Represents actor on game board.
    /// </summary>
    public class Unit : Actor
    {
        #region Events

        public delegate void UnitStateChange();
        /// <summary>
        /// Invokes when unit IS attacking.
        /// </summary>
        public event UnitStateChange OnAttack;

        #endregion
        
        public override void Initialize(int id)
        {
            
        }
        
        /// <summary>
        /// Prototype ctor.
        /// </summary>
        /// <param name="source">Clone original</param>
        protected Unit(Unit source) : base(source)
        {
            
        }

        public override Entity Clone()
        {
            return new Unit(this);
        }

        public override bool CanBePlayed()
        {
            return false;
        }

        public override Action OnSelected { get; }
    }
}