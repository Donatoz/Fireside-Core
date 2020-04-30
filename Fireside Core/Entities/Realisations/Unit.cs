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
        
        public override void Initialize()
        {
            
        }

        public override bool CanBePlayed()
        {
            return false;
        }

        public override Action OnSelected { get; }
    }
}