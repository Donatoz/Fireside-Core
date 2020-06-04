using System.Collections.Generic;
using FiresideCore.FireScript.Analyzing;
using Rule = FiresideCore.FireScript.Analyzing.Rules.Rule;

namespace FiresideCore.FireScript
{
    public static class FireScriptDefaults
    {
        public static List<Rule> Rules = new List<Rule>
        {
            new Rule()
        };

        public static Analyzer MainAnalyzer = new Analyzer
        {
            
        };
    }
}