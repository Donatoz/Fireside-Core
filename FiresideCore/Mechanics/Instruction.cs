using System;
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
        protected Action context { get; }

        #endregion

        /// <summary>
        /// Invoke instruction context (only when instruction is ready (i.e. not running))
        /// </summary>
        public abstract void Run();
        
        /// <summary>
        /// Create new instruction with specific context.
        /// </summary>
        /// <param name="context"></param>
        public Instruction(Action context)
        {
            this.context = context;
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