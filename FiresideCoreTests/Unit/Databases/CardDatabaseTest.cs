using FiresideCore.Database;
using FiresideCore.Database.Categories;
using NUnit.Framework;

namespace FiresideCoreTests.Unit.Databases
{
    public class CardDatabaseTest
    {
        //Test purpose - test card database functionality

        #region Setup_Members

        private CardData testCardData;

        #endregion

        [SetUp]
        public void Setup()
        {
            testCardData = new CardData();
            testCardData.DataId = 1;
            CardDatabase.GetInstance().AddItem(testCardData);
        }
        
        [Test]
        public void Test()
        {
            Assert.AreEqual(CardDatabase.GetInstance().GetItem(1), testCardData);
            Assert.AreEqual(CardDatabase.GetInstance().GetContentSize(), 1);
        }
    }
}