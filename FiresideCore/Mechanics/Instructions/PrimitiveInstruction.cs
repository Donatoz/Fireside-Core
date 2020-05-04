using System;
using FiresideCore.Enums;

namespace FiresideCore.Mechanics.Instructions
{
    /// <summary>
    /// Represents simple instruction with straight context.
    /// </summary>
    public class PrimitiveInstruction : Instruction
    {
        public sealed override void Run()
        {
            if (currentState != InstructionState.Ready) return;
            
            currentState = InstructionState.InProgress;

            try
            {
                context.Invoke();
            }
            catch(Exception e)
            {
                currentState = InstructionState.Interrupted;
                return;
            }

            currentState = InstructionState.Done;
        }

        public PrimitiveInstruction(Action context) : base(context)
        {
            Run();
        }
    }
}