using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidEnnemy : Character
{
    protected override void GetCharacterInfo()
    {
        max_life = 20;
        max_energy = 10;
        max_mana = 0;
        list_of_skills[0] = new Slam();
    }
    
    protected override void TakeTurn()
    {
       // list_of_skills[0].Activate(this, ChoseTarget());
    }
    /*
    private Character ChoseTarget()
    {

    }
    */

}
