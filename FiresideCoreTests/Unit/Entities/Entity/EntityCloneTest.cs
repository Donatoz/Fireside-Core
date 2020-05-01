using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities;
using FiresideCore.Entities.Realisations;
using FiresideCore.Extensions;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Entities.Entity
{
    public class EntityCloneTest
    {
        //Test purpose - test entity cloning functionality.
        
        #region Setup_Members

        private FiresideCore.Entities.Entity testEntity;
        private FiresideCore.Entities.Entity clonedEntity;
        private Card testCard;

        #endregion

        [SetUp]
        public void Setup()
        {
            var data = new CardData(){Name = "Test", DataId = 1};
            data.Stats.Add(new StatInfo("Health", 1));
            data.Keywords.Add(new KeywordInfo("Charge", 1));
            CardDatabase.GetInstance().AddItem(data);
            
            testEntity = EntityFactory.Create(typeof(Card), 1);
            clonedEntity = testEntity.Clone();
            testCard = testEntity.Clone().AsActor().AsCard();
        }
        
        [Test]
        public void Test()
        {
            Assert.AreEqual(clonedEntity.Name, "Test");
            Assert.IsTrue(testEntity.Equals(clonedEntity));
            Assert.IsTrue(testCard.Equals(testEntity));
        }
    }
}