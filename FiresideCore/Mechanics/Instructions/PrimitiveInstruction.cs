using System;
using FiresideCore.Entities;
using FiresideCore.Enums;

namespace FiresideCore.Mechanics.Instructions
{
    /// <summary>
    /// Represents simple instruction with straight context.
    /// </summary>
    public class PrimitiveInstruction : Instruction
    {
        public object[] Members;
        public sealed override void Run()
        {
            if (currentState != InstructionState.Ready) return;
            
            currentState = InstructionState.InProgress;

            try
            {
                if (Members == null)
                {
                    currentState = InstructionState.Ready;
                    return;
                }
                context.Invoke(Members);
            }
            catch(Exception e)
            {
                currentState = InstructionState.Interrupted;
                return;
            }

            currentState = InstructionState.Done;
        }

        public PrimitiveInstruction(Action<object[]> context) : base(context)
        {
        }

        public void SetMembers(params object[] members)
        {
            Members = members;
        }
    }
}