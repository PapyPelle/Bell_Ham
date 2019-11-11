using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : Skill
{
    public Slam()
    {
        damage = 10;
        cost = 30;
        cast_type = 1; // 1 : energy
    }

    public override bool IsCastable(Character caster)
    {
        // Inutile mais c'est pour l'exemple, si on veut d'autres conditions
        return base.IsCastable(caster);
    }
    public override void Activate(Character caster, Character target)
    {
        if (IsCastable(caster))
        {
            if (target != null && IsValidTarget(caster, target))
            {
                base.Activate(caster, target);
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
