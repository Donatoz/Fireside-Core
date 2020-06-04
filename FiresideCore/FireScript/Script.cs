using System;
using System.Collections.Generic;

namespace FiresideCore.FireScript
{
    public sealed class Script
    {
        #region Private_members

        private Action mainContext;
        private Dictionary<string, object> variables;
        private Dictionary<string, Func<object>> functions;

        #endregion

        public Script()
        {
            variables = new Dictionary<string, object>();
            functions = new Dictionary<string, Func<object>>();
            mainContext = delegate { };
        }
        
        public void AppendVariable(string name, object value)
        {
            variables[name] = value;
        }

        public void AppendContext(Action context)
        {
            mainContext += context;
        }

        public void AddFunction(string name, Func<object> function)
        {
            functions[name] = function;
        }
    }
}