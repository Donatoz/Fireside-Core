using System;

namespace FiresideCore.Entities
{
    /// <summary>
    /// Special unit for helping with creating new entities.
    /// </summary>
    internal sealed class EntityDescriptor
    {
        #region Private_Members

        /// <summary>
        /// Type of entity which is being created.
        /// </summary>
        private readonly Type entityType;
        /// <summary>
        /// Delegate which returns new entity.
        /// </summary>
        private readonly Func<Entity> descriptor;

        #endregion
        
        public EntityDescriptor(Type entityType, Func<Entity> descriptor)
        {
            this.entityType = entityType;
            this.descriptor = descriptor;
        }
        
        /// <summary>
        /// If given type equals this descriptor type, returns entity-creating delegate.
        /// </summary>
        /// <param name="type">Entity subtype to pass</param>
        /// <returns>Entity-creating delegate if given type is correct, null otherwise.</returns>
        public Func<Entity> Descript(Type type)
        {
            return type == entityType ? descriptor : null;
        }
    }
}