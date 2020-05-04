using System;
using System.Collections.Generic;

namespace FiresideCore.Structural
{
    /// <summary>
    /// Represents mutable value with minimal and maximal values.
    /// </summary>
    public class Stat
    {
        #region Public_Members
        
        /// <summary>
        /// Base value of the stat (stat effective value without modifiers).
        /// </summary>
        public int BaseValue { get; set; }
        
        /// <summary>
        /// Unmutuable value which was given to the stat in constructor.
        /// </summary>
        public int OriginalValue { get; }
        
        /// <summary>
        /// Minimal value which stat can have.
        /// </summary>
        public int MinimumValue { get; set; }
        
        /// <summary>
        /// Maximal value which stat can have.
        /// </summary>
        public int MaximumValue { get; set; }
        
        /// <summary>
        /// Base value summed with all modifiers.
        /// </summary>
        public int EffectiveValue
        {
            get
            {
                var result = BaseValue;
                for (var i = 0; i < modifiers.Count; i++)
                {
                    result += modifiers[i].Value;
                }

                return Math.Clamp(result, MinimumValue, MaximumValue);
            }
        }
        
        #endregion
        
        #region Private_Members
        
        /// <summary>
        /// All stat-affecting modifiers.
        /// </summary>
        private List<Modifier> modifiers;

        #endregion

        #region Events
        /// <summary>
        /// Delegate for all events connected to stat (value) changes.
        /// </summary>
        public delegate void StateChanged();
        
        /// <summary>
        /// Invokes when stat effective value changes (new modifier being added).
        /// </summary>
        public event StateChanged OnValueChanged;
        
        #endregion
        
        public Stat(int baseValue, int minimumValue = Int32.MinValue, int maximumValue = Int32.MaxValue)
        {
            BaseValue = baseValue;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
            OriginalValue = baseValue;
            modifiers = new List<Modifier>();
        }
        
        /// <summary>
        /// Modify stat by adding new modifier.
        /// </summary>
        /// <param name="modifier">New modifier</param>
        public void AddModifier(Modifier modifier)
        {
            modifiers.Add(modifier);
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Stat)) return false;

            var s = (Stat) obj;
            return s.EffectiveValue == EffectiveValue
                   && s.modifiers.Count == modifiers.Count
                   && BaseValue == s.BaseValue;
        }
        
        /// <summary>
        /// Remove modifier from stat.
        /// </summary>
        /// <param name="modifier">Existing modifier</param>
        public void RemoveModifier(Modifier modifier)
        {
            modifiers.Remove(modifier);
        }
    }
}