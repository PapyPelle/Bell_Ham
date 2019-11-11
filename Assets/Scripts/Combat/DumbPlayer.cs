using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbPlayer : Character
{
    // appelé régulièrement dans update
    protected override void TakeTurn()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Me player cast SLAM");
            list_of_skills[0].Activate(this, combat.fighter_list[1]);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            EndTurn();
        }
    }

    protected override void GetCharacterInfo()
    {
        // get values from player stats
/*        max_life = 30;
        max_energy = 10;
        max_mana = 10;*/
        list_of_skills[0] = new Slam();
    }
}
