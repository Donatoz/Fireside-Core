using System;
using System.Collections.Generic;
using System.Linq;
using FiresideCore.Enums;
using FiresideCore.Mechanics.Triggers;

namespace FiresideCore.Mechanics
{
    /// <summary>
    /// Represents custom delegate with condition to trigger.
    /// </summary>
    public class Trigger
    {
        #region Private_Members

        /// <summary>
        /// Context which invokes on trigger activation.
        /// </summary>
        private Action context;

        #endregion

        #region Protected_Members

        /// <summary>
        /// Current trigger state.
        /// </summary>
        /// <returns></returns>
        protected private TriggerState currentState;
        
        /// <summary>
        /// All trigger activators (trigger will activate if at least one of the returns "true").
        /// </summary>
        protected List<TriggerActivator> activators;

        #endregion

        /// <summary>
        /// Invoke trigger context (only when trigger is not (fully) invoked).
        /// </summary>
        public virtual void Activate()
        {
            if (currentState == TriggerState.Invoked) return;

            try
            {
                context.Invoke();
            }
            catch(Exception e)
            {
                currentState = TriggerState.Failed;
                return;
            }
            
            currentState = TriggerState.Invoked;
        }

        public Trigger(Action context)
        {
            this.context = context;
            currentState = TriggerState.Waiting;
            activators = new List<TriggerActivator>();
        }
        
        /// <summary>
        /// Get current trigger state.
        /// </summary>
        /// <returns>Trigger state</returns>
        public TriggerState GetState()
        {
            return currentState;
        }

        /// <summary>
        /// Refresh trigger state.
        /// </summary>
        public void Refresh()
        {
            if (activators.Any(activator => activator.Context())) Activate();
        }
    }
}