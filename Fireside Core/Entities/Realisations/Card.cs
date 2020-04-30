using System;
using Fireside_Core.Entities.Archetypes;

namespace Fireside_Core.Entities.Realisations
{
    /// <summary>
    /// Represents card object.
    /// </summary>
    public class Card : Actor
    {
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
            
        }

        protected Card(Card source) : base(source)
        {
            
        }

        public override Entity Clone()
        {
            return new Card(this);
        }

        public override bool CanBePlayed()
        {
            return false;
        }

        public override Action OnSelected { get; }
    }
}