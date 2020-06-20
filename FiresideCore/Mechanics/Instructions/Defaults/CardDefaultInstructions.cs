using System;
using FiresideCore.Entities;
using FiresideCore.Extensions;
using FiresideCore.Interfaces;
using FiresideCore.Entities.Archetypes;
using FiresideCore.Entities.Realisations;
using FiresideCore.Runtime;
using FiresideCore.Structural;
using FiresideCore.Structural.Zones;

namespace FiresideCore.Mechanics.Instructions.Defaults
{
    public static class CardDefaultInstructions
    {
        #region Attack_default

        /// <summary>
        /// Simple attack instruction.
        /// Only adjusts stats.
        /// Set instruction members before running it.
        /// First entity must be attacker (<see cref="Actor"/>), second must be attacked (<see cref="IVulnerable"/>).
        /// </summary>
        public static readonly PrimitiveInstruction Attack = new PrimitiveInstruction
        (
            delegate(object[] members)
            {
                Action<string> insufficientMembersErr = delegate(string exception)
                {
                    DebuggingProxy.Log($"Insufficient members. Error: {exception}");
                };

                #region members
                
                Actor attacker;
                IVulnerable attacked;
                
                #endregion
         
                // Checking members for compliance
                if (!(members[0] is Actor) || !(members[1] is IVulnerable))
                {
                    insufficientMembersErr("internal");
                    return;
                }
                try
                {
                    attacker = (Actor) members[0];
                    attacked = (IVulnerable) members[1];
                }
                catch (Exception e)
                {
                    insufficientMembersErr(e.Message);
                    return;
                }
                attacked.ChangeStat(Stat.HEALTH_STAT, new Modifier(-attacker.GetStat(Stat.ATTACK_STAT).EffectiveValue));
                //TODO: Change attacker stat by attacked attack stat.
            }
        );

        #endregion

        #region Move_to_zone_default
        
        /// <summary>
        /// Move the card to some zone.
        /// First member should be target (<see cref="Actor"/>),
        /// second member should be destination (<see cref="Zone{T}"/>).
        /// </summary>
        public static readonly PrimitiveInstruction MoveToZone = new PrimitiveInstruction
        (
            delegate(object[] members)
            {
                var target = (Actor)members[0];
                //TODO: Probably there might be thrown runtime exception. Fix it!
                var destination = (IZoneAdapter<Card>) members[1];
                
                
                
            }
        );

        #endregion
    }
}