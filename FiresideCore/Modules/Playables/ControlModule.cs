using System;
using System.Collections.Generic;
using FiresideCore.Entities;
using FiresideCore.Mechanics.Instructions;
using System.Linq;
using FiresideCore.Mechanics;

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
        /// <summary>
        /// Default commands.
        /// </summary>
        private readonly HashSet<PrimitiveInstruction> nativeCommands;
        /// <summary>
        /// Additional commands (can be added at runtime).
        /// </summary>
        private readonly HashSet<Instruction> runtimeCommands;

        #endregion

        #region Events

        /// <summary>
        /// Invokes when entity's owner is changed.
        /// </summary>
        public event Action OnOwnerChanged;

        #endregion

        public ControlModule(Entity attachedEntity, Player owner, params PrimitiveInstruction[] nativeCmds) : base(attachedEntity)
        {
            this.owner = owner;
            nativeCommands = new HashSet<PrimitiveInstruction>();
            foreach (var cmd in nativeCmds)
            {
                nativeCommands.Add(cmd);
            }
        }
        
        /// <summary>
        /// Load custom runtime commands.
        /// </summary>
        /// <param name="commands">Commands to add</param>
        public void LoadCommands(params PrimitiveInstruction[] commands)
        {
            foreach (var cmd in commands)
            {
                runtimeCommands.Add(cmd);
            }
        }

        internal void LoadBasicCommands(params PrimitiveInstruction[] commands)
        {
            foreach (var cmd in commands)
            {
                nativeCommands.Add(cmd);
            }
        }
    }
}