using System;
using FiresideCore.Entities.Archetypes;

namespace FiresideCore.Entities.Realisations
{
    /// <summary>
    /// Represents actor on game board.
    /// </summary>
    public class Unit : Actor
    {
        #region Events
        
        /// <summary>
        /// Delegate for all events connected to unit behavior changes.
        /// </summary>
        public delegate void UnitStateChange();
        
        /// <summary>
        /// Delegate for all unit actions.
        /// </summary>
        /// <param name="target"></param>
        /// <typeparam name="T"></typeparam>
        public delegate void UnitAction<in T>(T target);
        
        /// <summary>
        /// Invokes when unit IS attacking.
        /// </summary>
        public event UnitAction<Actor> OnAttack;

        #endregion
        
        public override void Initialize(int id)
        {
            
        }

        internal Unit()
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
        
        internal override void LoadBasicInstructions()
        {
            
        }
    }
}