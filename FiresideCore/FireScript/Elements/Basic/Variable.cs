using System.Text.RegularExpressions;

namespace FiresideCore.FireScript.Elements.Basic
{
    public class Variable : ScriptElement
    {
        public Variable(Script root) : base(root)
        {
            elementRegex = new Regex(@"var\s+\w+\s+=\s+\w+");
        }
        
        public override void Construct(string[] scriptLines)
        {
            if (scriptLines.Length == 0 || !elementRegex.Match(scriptLines[0]).Success) return;
            var splitted = Regex.Split(scriptLines[0], @"\s+");
            root.AppendVariable(splitted[1], splitted[3]);
        }
    }
}