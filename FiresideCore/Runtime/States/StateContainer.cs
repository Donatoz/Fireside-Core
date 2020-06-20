using FiresideCore.Entities;
using FiresideCore.Entities.Realisations;
using FiresideCore.Structural.Zones;

namespace FiresideCore.Runtime.States
{
    /// <summary>
    /// Contains information about specific entity in the game.
    /// </summary>
    /// <typeparam name="T">Entity sub-type</typeparam>
    public struct StateContainer<T> where T : Entity
    {
        /// <summary>
        /// Reference id of the contained entity.
        /// </summary>
        public readonly int RefId;
        /// <summary>
        /// Current zone of the contained entity.
        /// </summary>
        public readonly Zone<T> CurrentZone;

        public StateContainer(int refId, Zone<T> currentZone)
        {
            RefId = refId;
            CurrentZone = currentZone;
        }
    }
}