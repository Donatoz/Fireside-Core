using Fireside_Core.Structural;

namespace Fireside_Core.Interfaces
{
    /// <summary>
    /// Provides functionality for changing stats.
    /// </summary>
    public interface IVulnerable
    {
        /// <summary>
        /// Change specific stat value.
        /// </summary>
        /// <param name="statName">Name of the stat</param>
        /// <param name="modifier">Modify value</param>
        void ChangeStat(string statName, Modifier modifier);
    }
}