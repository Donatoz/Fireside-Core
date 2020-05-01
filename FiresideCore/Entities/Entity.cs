using System;
using System.Collections.Generic;
using System.Reflection;
using FiresideCore.Database;
using FiresideCore.Management;

namespace FiresideCore.Entities
{
    /// <summary>
    /// Base class for all game objects and contains only object game- and metadata.
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

        #region Protected_Members

        /// <summary>
        /// Entity data which is taken from database.
        /// </summary>
        protected EntityData metaData;

        /// <summary>
        /// List of all entity extensions.
        /// </summary>
        protected List<Module> modules;

        #endregion
        
        protected Entity()
        {
            ReferenceId = ReferenceManager.AddEntity(this);
        }
        
        /// <summary>
        /// Prototype ctor.
        /// </summary>
        /// <param name="source">Clone original</param>
        protected Entity(Entity source)
        {
            Name = source.Name;
        }
        
        /// <summary>
        /// Entity initialization (after ctor).
        /// </summary>
        /// <param name="id">Id in database</param>
        public abstract void Initialize(int id);
        
        /// <summary>
        /// Clone game object.
        /// </summary>
        /// <returns>New instance of entity with same values.</returns>
        public abstract Entity Clone();

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity)) return false;
            Entity e = (Entity) obj;

            return Name == ((Entity) obj).Name && ReferenceId == ((Entity) obj).ReferenceId;
        }

        /// <summary>
        /// Get metadata of this entity.
        /// </summary>
        /// <returns>Entity metadata</returns>
        public virtual EntityData GetData()
        {
            return metaData;
        }
    }
}