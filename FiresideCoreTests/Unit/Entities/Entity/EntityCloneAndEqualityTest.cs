using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities;
using FiresideCore.Entities.Realisations;
using FiresideCore.Extensions;
using FiresideCore.Structural;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Entities.Entity
{
    public class EntityCloneAndEqualityTest
    {
        //Test purpose - test entity cloning functionality and equality checking.
        
        #region Setup_Members

        private FiresideCore.Entities.Entity testEntity;
        private FiresideCore.Entities.Entity clonedEntity;
        private FiresideCore.Entities.Entity notEqualEntityDifStats;
        private FiresideCore.Entities.Entity notEqualEntityDifKeywords;
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
            
            notEqualEntityDifStats = EntityFactory.Create(typeof(Card), 1);
            notEqualEntityDifStats.AsActor().AsCard().ChangeStat("Health", new Modifier(1));
            notEqualEntityDifKeywords = testEntity.Clone();
            notEqualEntityDifKeywords
                .AsActor().AsCard().AddKeyword(new Keyword(new KeywordInfo("kwd", 1)));
        }
        
        [Test]
        public void TestClones()
        {
            Assert.AreEqual(clonedEntity.Name, "Test");
            Assert.IsTrue(testEntity.Equals(clonedEntity));
            Assert.IsTrue(testCard.Equals(testEntity));
        }
        
        [Test]
        public void TestEquality()
        {
            Assert.IsFalse(notEqualEntityDifStats.Equals(testEntity));
            Assert.IsFalse(notEqualEntityDifKeywords.Equals(testEntity));
        }
    }
}