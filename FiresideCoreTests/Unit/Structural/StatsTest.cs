using FiresideCore.Structural;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Structural
{
    public class StatsTest
    {
        //Test purpose - test stat functionality

        #region Setup_Members

        private Stat basicStat;
        private Stat modifiedStat;

        #endregion
        
        [SetUp]
        public void Setup()
        {
            basicStat = new Stat(10, 0, 10);
            modifiedStat = new Stat(1);
            modifiedStat.AddModifier(new Modifier(4));
            modifiedStat.AddModifier(new Modifier(-3));
        }
        
        [Test]
        public void Test()
        {
            Assert.AreEqual(basicStat.BaseValue, 10);
            Assert.AreEqual(basicStat.EffectiveValue, 10);
            Assert.AreEqual(modifiedStat.EffectiveValue, 2);
        }

    }
}