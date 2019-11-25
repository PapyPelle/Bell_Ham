using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbPlayer : Character
{
    // appelé régulièrement dans update
    public override void TakeTurn()
    {
        if (attacking)
            return;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Me player cast spell SLAM");
            list_of_skills[0].Activate(this, GetTarget());
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Me player cast spell FIREBALL");
            list_of_skills[1].Activate(this, GetTarget());
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Me player cast spell POISONMIST");
            list_of_skills[2].Activate(this, GetTarget());
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Me player cast spell HEAL");
            list_of_skills[3].Activate(this, this);
        }
        else if (Input.GetKeyDown(KeyCode.T))
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
        list_of_skills[1] = new FireBall();
        list_of_skills[2] = new PoisonMist();
        list_of_skills[3] = new Heal();
    }

    private Character GetTarget()
    {
        int i = 1;
        while (i < combat.fighter_list.Length && combat.fighter_list[i].is_alive == false)
            i++;
        if (i >= combat.fighter_list.Length)
            return null;
        return combat.fighter_list[i];
    }
}
