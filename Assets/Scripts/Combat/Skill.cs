using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe générique pour les compétences
public class Skill // : MonoBehaviour
{
    // Cout de lancement
    public int cost;
    // Type de stat consommée (potentiellement inutile : heritage)
    public int cast_type;

    public int damage;

    public virtual bool IsCastable(Character caster)
    {
        return (caster.current_stats[cast_type] >= cost);
    }

    public virtual bool IsValidTarget(Character caster, Character target)
    {
        return target.is_alive;
    }

    public virtual void Activate(Character caster, Character target)
    {
        if (target != null && IsValidTarget(caster, target))
        {
            target.current_stats[0] -= damage;
        }
        caster.current_stats[cast_type] -= cost;    
    }

}
