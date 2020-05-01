using System;
using System.Collections.Generic;
using FiresideCore.Database;
using FiresideCore.Database.Categories;
using FiresideCore.Entities.Archetypes;
using FiresideCore.Structural;

namespace FiresideCore.Entities.Realisations
{
    /// <summary>
    /// Represents card object.
    /// </summary>
    public class Card : Actor
    {
        #region Public_Members

        public override Action OnSelected { get; }

        #endregion
        
        #region Private_Members
        
        /// <summary>
        /// Card's all current keyword.
        /// </summary>
        private List<Keyword> keywords;

        #endregion
        
        #region Events
        
        /// <summary>
        /// Delegate for all events connected to card behavior changes.
        /// </summary>
        public delegate void CardStateChanged();
        
        /// <summary>
        /// Invokes when card HAS BEEN played.
        /// </summary>
        public event CardStateChanged OnPlay;
        
        /// <summary>
        /// Invokes when card IS being taken from the deck.
        /// </summary>
        public event CardStateChanged OnDraw;

        #endregion

        public override void Initialize(int id)
        {
            CardData data = CardDatabase.GetInstance().GetItem(id);
            if(data == null) return;
            
            //Entity level
            metaData = data;
            Name = data.Name;
            
            //Actor level
            foreach (var stat in data.Stats)
            {
                stats[stat.Name] = new Stat(stat.Value);
            }

            //Card level
            foreach (var keyword in data.Keywords)
            {
                keywords.Add(new Keyword(keyword));
            }
        }

        protected Card(Card source) : base(source)
        {
            keywords = source.keywords;
        }

        internal Card(int id)
        {
            keywords = new List<Keyword>();
            Initialize(id);
        }

        public override Entity Clone()
        {
            return new Card(this);
        }

        public override bool CanBePlayed()
        {
            return false;
        }

        public override EntityData GetData()
        {
            return (CardData)base.GetData();
        }
    }
}