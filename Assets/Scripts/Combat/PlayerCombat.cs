using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Character
{
    public int current_spell = 0;
    public bool attack = false;

    protected override void GetCharacterInfo()
    {
        max_life = PlayerPrefs.GetInt("PV", 100);
        max_energy = PlayerPrefs.GetInt("ENERGIE", 100);
        max_mana = PlayerPrefs.GetInt("MANA", 100);
        for (int i = 0; i < 4; i++)
            list_of_skills[i] = SetUpSpell(PlayerPrefs.GetString("comp" + (i+1).ToString(), ""));
    }

    public override void TakeTurn()
    {
        if (attack)
        {
            if (list_of_skills[current_spell] != null)
                list_of_skills[current_spell].Activate(this, combat.fighter_list[target]);
            else
                Debug.Log("The spell isn't correctly set");
            attack = false;
        }
            
    }

    private Skill SetUpSpell(string s)
    {
        Debug.Log("setting up : " + s);
        if (string.Compare(s, "Attaque basique") == 0)
            return new Slam();
        else if (string.Compare(s, "Boule de feu") == 0)
            return new FireBall();
        else if (string.Compare(s, "Flaque de poison") == 0)
            return new PoisonMist();
        else if (string.Compare(s, "Premier soin") == 0)
            return new Heal();
        return null;

    }

    public void SelectSpell(int i)
    {
        current_spell = i;
    }

    public void Attack()
    {
        attack = true;
    }


}
