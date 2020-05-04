using System;
using FiresideCore.Database.Categories;
using FiresideCore.Enums;
using FiresideCore.Mechanics;
using FiresideCore.Mechanics.Instructions;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.MechanicsTests
{
    public class InstructionsTest
    {
        //Test purpose - test instructions functionality.

        #region Setup_Members

        private Instruction testSimpleInstruction;
        private Instruction testFailingInstruction;
        private ComplexInstruction complexInstruction;

        private int testInteger = 1;
        private int testInteger2;
        private bool testBoolean;
        private bool testBoolean2;

        #endregion
        
        [SetUp]
        public void Setup()
        {
            testSimpleInstruction = new PrimitiveInstruction(() => testInteger += 1);
            testFailingInstruction = new PrimitiveInstruction(() => throw new Exception());
            
            complexInstruction = new ComplexInstruction(() => testBoolean = true);
            complexInstruction.AddParallel(new PrimitiveInstruction(() => testBoolean2 = true));
            complexInstruction.Run();
        }
        
        [Test]
        public void TestPrimitives()
        {
            Assert.IsTrue(testInteger == 2);
            Assert.IsTrue(testSimpleInstruction.GetState() == InstructionState.Done);
            Assert.IsTrue(testFailingInstruction.GetState() == InstructionState.Interrupted);
            Assert.IsTrue(testInteger2 == default);
        }
        
        [Test]
        public void TestComplex()
        {
            Assert.IsTrue(testBoolean);
            Assert.IsTrue(testBoolean2);
            Assert.IsTrue(complexInstruction.GetState() == InstructionState.Done);
        }
    }
}