using System;
using FiresideCore.Mechanics;

namespace FiresideCore.Interfaces
{
    /// <summary>
    /// Provides basic functionality for entities that can be played.
    /// </summary>
    public interface IPlayable
    {
        /// <summary>
        /// Can this playable be played at this moment?
        /// </summary>
        /// <returns>True if all conditions are met, false otherwise.</returns>
        bool CanBePlayed();
        /// <summary>
        /// Invokes when playable is being selected.
        /// </summary>
        Action OnSelected { get; }
        /// <summary>
        /// Play this playable.
        /// </summary>
        void Play(params Instruction[] instructions);
        /// <summary>
        /// Must be invoked when playable is being played.
        /// </summary>
        public Action OnPlay { get; }
    }
}