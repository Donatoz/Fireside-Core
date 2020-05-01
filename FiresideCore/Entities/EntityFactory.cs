using System;
using System.Collections.Generic;
using FiresideCore.Entities.Realisations;
using FiresideCore.Structural;

namespace FiresideCore.Entities
{
    /// <summary>
    /// Central factory which creates all entities.
    /// </summary>
    public static class EntityFactory
    {
        /// <summary>
        /// Used for passing in some entity ctor.
        /// </summary>
        private static int currentId = 0;
        
        /// <summary>
        /// List of available descriptors.
        /// </summary>
        private static readonly List<EntityDescriptor> nativeDescriptors = new List<EntityDescriptor>
        {
            new EntityDescriptor(typeof(Card), () => new Card(currentId)),
            new EntityDescriptor(typeof(Unit), () => new Unit(currentId))
        };
        
        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entityType">Entity subtype (Card, unit, etc...)</param>
        /// <param name="id">Global id (in database)</param>
        /// <returns>New entity if all requirements were met, null otherwise.</returns>
        public static Entity Create(Type entityType, int id = 0)
        {
            if (!entityType.IsSubclassOf(typeof(Entity))) return null;

            Func<Entity> validDescriptor = null;
            foreach (var descriptor in nativeDescriptors)
            {
                validDescriptor = descriptor.Descript(entityType);
                if (validDescriptor != null) break;
            }

            currentId = id;
            return validDescriptor?.Invoke();
        }
    }
}