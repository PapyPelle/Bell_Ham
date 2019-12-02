using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMist : Skill
{
    public PoisonMist()
    {
        amount = 10;
        cost = 50;
        cast_type = (int)CastType.mana;
    }

    public override bool IsCastable(Character caster)
    {
        // Inutile mais c'est pour l'exemple, si on veut d'autres conditions
        return base.IsCastable(caster);
    }

    public override bool IsValidTarget(Character caster, Character target)
    {
        return (target != null);
    }

    public override void Activate(Character caster, Character target)
    {
        if (IsCastable(caster))
        {
            if (IsValidTarget(caster, target))
            {
                caster.attacking = true;
                caster.current_stats[cast_type] -= cost;
                target.AddStatus(new Poison(amount, target));
                caster.me_body.Cast(0, null, target.me_body, () => { caster.attacking = false; });
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
