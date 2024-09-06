using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TcgEngine.Gameplay;
using UnityEditor.Playables;

namespace TcgEngine
{
    /// <summary>
    /// Effect to draw cards
    /// </summary>

    [CreateAssetMenu(fileName = "effect", menuName = "TcgEngine/Effect/Draw", order = 10)]
    public class EffectDraw : EffectData
    {
        [SerializeField] EffectType value_type;
        public override void DoEffect(GameLogic logic, AbilityData ability, Card caster, Player target)
        {
            logic.DrawCard(target, GetValue(logic, ability));
        }

        public override void DoEffect(GameLogic logic, AbilityData ability, Card caster, Card target)
        {
            Player player = logic.GameData.GetPlayer(target.player_id);
            logic.DrawCard(player, GetValue(logic,ability));
        }

        int GetValue(GameLogic logic,AbilityData ability)
        {
           
            switch (value_type)
            {
                case EffectType.value:
                    return ability.value;
                case EffectType.selector_count:
                    return logic.GameData.selector_count;
                default:
                    return 0;

            }
            
        }

        public enum EffectType
        {
            value = 0,
            selector_count = 10,
        }

    }
}