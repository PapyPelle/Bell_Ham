using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Character
{
    private int current_spell = 0;
    private bool attack = false;

    public BarControl energyBarControl;
    public BarControl manaBarControl;

    // le son du click
    public AudioClip capacitySelectSound;


    protected override void GetCharacterInfo()
    {
        max_life = PlayerPrefs.GetInt("PV", 100);
        max_energy = PlayerPrefs.GetInt("ENERGIE", 100);
        max_mana = PlayerPrefs.GetInt("MANA", 100);
        for (int i = 0; i < 4; i++)
            list_of_skills[i] = SetUpSpell(PlayerPrefs.GetString("comp" + (i+1).ToString(), ""));
        energyBarControl.SetBar(1);
        manaBarControl.SetBar(1);
    }

    public override void TakeTurn()
    {
        energyBarControl.SetBar((float)current_stats[1] / (float)max_energy);
        manaBarControl.SetBar((float)current_stats[2] / (float)max_mana);
        if (attack)
        {
            if (list_of_skills[current_spell] != null)
            {
                list_of_skills[current_spell].Activate(this, combat.fighter_list[target]);
            }
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
       
        SoundManager.instance.RandomizeSfx(capacitySelectSound);
    }

    public void Attack()
    {
        attack = true;
    }


}
