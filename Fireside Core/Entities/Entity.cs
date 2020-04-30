namespace Fireside_Core.Entities
{
    /// <summary>
    /// Base class for all game objects.
    /// </summary>
    public abstract class Entity
    {
        #region Public_Members
        
        /// <summary>
        /// Name of the entity.
        /// </summary>
        public string Name { get; protected set; }
        
        /// <summary>
        /// Unique ID which offers fast access to the entity (through manager).
        /// </summary>
        public string ReferenceId { get; }
        
        #endregion
        
        /// <summary>
        /// Entity initialization (after ctor).
        /// </summary>
        public abstract void Initialize();
    }
}