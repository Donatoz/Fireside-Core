using System;
using System.Collections.Generic;

namespace FiresideCore.Mechanics.Abilities
{
    /// <summary>
    /// Flexible scriptable object that represents unique ability.
    /// </summary>
    public abstract class Ability
    {
        #region Public_Members

        /// <summary>
        /// Activate this ability.
        /// </summary>
        public abstract void Activate();

        #endregion

        #region PortectedInternal_Members

        /// <summary>
        /// Context of the ability which is going to be activated.
        /// </summary>
        protected internal Instruction context;

        #endregion
        
        #region Events

        /// <summary>
        /// Delegate for all changes of the ability state.
        /// </summary>
        public delegate void AbilityStateChange();

        #endregion

        internal Ability(Instruction context)
        {
            this.context = context;
        }
    }
}