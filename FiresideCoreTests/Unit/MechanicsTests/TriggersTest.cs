using System;
using FiresideCore.Database.Categories;
using FiresideCore.Enums;
using FiresideCore.Mechanics;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.MechanicsTests
{
    public class TriggersTest
    {
        //Test purpose - test triggers functionality

        #region Setup_Members

        private Trigger someTrigger;
        private Trigger failingTrigger;

        private bool testBoolean;
        private string testStr;

        #endregion
        
        [SetUp]
        public void Setup()
        {
            someTrigger = new Trigger(() => testBoolean = true);
            someTrigger.Activate();
            
            failingTrigger = new Trigger(() => throw new Exception());
            failingTrigger.Activate();
        }
        
        [Test]
        public void Test()
        {
            Assert.AreEqual(TriggerState.Invoked, someTrigger.GetState());
            Assert.IsTrue(testBoolean);
            Assert.AreEqual(TriggerState.Failed, failingTrigger.GetState());
            Assert.IsTrue(testStr == null);
        }
    }
}