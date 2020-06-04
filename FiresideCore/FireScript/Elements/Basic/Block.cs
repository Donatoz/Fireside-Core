using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FiresideCore.FireScript.Elements.Basic
{
    /// <summary>
    /// Represents code block (SCRIPT, ACTION, etc...).
    /// </summary>
    public class Block : ScriptElement
    {
        /// <summary>
        /// Block body (needs to be sub-analyzed).
        /// </summary>
        public string[] Body;
        
        public Block(Script root) : base(root)
        {
            elementRegex = new Regex(@"[A-Z]+\s*\w*\s*{[\S\s]*}");
        }

        public override void Construct(string[] scriptLines)
        {
            if (scriptLines.Length == 0 || !elementRegex.Match(scriptLines[0]).Success) return;
            Body = scriptLines.Skip(1).SkipLast(1).ToArray();
            //TODO: Call sub-analyze
        }
    }
}