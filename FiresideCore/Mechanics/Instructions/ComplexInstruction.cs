using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using FiresideCore.Enums;

namespace FiresideCore.Mechanics.Instructions
{
    /// <summary>
    /// Represents complex instruction with complex context.
    /// </summary>
    public class ComplexInstruction : Instruction
    {
        /// <summary>
        /// List of parallel instructions which is invoked at the same time as this instruction is invoked.
        /// </summary>
        private List<Instruction> parallelInstructions;
        
        public override void Run()
        {
            if(currentState != InstructionState.Ready) return;
            
            currentState = InstructionState.InProgress;

            try
            {
                context.Invoke();
                parallelInstructions.ForEach(instruction => instruction.Run());
            }
            catch
            {
                currentState = InstructionState.Interrupted;
            }

            currentState = InstructionState.Done;
        }
        
        /// <summary>
        /// Adds parallel instruction to the parallel invocation list (including duplicates).
        /// </summary>
        /// <param name="parallelInstruction">Instruction to add</param>
        public void AddParallel(Instruction parallelInstruction)
        {
            parallelInstructions.Add(parallelInstruction);
        }
        
        public ComplexInstruction(Action context, bool multiThread = false) : base(context)
        {
            parallelInstructions = new List<Instruction>();
        }
    }
}