using System;
using System.Collections.Generic;
using FiresideCore.FireScript.Analyzing.Rules;
using System.IO;
using System.Threading.Tasks;
using FiresideCore.FireScript.Analyzing;

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
        
        #endregion

        #region Protected_members
        
        /// <summary>
        /// Additional loading context, which is invoked after reading all script lines.
        /// </summary>
        protected Func<bool> loadingSubContext = () => true;
        
        /// <summary>
        /// Lines of the loaded script.
        /// </summary>
        protected string[] buffer;
        
        protected Analyzer scriptAnalyzer;

        #endregion

        #region Events
        
        /// <summary>
        /// Invokes when parsing is complete (in any state).
        /// </summary>
        public Action<ParsingResult> OnParsingComplete;

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
            
            return loadingSubContext.Invoke();
        }

        public virtual async void StartParsing()
        {
            OnParsingComplete(await Parse());
        }
        
        /// <summary>
        /// Parse (asynchronously) existing loaded script.
        /// Use Load() function to load script.
        /// </summary>
        /// <returns></returns>
        protected abstract Task<ParsingResult> Parse();

        public ScriptParser(string scriptExtension)
        {
            this.scriptExtension = scriptExtension;
        }

        public void LoadRules(IEnumerable<Rule> analysisRules)
        {
            scriptAnalyzer.Rules.AddRange(analysisRules);
        }
        
        /// <summary>
        /// Parse primitive script (without blocks).
        /// </summary>
        /// <param name="lines">Script lines</param>
        /// <returns>Subscript</returns>
        public Task<Script> PrimitiveParse(IEnumerable<string> lines)
        {
            return Task<Script>.Factory.StartNew(() =>
            {
                var subScript = new Script();
                foreach (var line in lines)
                {
                    if (!scriptAnalyzer.AnalyzeLine(line, ref subScript)) return null;
                }
                
                return subScript;
            });
        }
    }
}