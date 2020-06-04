using System;
using FiresideCore.FireScript.Elements;

namespace FiresideCore.FireScript.Analyzing
{
    public readonly struct ElementDescriptor
    {
        /// <summary>
        /// Delegate for filling function.
        /// </summary>
        /// <param name="script"></param>
        public delegate void FillingDelegate(ref Script script);
        
        /// <summary>
        /// Descripting function.
        /// </summary>
        public readonly Func<ScriptElement> Descript;
        /// <summary>
        /// The regex pattern this descriptor matches.
        /// </summary>
        public readonly string Pattern;
        /// <summary>
        /// Actions which are done with given script when descriptor is being used.
        /// </summary>
        public readonly FillingDelegate ScriptFilling;

        public ElementDescriptor(Func<ScriptElement> descriptContext, string pattern, FillingDelegate scriptFilling)
        {
            Descript = descriptContext;
            Pattern = pattern;
            ScriptFilling = scriptFilling;
        }
    }
}