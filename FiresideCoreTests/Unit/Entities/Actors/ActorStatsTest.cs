using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities;
using FiresideCore.Entities.Archetypes;
using FiresideCore.Entities.Realisations;
using FiresideCore.Extensions;
using FiresideCore.Structural;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Entities.Actors
{
    public class ActorStatsTest
    {
        //Test purpose - test actor stats functionality.
        
        #region Setup_Members

        private Actor testActor;
        private Actor modifiedActor;

        #endregion
        
        [SetUp]
        public void Setup()
        {
            var data = new CardData() {Name = "TestCard", DataId = 1};
            data.Stats.Add(new StatInfo{Name = "Health", Value = 1});
            CardDatabase.GetInstance().AddItem(data);
            
            testActor = EntityFactory.Create(typeof(Card), 1).AsActor();
            modifiedActor = EntityFactory.Create(typeof(Card), 1).AsActor();
            modifiedActor.ChangeStat("Health", new Modifier(4));
        }

        [Test]
        public void Test()
        {
            Assert.IsFalse(testActor.GetStat("Health") == null);
            Assert.AreEqual(testActor.GetStat("Health").EffectiveValue, 1);
            Assert.AreEqual(modifiedActor.GetStat("Health").EffectiveValue, 5);
        }
    }
}