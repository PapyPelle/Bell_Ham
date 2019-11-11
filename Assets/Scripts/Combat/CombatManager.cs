using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // Liste des combattants et indice du tour
    public Character[] fighter_list;
    public int current_fighter = 0;
    public int player_i = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Au début du combat, on décide de l'ordre d'action
        SortFighters();
        fighter_list[0].my_turn = true;
    }


    // Update is called once per frame
    void Update()
    {
        // Si le tour actuel vient de se terminer, on change
        if (fighter_list[current_fighter].my_turn == false)
        {
            NextFighter();
        }
        // Si le combat est fini, on termine
/*        int combat_result = CheckEndOfCombat();
        if (combat_result != 0)
        {
            EndFight(combat_result == 1);
        }*/
    }


    // Trie les combattants selon un ordre défini
    // Pour l'instant, on fait jouer le joueur en premier (on pourrait imaginer une "initiative")
    private void SortFighters()
    {
        for(int i=0; i < fighter_list.Length; i++)
        {
            if (fighter_list[i].gameObject.CompareTag("Player"))
            {
                if (i != 0)
                {
                    Character tmp = fighter_list[0];
                    fighter_list[0] = fighter_list[i];
                    fighter_list[i] = tmp;
                    player_i = 0;
                }
                break;
            }
        }
    }


    /**
     * Cherche le prochain combattant et active son tour
     */
    private void NextFighter()
    {
        current_fighter = (current_fighter + 1) % fighter_list.Length;
        fighter_list[current_fighter].my_turn = true;
    }


    /**
     * Vérifie si le combat est fini
     */
    private int CheckEndOfCombat()
    {
        // Si le joueur est mort : -1
        if (fighter_list[player_i].gameObject.CompareTag("Player") && !fighter_list[player_i].is_alive)
        {
            return -1;
        }
        // Si un ennemi est vivant (et donc joueur aussi) : 0
        foreach (Character c in fighter_list)
        {
            if (!c.gameObject.CompareTag("Player") && c.is_alive)
            {
                return 0;
            }
        }
        // Si aucun ennemi vivant : 1
        return 1;
    }

    /**
     * Termine le combat et résout (game over ou victory screen)
     */
    public void EndFight(bool playerAlive)
    {
        if (playerAlive)
        {
            Debug.Log(" === PLAYER WINS === ");
        }
        else
        {
            Debug.Log(" === PLAYER LOSE === ");
        }
    }


    /**
     * Renvoie le joueur dans le combats (pour les cibles)
     */
    public Character PlayerCharacter()
    {
        return fighter_list[player_i];
    }

}
