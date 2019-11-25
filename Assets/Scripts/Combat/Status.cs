using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe générique des status
public abstract class Status
{
    protected Character owner;
    public abstract void EffectStart();
    public abstract void EffectEnd();
}


// Poison inflige des dégâts à chaque fin de tour
public class Poison : Status
{
    private readonly int damage;

    public Poison(int d, Character target)
    {
        damage = d;
        owner = target;
    }

    public override void EffectStart()
    {

    }

    public override void EffectEnd()
    {
        owner.current_stats[0] -= damage;
        owner.me_body.Damage(owner.me_body, damage);
    }
}


// Etourdissement (passe le tour)
public class Stun : Status
{
    private int turn_remaining;

    public Stun(int t, Character target)
    {
        turn_remaining = t;
        owner = target;
    }

    public override void EffectEnd()
    {

    }

    public override void EffectStart()
    {
        if (turn_remaining > 0)
        {
            // Attention ! skip les autres effets au start !!! Pas bon
            turn_remaining -= 1;
            owner.EndTurn();
        }
        else
        {
            // owner.RemoveStatus(this);
        }
    }
}

// Régénération de pvs
public class Regeneration : Status
{
    private readonly int health_gain;
    private int turn_remaining;

    public Regeneration(int amount, int duration, Character target)
    {
        health_gain = amount;
        owner = target;
        turn_remaining = duration;
    }

    public override void EffectStart()
    {
        
    }

    public override void EffectEnd()
    {
        turn_remaining--;
        if (turn_remaining == 0)
            owner.RemoveStatus(this);
        else
            owner.current_stats[0] += health_gain;
    }
}
