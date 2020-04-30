﻿using System;
using System.Collections.Generic;
using Fireside_Core.Interfaces;
using Fireside_Core.Structural;

namespace Fireside_Core.Entities.Archetypes
{
    /// <summary>
    /// Represents all acting entities in the game.
    /// </summary>
    public abstract class Actor : Entity, IPlayable, IVulnerable
    {
        #region Public_Members
        
        public abstract Action OnSelected { get; }

        #endregion
        
        #region Protected_Members
        
        /// <summary>
        /// Actor's main stats.
        /// </summary>
        protected Dictionary<string, Stat> stats;

        #endregion

        #region Events
        
        /// <summary>
        /// Delegate for all events connected to actor behavior changes.
        /// </summary>
        public delegate void ActorStateChanged();
        
        /// <summary>
        /// Invokes when actor IS dead.
        /// </summary>
        public event ActorStateChanged OnDeath;
        /// <summary>
        /// Invokes when actor HAS appeared in the game.
        /// </summary>
        public event ActorStateChanged OnBirth;
        
        #endregion

        protected Actor()
        {
            stats = new Dictionary<string, Stat>();
        }
        
        public abstract bool CanBePlayed();
        
        public void ChangeStat(string statName, Modifier modifier)
        {
            stats[statName].AddModifier(modifier);
        }

        /// <summary>
        /// Get specific stat.
        /// </summary>
        /// <param name="statName">Searched stat name</param>
        /// <returns>Found stat or null</returns>
        public Stat GetStat(string statName)
        {
            return stats[statName];
        }
    }
}