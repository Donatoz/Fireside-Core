using System;
using System.Collections.Generic;
using System.Linq;
using FiresideCore.Database;
using FiresideCore.Interfaces;
using FiresideCore.Mechanics;
using FiresideCore.Modules.Playables;
using FiresideCore.Structural;

namespace FiresideCore.Entities.Archetypes
{
    /// <summary>
    /// Represents all acting entities which are already in the running state.
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

        protected ControlModule Control
        {
            get
            {
                if (modules.Find(x => x is ControlModule) == null)
                {
                    modules.Add(new ControlModule(this, Player.OwnerFor(this)));
                }

                return modules.Find(x => x is ControlModule) as ControlModule;
            }
        }

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
        
        public Action OnPlay { get; protected set; }

        #endregion
        
        protected Actor()
        {
            stats = new Dictionary<string, Stat>();
        }
        
        /// <summary>
        /// Prototype ctor.
        /// </summary>
        /// <param name="source">Clone original</param>
        protected Actor(Actor source) : base(source)
        {
            stats = new Dictionary<string, Stat>(source.stats);
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;
            
            if (!(obj is Actor) || ((Actor) obj).stats.Count != stats.Count) return false;

            return ((Actor) obj).stats
                .All(stat => stats[stat.Key] != null 
                             && stats[stat.Key].Equals(stat.Value));
        }

        public abstract bool CanBePlayed();

        internal abstract void LoadBasicInstructions();
        
        /// <summary>
        /// Change some stat value (if actor has this stat ofk, otherwise nothing will happen).
        /// </summary>
        /// <param name="statName"></param>
        /// <param name="modifier"></param>
        public void ChangeStat(string statName, Modifier modifier)
        {
            if(stats.ContainsKey(statName)) stats[statName].AddModifier(modifier);
        }

        /// <summary>
        /// Get specific stat.
        /// </summary>
        /// <param name="statName">Searched stat name</param>
        /// <returns>Found stat or null</returns>
        public Stat GetStat(string statName)
        {
            try
            {
                return stats[statName];
            }
            catch (KeyNotFoundException e)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Get metadata of this actor.
        /// </summary>
        /// <returns>Actor metadata</returns>
        public override EntityData GetData()
        {
            return (ActorData) base.GetData();
        }
        
        public virtual void Play(params Instruction[] instructions)
        {
            throw new NotImplementedException();
        }
    }
}