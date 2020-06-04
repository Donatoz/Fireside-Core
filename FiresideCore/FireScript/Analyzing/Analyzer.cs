using System;
using System.Collections.Generic;
using FiresideCore.FireScript.Analyzing.Rules;
using System.Linq;
using System.Text.RegularExpressions;
using FiresideCore.FireScript.Parsing;

namespace FiresideCore.FireScript.Analyzing
{
    public class Analyzer
    {
        public List<Rule> Rules;
        public ParsingException LastException;

        public List<ElementDescriptor> Descriptors;

        public Analyzer()
        {
            Rules = new List<Rule>();
            Descriptors = new List<ElementDescriptor>();
        }

        public bool AnalyzeLine(string line, ref Script script)
        {
            var descriptor = Descriptors.Find(x => Regex.Match(line, x.Pattern).Success);
            try
            {
                descriptor.ScriptFilling.Invoke(ref script);
            }
            catch (Exception e)
            {
                LastException = new ParsingException(e.Message, true);
            }
            return Rules
                .Where(x => Regex.Match(line, x.Condition).Success)
                .All(x => x.Compliance(line));
        }

        internal void LoadDescriptor(ElementDescriptor descriptor)
        {
            Descriptors.Add(descriptor);
        }
    }
}