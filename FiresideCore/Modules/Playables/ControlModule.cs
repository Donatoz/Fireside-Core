using System;
using FiresideCore.Entities;

namespace FiresideCore.Modules.Playables
{
    public class ControlModule : Module
    {
        #region Public_Members

        /// <summary>
        /// Owner of the controlled entity.
        /// </summary>
        public Player Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
                OnOwnerChanged?.Invoke();
            }
        }

        #endregion

        #region Private_Members
        
        private Player owner;

        #endregion

        #region Events

        /// <summary>
        /// Invokes when entity's owner is changed.
        /// </summary>
        public event Action OnOwnerChanged;

        #endregion

        public ControlModule(Entity attachedEntity, Player owner) : base(attachedEntity)
        {
            this.owner = owner;
        }
        
    }
}