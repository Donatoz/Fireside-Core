using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities;
using FiresideCore.Entities.Realisations;
using FiresideCore.Extensions;
using FiresideCore.Structural;
using FiresideCoreTests.Utils;
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
            
            testEntity = EntityFactory.Create(typeof(Card), TestDefaults.MainPlayer, 1);
            clonedEntity = testEntity.Clone();
            testCard = testEntity.Clone().AsActor().AsCard();
            
            notEqualEntityDifStats = EntityFactory.Create(typeof(Card), TestDefaults.MainPlayer, 1);
            notEqualEntityDifStats.AsActor().AsCard().ChangeStat("Health", new Modifier(1));
            notEqualEntityDifKeywords = testEntity.Clone();
            notEqualEntityDifKeywords
                .AsActor().AsCard().AddKeyword(new Keyword(new KeywordInfo("kwd", 2)));
        }
        
        [Test]
        public void TestClones()
        {
            Assert.AreEqual("Test", clonedEntity.Name);
            Assert.IsTrue(testEntity.Equals(clonedEntity));
            Assert.IsTrue(testCard.Equals(testEntity));
        }
        
        [Test]
        public void TestFakeEquality()
        {
            Assert.IsFalse(notEqualEntityDifStats.Equals(testEntity));
            Assert.IsFalse(notEqualEntityDifKeywords.Equals(testEntity));
        }
    }
}