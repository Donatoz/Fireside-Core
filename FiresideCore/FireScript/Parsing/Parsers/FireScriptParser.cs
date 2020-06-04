using System.Linq;
using System.Threading.Tasks;

namespace FiresideCore.FireScript.Parsing.Parsers
{
    public class FireScriptParser : ScriptParser
    {
        public FireScriptParser(string scriptExtension) : base(scriptExtension)
        {
        }

        protected override Task<ParsingResult> Parse()
        {
            return Task<ParsingResult>.Factory.StartNew(() =>
            {
                if (buffer.Length == 0) return default;
                var result = new ParsingResult();

                if (buffer.All(line => scriptAnalyzer.AnalyzeLine(line, ref result.FinalScript))) 
                    return result;
                result.AddException(scriptAnalyzer.LastException);
                return result;

            });
        }
    }
}