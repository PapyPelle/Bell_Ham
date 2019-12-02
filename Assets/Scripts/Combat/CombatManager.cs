using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // ----------- donée de l'animation --------------
    public AudioClip soundDeath;
    public AudioClip soundDash;
    public AudioClip soundAttack;
    private static CombatManager instance;
    public AudioClip characterSelectSound;


    public static CombatManager GetInstance()
    {
        return instance;
    }


    [SerializeField] private Transform pfCharacterBattle;
    public Texture2D playerSpritesheet;
    public Texture2D enemySpritesheet;

    private void Awake()
    {
        instance = this;
    }

    // ------------------------------------------------

    // Liste des combattants et indice du tour
    public Character[] fighter_list;
    private int current_fighter = 0;
    private int player_i = 0;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Character c in fighter_list)
            c.combat = this;
        // Au début du combat, on décide de l'ordre d'action
        SortFighters();
        // On instantie le corps anime
        fighter_list[0].me_body = SpawnCharacter(true, 0);
        fighter_list[0].gameObject.transform.position = fighter_list[0].me_body.gameObject.transform.position;
        fighter_list[0].my_number = 0;
        for (int i=1; i < fighter_list.Length; i++)
        {
            fighter_list[i].me_body = SpawnCharacter(false, i);
            fighter_list[i].gameObject.transform.position = fighter_list[i].me_body.gameObject.transform.position;
            fighter_list[i].my_number = i;
        }

        // Lance le combat
        fighter_list[0].me_body.ShowSelectionCircle();
        fighter_list[0].StartTurn();
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
        int combat_result = CheckEndOfCombat();
        if (combat_result != 0)
        {
            EndFight(combat_result == 1);
        }
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
        if (fighter_list[current_fighter].is_alive)
        {
            fighter_list[current_fighter].StartTurn();
        }
     
    }


    /**
     * Vérifie si le combat est fini
     */
    private int CheckEndOfCombat()
    {
        // Si le joueur est mort : -1
        if (!fighter_list[player_i].is_alive)
        {
            return -1;
        }
        // Si un ennemi est vivant (et donc joueur aussi) : 0
        foreach (Character c in fighter_list)
        {
            if (c != fighter_list[player_i] && c.is_alive)
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

    private CharacterBattle SpawnCharacter(bool isPlayerTeam, int i)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(-50, 0);
        }
        else
        {
            position = new Vector3(+50, -60 + i * 25);
        }
        Transform characterTransform = Instantiate(pfCharacterBattle, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
        characterBattle.Setup(isPlayerTeam, fighter_list[i]);

        return characterBattle; 
    }
}
