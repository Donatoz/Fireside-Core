using System;
using System.Text.RegularExpressions;

namespace FiresideCore.FireScript.Elements
{
    public abstract class ScriptElement
    {
        #region Private_members

        private Action elementContext;

        #endregion

        #region Protected_members

        protected Regex elementRegex;
        protected Script root;
        protected ScriptElement parent;

        #endregion
        
        public abstract void Construct(string[] scriptLines);

        public ScriptElement(Script root)
        {
            this.root = root;
        }
    }
}