using System;
using FiresideCore.Entities;
using FiresideCore.Enums;

namespace FiresideCore.Mechanics
{
    /// <summary>
    /// Represents dynamic <see cref="Delegate"/> wrapper which invokes on instantiation.
    /// </summary>
    public abstract class Instruction
    {
        #region Protected_Members

        /// <summary>
        /// Current instruction state.
        /// </summary>
        protected InstructionState currentState;
        
        /// <summary>
        /// Instruction body which invokes from outside.
        /// </summary>
        protected Action<object[]> context { get; }

        #endregion

        #region Events
        
        /// <summary>
        /// Delegate for all instruction state changes.
        /// </summary>
        public delegate void InstructionStateChange();
        
        /// <summary>
        /// Invokes when instruction context has been successfully invoked.
        /// </summary>
        public event InstructionStateChange OnInstructionComplete;

        #endregion

        /// <summary>
        /// Invoke instruction context (only when instruction is ready (i.e. not running))
        /// </summary>
        public abstract void Run();
        
        /// <summary>
        /// Create new instruction with specific context.
        /// </summary>
        /// <param name="context"></param>
        public Instruction(Action<object[]> context)
        {
            this.context = context;
        }

        public Instruction(Action context)
        {
            this.context = delegate
            {
                context.Invoke();
            };
        }
            
        /// <summary>
        /// Get current instruction state.
        /// </summary>
        /// <returns>Instruction state</returns>
        public InstructionState GetState()
        {
            return currentState;
        }
        
        /// <summary>
        /// Interrupt instruction (not safe).
        /// </summary>
        internal void Interrupt()
        {
            currentState = InstructionState.Interrupted;
        }
    }
}