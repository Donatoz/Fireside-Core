using System;

namespace FiresideCore.Mechanics.Triggers
{
    /// <summary>
    /// Represents an activator of the trigger context.
    /// </summary>
    public sealed class TriggerActivator
    {
        /// <summary>
        /// Trigger activation condition.
        /// </summary>
        internal Func<bool> Context;
        
        public TriggerActivator(Func<bool> context)
        {
            this.Context = context;
        }
    }
}