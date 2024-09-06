using System.Collections;
using System.Collections.Generic;
using TcgEngine.Client;
using TcgEngine.UI;
using UnityEngine;

namespace TcgEngine
{
    /// <summary>
    /// Condition that check the owner of the target match the Client of the caster
    /// It's probably going to cause problems, so don't use it.
    /// </summary>

    [CreateAssetMenu(fileName = "condition", menuName = "TcgEngine/Condition/CardOwner_Respective", order = 10)]
    public class ConditionOwner_Respective : ConditionData
    {
        public ConditionOperatorBool oper;
        public override bool IsTargetConditionMet(Game data, AbilityData ability, Card caster, Card target)
        {
            bool same_owner = caster.player_id == target.player_id;
            bool b = CompareBool(same_owner, oper);
            if (caster.player_id != GameClient.Get().GetPlayerID())
                b = !b;
            return b;
        }

        public override bool IsTargetConditionMet(Game data, AbilityData ability, Card caster, Player target)
        {
            bool same_owner = caster.player_id == target.player_id;
            bool b = CompareBool(same_owner, oper);
            if (caster.player_id != GameClient.Get().GetPlayerID())
                b = !b;
            return b;
        }

        public override bool IsTargetConditionMet(Game data, AbilityData ability, Card caster, Slot target)
        {
            bool same_owner = Slot.GetP(caster.player_id) == target.p;
            bool b = CompareBool(same_owner, oper);
            if (caster.player_id != GameClient.Get().GetPlayerID())
                b = !b;
            return b;
        }
    }
}