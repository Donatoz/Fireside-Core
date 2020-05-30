using System;
using System.Collections.Generic;
using System.Linq;

namespace FiresideCore.FireScript.Parsing
{
    /// <summary>
    /// Result of the script parser.
    /// </summary>
    public struct ParsingResult
    {
        #region Properties
        
        /// <summary>
        /// Was parsing successful (if parsing result does not include critical exceptions)?
        /// </summary>
        public bool IsSuccessful
        {
            get
            {
                return exceptions.Any(x => x.Critical);
            }
        }
        
        /// <summary>
        /// Exceptions count thrown in parsing process.
        /// </summary>
        public int ExceptionsCount => exceptions.Count;

        #endregion

        #region Private_members
        
        /// <summary>
        /// All thrown exceptions.
        /// </summary>
        private readonly List<ParsingException> exceptions;

        #endregion

        public ParsingResult(params ParsingException[] exceptions)
        {
            this.exceptions = exceptions.ToList();
        }
    }
}