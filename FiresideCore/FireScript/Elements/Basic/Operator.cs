using System.Text.RegularExpressions;

namespace FiresideCore.FireScript.Elements.Basic
{
    public class Operator : ScriptElement
    {
        protected string operatorSymbol;
        
        protected Operator(Script root) : base(root)
        {
            elementRegex = new Regex($@"[a-zA-Z0-9_]+\s*{operatorSymbol}\s*[a-zA-Z0-9]+");
        }
        
        public override void Construct(string[] scriptLines)
        {
            throw new System.NotImplementedException();
        }
    }
}