using System;
using System.Collections.Generic;
using FiresideCore.Entities;
using System.Linq;

namespace FiresideCore.Management
{
    /// <summary>
    /// Deals with all entities in game (giving them refId, finding entities in game, etc...).
    /// </summary>
    public static class EntityManager
    {
        #region Private_Members

        /// <summary>
        /// All entities which are created after start.
        /// </summary>
        private static readonly HashSet<Entity> createdEntities = new HashSet<Entity>();
        
        /// <summary>
        /// Helps with giving new unique reference ids.
        /// </summary>
        private static int refIdCounter = 0;

        #endregion

        /// <summary>
        /// Add existing entity to the entities buffer.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>New reference id</returns>
        public static string AddEntity(Entity entity)
        {
            createdEntities.Add(entity);
            return (++refIdCounter).ToString("X");
        }
        
        /// <summary>
        /// Find entity by it's reference id.
        /// </summary>
        /// <param name="refId">Searched entity reference id</param>
        /// <returns>Found entity if such exists with giver id, null otherwise</returns>
        public static Entity FindEntity(string refId)
        {
            return String.IsNullOrEmpty(refId) 
                ? null 
                : createdEntities.ToList().Find(e => e.ReferenceId == refId);
        }
    }
}