using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities;
using FiresideCore.Entities.Realisations;
using FiresideCoreTests.Utils;
using System.Linq;
using FiresideCore.Modules.Playables;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Entities.Entity
{
    public class EntityModulesTests
    {
        //Test purpose - test modules functionality.

        #region Setup_Members

        private FiresideCore.Entities.Entity testEntity;
        private FiresideCore.Entities.Entity anotherEntity;

        #endregion
        
        [SetUp]
        public void Setup()
        {
            var data = new CardData {Name = "Test", DataId = 1};
            CardDatabase.GetInstance().AddItem(data);
            
            testEntity = EntityFactory.Create(typeof(Card), TestDefaults.MainPlayer, 1);
            anotherEntity = testEntity.Clone();
            anotherEntity.AddModule(new ControlModule(anotherEntity, TestDefaults.Enemy));
        }
        
        [Test]
        public void Test()
        {
            Assert.IsTrue(testEntity.GetModules().Any(module => module.GetType() == typeof(ControlModule)));
            Assert.IsTrue(anotherEntity.GetModules().Count == 1);
        }
    }
}