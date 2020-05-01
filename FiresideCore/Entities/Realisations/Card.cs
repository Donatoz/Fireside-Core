﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Delegate for all card value changes.
        /// </summary>
        /// <param name="value">Changed value</param>
        /// <typeparam name="T">Changed value type</typeparam>
        public delegate void CardValueChanged<in T>(T value);
        
        /// <summary>
        /// Invokes when card HAS BEEN played.
        /// </summary>
        public event CardStateChanged OnPlay;
        
        /// <summary>
        /// Invokes when card IS being taken from the deck.
        /// </summary>
        public event CardStateChanged OnDraw;
        
        /// <summary>
        /// Invokes when some keyword is being added/removed from this card.
        /// </summary>
        public event CardValueChanged<Keyword> OnKeywordAdded;

        #endregion

        public override void Initialize(int id)
        {
            // Get data from card database
            var data = CardDatabase.GetInstance().GetItem(id);
            if (data == null) return;
            
            // Entity level
            metaData = data;
            Name = data.Name;
            
            // Actor level
            foreach (var stat in data.Stats)
            {
                stats[stat.Name] = new Stat(stat.Value);
            }

            // Card level
            foreach (var keyword in data.Keywords)
            {
                keywords.Add(new Keyword(keyword));
            }
        }

        protected Card(Card source) : base(source)
        {
            keywords = source.keywords;
        }

        public override bool Equals(object? obj)
        {
            if (!base.Equals(obj)) return false;
            
            if (!(obj is Card) || ((Card) obj).keywords.Count != keywords.Count) return false;

            return ((Card) obj).keywords
                .All(keyword => keywords.Find(k => k.Equals(keyword)) != null);
        }

        internal Card(int id)
        {
            keywords = new List<Keyword>();
            Initialize(id);
        }
        
        /// <summary>
        /// Add keyword to this card.
        /// </summary>
        /// <param name="keyword">Keyword to add</param>
        public void AddKeyword(Keyword keyword)
        {
            if (keywords.Contains(keyword)) return;
            keywords.Add(keyword);
            OnKeywordAdded?.Invoke(keyword);
        }
        
        /// <summary>
        /// Remove keyword by it's meta id.
        /// </summary>
        /// <param name="metaId">Keyword meta id</param>
        public void RemoveKeyword(int metaId)
        {
            keywords.Remove(keywords.Find(keyword => keyword.GetMetaId() == metaId));
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