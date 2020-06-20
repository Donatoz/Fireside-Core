using System;
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
        public Entity AttachedEntity { get; protected set; }
        /// <summary>
        /// If module is not enabled, it's context can't be used form outside.
        /// </summary>
        public bool Enabled;

        public Module(Entity attachedEntity)
        {
            AttachedEntity = attachedEntity;
        }

        /// <summary>
        /// Should be used to pass module context and execute it if module is enabled.
        /// </summary>
        /// <param name="context"></param>
        protected void PassFunction(Action context)
        {
            if (Enabled) context.Invoke();
        }
    }
}