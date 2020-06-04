using System;

namespace FiresideCore.FireScript.Analyzing.Rules
{
    public struct Rule
    {
        #region Public_members
        
        /// <summary>
        /// Regex condition.
        /// </summary>
        public readonly string Condition;
        /// <summary>
        /// Rule custom compliance check.
        /// </summary>
        public readonly Predicate<string> Compliance;
        /// <summary>
        /// Level of the rule.
        /// </summary>
        public readonly RuleLevel Level;

        #endregion

        public Rule(Predicate<string> compliance, RuleLevel level, string conditionRegex)
        {
            Compliance = compliance;
            Level = level;
            Condition = conditionRegex;
        }
    }
}