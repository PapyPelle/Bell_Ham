using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Character
{
    int current_spell = 0;
    int current_target = 0;

    protected override void GetCharacterInfo()
    {
        max_life = PlayerPrefs.GetInt("PV", 100);
        max_energy = PlayerPrefs.GetInt("ENERGIE", 100);
        max_mana = PlayerPrefs.GetInt("MANA", 100);
        for (int i = 0; i < 4; i++)
            list_of_skills[i] = SetUpSpell(PlayerPrefs.GetString("comp" + i.ToString(), ""));
    }

    public override void TakeTurn()
    {

    }

    private Skill SetUpSpell(string s)
    {
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

    private int SelectSpell()
    {
        return 0;
    }

    private int SelectTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));
            if (hitCollider != null && hitCollider.CompareTag("Player"))
            {
                Debug.Log("This is player");
            }
        }
        return 0;
    }

}
