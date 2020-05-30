using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FiresideCore.FireScript.Parsing
{
    /// <summary>
    /// Represents a script parser that only parses whole file (without executing).
    /// </summary>
    public abstract class ScriptParser
    {
        #region Private_member
        
        /// <summary>
        /// Parsable script extension.
        /// </summary>
        private readonly string scriptExtension;
        /// <summary>
        /// Lines of the loaded script.
        /// </summary>
        private string[] buffer;

        #endregion

        #region Protected_members
        
        /// <summary>
        /// Additional loading context, which is invoked after reading all script lines.
        /// </summary>
        protected Action loadingSubContext;

        #endregion
        
        /// <summary>
        /// Load script from path.
        /// Do not add script extension.
        /// For example C:/files/someScript (without .txt, .fscript, etc...)
        /// </summary>
        /// <param name="scriptPath">Script file path</param>
        /// <returns>Was loading successful?</returns>
        public bool Load(string scriptPath)
        {
            if (!File.Exists(scriptPath)) return false;
            buffer = File.ReadAllLines(string.Concat(scriptPath, scriptExtension));
            
            loadingSubContext.Invoke();
            
            return true;
        }
        
        /// <summary>
        /// Parse (asynchronously) existing loaded script.
        /// Use Load() function to load script.
        /// </summary>
        /// <returns></returns>
        public abstract Task<ParsingResult> Parse();

        public ScriptParser(string scriptExtension)
        {
            this.scriptExtension = scriptExtension;
        }
    }
}