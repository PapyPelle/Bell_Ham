﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : Skill
{
    public Slam()
    {
        amount = 10;
        cost = 30;
        cast_type = (int) CastType.energy;
    }

    public override bool IsCastable(Character caster)
    {
        // Inutile mais c'est pour l'exemple, si on veut d'autres conditions
        return base.IsCastable(caster);
    }

    public override bool IsValidTarget(Character caster, Character target)
    {
        if (target == null)
            return false;
        return base.IsValidTarget(caster, target);
    }

    public override void Activate(Character caster, Character target)
    {
        if (IsCastable(caster))
        {
            if (target != null && IsValidTarget(caster, target))
            {
                caster.attacking = true;
                caster.current_stats[cast_type] -= cost;
                // Le critique multiplicatif
                int mult_crit = 1;
                if (Random.Range(0, 20) <= 1.0) // 5%
                    mult_crit = 2;
                // Application des dégâts
                target.current_stats[(int)CastType.life] -= amount * mult_crit;
                caster.me_body.Attack(amount * mult_crit, target.me_body, () => { caster.attacking = false; });
            }
            else
            {
                Debug.Log(caster.name + " have no valid target");
            }
        }
        else
        {
            Debug.Log(caster.name + " can't cast this");
        }
    }

}
