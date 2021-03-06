﻿using System;
using FiresideCore.Entities.Realisations;
using FiresideCore.Interfaces;
using FiresideCore.Structural.Zones;

namespace FiresideCore.Entities
{
    /// <summary>
    /// Represents interface for real player to control the game.
    /// </summary>
    public sealed class Player
    {
        #region Public_Members

        /// <summary>
        /// Player unique id (1 - player, 2 - enemy, 3+ - custom).
        /// </summary>
        public int Id;
        
        /// <summary>
        /// Player's name.
        /// </summary>
        public readonly string Name;

        #endregion

        #region Private_Members
        
        /// <summary>
        /// A zone, where all not yet drawn card are held.
        /// </summary>
        private Zone<Card> deck = new Zone<Card>();
        
        /// <summary>
        /// A zone, where all drawn cards and playable cards are held.
        /// </summary>
        private Zone<Card> hand = new Zone<Card>();
        
        /// <summary>
        /// A zone, where all alive units are held.
        /// </summary>
        private Zone<Unit> board = new Zone<Unit>();
        
        /// <summary>
        /// A zone, where all dead units are held.
        /// </summary>
        private Zone<Unit> graveyard = new Zone<Unit>();

        #endregion

        public static Player OwnerFor(IPlayable playable)
        {
            throw new NotImplementedException();
        }
    }
}