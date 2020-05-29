using System;

namespace FiresideCore.Database
{
    /// <summary>
    /// Represents scripted card ability.
    /// </summary>
    public class CardAbilityInfo
    {
        public Func<bool> Trigger;
        public Action Ability;
    }
}