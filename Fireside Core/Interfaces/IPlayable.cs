using System;

namespace Fireside_Core.Interfaces
{
    /// <summary>
    /// Provides basic functionality for entities that can be played.
    /// </summary>
    public interface IPlayable
    {
        /// <summary>
        /// Does this playable can be played at this moment?
        /// </summary>
        /// <returns>True if all conditions are met, false otherwise.</returns>
        bool CanBePlayed();
        /// <summary>
        /// Invokes when playable is being selected.
        /// </summary>
        Action OnSelected { get; }
    }
}