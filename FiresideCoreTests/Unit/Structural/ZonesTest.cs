using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities;
using FiresideCore.Entities.Realisations;
using FiresideCore.Extensions;
using FiresideCore.Structural.Zones;
using FiresideCoreTests.Utils;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Structural
{
    public class ZonesTest
    {
        // Test purpose - test zones functionality

        #region Setup_members

        private Zone<Card> testZone;
        private Entity testEntity;
        private bool mustBeTrue;
        private bool mustBeTrue2;

        #endregion
        
        [SetUp]
        public void Setup()
        {
            var data = new CardData {Name = "Test", DataId = 1};
            CardDatabase.GetInstance().AddItem(data);
            testEntity = EntityFactory.Create(typeof(Card), TestDefaults.MainPlayer);

            testZone = new Zone<Card> {MaxSize = 1};
            testZone.OnItemAdded += delegate
            {
                mustBeTrue = true;
            };
            testZone.OnItemRemoved += delegate
            {
                mustBeTrue2 = true;
            };
            testZone.Add(testEntity.AsActor().AsCard());
        }
        
        [Test]
        public void Test()
        {
            Assert.IsTrue(testZone.Contains(testEntity.AsActor().AsCard()));
            testZone.Remove(testEntity.AsActor().AsCard());
            Assert.IsFalse(testZone.Contains(testEntity.AsActor().AsCard()));
            Assert.IsTrue(mustBeTrue);
            Assert.IsTrue(mustBeTrue2);
        }
    }
}