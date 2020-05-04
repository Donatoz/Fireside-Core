using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities;
using FiresideCore.Entities.Realisations;
using FiresideCore.Management;
using FiresideCoreTests.Utils;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Entities.Entity
{
    public class EntityCreationTest
    {
        //Test purpose - test entity factory

        #region Setup_Members

        private FiresideCore.Entities.Entity basicEntity;
        private FiresideCore.Entities.Entity databaseEntity;
        private CardData data;

        #endregion

        [SetUp]
        public void Setup()
        {
            basicEntity = EntityFactory.Create(typeof(Card), TestDefaults.MainPlayer);

            data = new CardData {Name = "TestCard", DataId = 1};
            CardDatabase.GetInstance().AddItem(data);
            databaseEntity = EntityFactory.Create(typeof(Card), TestDefaults.MainPlayer, 1);
        }
        
        [Test]
        public void Test()
        {
            Assert.AreEqual(ReferenceManager.FindEntity(basicEntity.ReferenceId), basicEntity);
            Assert.AreEqual("TestCard", databaseEntity.Name);
        }

    }
}