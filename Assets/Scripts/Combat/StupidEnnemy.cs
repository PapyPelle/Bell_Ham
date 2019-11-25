using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidEnnemy : Character
{
    protected override void GetCharacterInfo()
    {
        // Get values from ennemy type
        /*max_life = 20;
        max_energy = 10;
        max_mana = 0;*/
        list_of_skills[0] = new Slam();
        list_of_skills[1] = new PowerStrike();
    }
    
    public override void TakeTurn()
    {
        if (attacking)
            return;
        if (current_stats[1] < 30)
        {
            EndTurn();
            return;
        }
            
        if (Random.Range(0,20) <= 1.0)
        {
            Debug.Log("MONSTER STUN YOU");
            list_of_skills[1].Activate(this, ChoseTarget());
        }
        else
        {
            list_of_skills[0].Activate(this, ChoseTarget());
            Debug.Log("MONSTER SLAM");
        }
        
        EndTurn();
    }
 
    private Character ChoseTarget()
    {
        return combat.PlayerCharacter();
    }
}
