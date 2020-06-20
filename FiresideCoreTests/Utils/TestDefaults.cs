using System.Runtime.InteropServices;
using FiresideCore.Entities;

namespace FiresideCoreTests.Utils
{
    /// <summary>
    /// Global variables for unit tests.
    /// </summary>
    public static class TestDefaults
    {
        public static readonly Player MainPlayer = new Player {Id = 1};
        public static readonly Player Enemy = new Player {Id = 2};
        
    }
}