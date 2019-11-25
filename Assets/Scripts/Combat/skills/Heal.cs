using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill
{
    public Heal()
    {
        amount = 10;
        cost = 20;
        cast_type = (int)CastType.mana;
    }

    public override bool IsCastable(Character caster)
    {
        // Inutile mais c'est pour l'exemple, si on veut d'autres conditions
        return base.IsCastable(caster);
    }

    public override bool IsValidTarget(Character caster, Character target)
    {
        return (caster == target || target == null);
    }

    public override void Activate(Character caster, Character target)
    {
        if (IsCastable(caster))
        {
            if (IsValidTarget(caster, target))
            {
                caster.attacking = true;
                caster.current_stats[cast_type] -= cost;
                if (target.current_stats[(int)CastType.life] < target.max_life - amount)
                    target.current_stats[(int)CastType.life] += amount;
                else
                    target.current_stats[(int)CastType.life] = target.max_life;
                caster.me_body.Cast(-amount, caster.me_body, () => { caster.attacking = false; });
            }
            else
            {
                Debug.Log(caster.name + " use no valid target");
            }
        }
        else
        {
            Debug.Log(caster.name + " can't cast this");
        }
    }

}
