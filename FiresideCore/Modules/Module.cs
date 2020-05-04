using FiresideCore.Entities;

namespace FiresideCore.Modules
{
    /// <summary>
    /// Represents functionality extension for entity.
    /// </summary>
    public abstract class Module
    {
        /// <summary>
        /// Target entity.
        /// </summary>
        public Entity AttachedEntity { get; }

        public Module(Entity attachedEntity)
        {
            AttachedEntity = attachedEntity;
        }
    }
}