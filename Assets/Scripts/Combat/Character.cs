using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe des entité combattantes (joueur et ennemis)
// Heritage : protected override void TakeTurn() and GetCharacterInfo()
public abstract class Character : MonoBehaviour
{
    // D'autres effets que la vie < 0 peuvent causer la mort, donc on garde un bool
    public bool is_alive = true;

    // Les 3 stats de base ("readonly", mais pas vrmnt parce qu'on veut les sets)
    public int max_life;
    public int max_energy;
    public int max_mana;
    // Variables
    public int[] current_stats = new int[3];

    // Savoir si l'on peut agir
    public bool my_turn = false;
    public bool attacking = false;
    public int target = 0;
    public int my_number;

    // Combat en cours
    public CombatManager combat;

    // Les spells disponibles
    public Skill[] list_of_skills = new Skill[4];

    // Les status affectant le joueur
    public List<Status> status = new List<Status>();
    

    // truc pas propre pour accèder au corps anime
    public CharacterBattle me_body;

    // -- Fonctions à override -- //

    /**
     * Récupère les infos actuelles de vie/mana/stamina, spells etc.
     * pour l'instanciation du combattant
     */
    protected abstract void GetCharacterInfo();

    // Effectue son action du tour (ennemi = ai, joueur = inputs)
    public abstract void TakeTurn();

    // -- -------------------- -- //


    /**
     * Appelée avant la première frame
     */
    void Start()
    {
        // Obtenir les infos sur le mob
        // Obtenir les infos sur l'état du joueur
        GetCharacterInfo();
        current_stats[0] = max_life;
        current_stats[1] = max_energy;
        current_stats[2] = max_mana;
    }
        

    /**
     * Appelée à chaque frame
     */
    void Update()
    {
        // Vérifie si on est mort par dégâts
        if (is_alive && current_stats[0] <= 0)
        {
            is_alive = false;
        }
        // Vérifie si on doit jouer
        if (my_turn && !attacking)
        {
            if (!is_alive)
            {
                my_turn = false;
                // Et non "endturn" car plus aucun effet ne s'applique, et le mana/energy ne remontent plus
                // On ne veut pas qu'un ennemi sous buff regen voit sa vie repasser > 0
            }
            else
            {
                TakeTurn();
            }
        }
    }

    public void StartTurn()
    {
        if (!is_alive)
            return;
        me_body.ShowSelectionCircle();
        my_turn = true;
        foreach (Status s in status)
        {
            s.EffectStart();
        }
               
    }


    /**
     * Termine le tour du combattant (récup energies et application d'effet ??)
     */
    public void EndTurn()
    {
        if (attacking)
            return;
        foreach (Status s in status)
        {
            s.EffectEnd();
        }
        me_body.HideSelectionCircle();
        // foreach(affectation on me) affectation.affect(me); ?
        Debug.Log(gameObject.name + " end turn, stats (" + current_stats[0] + "," + current_stats[1] + "," + current_stats[2] + ")");
        current_stats[1] = max_energy;
        current_stats[2] = max_mana;
        my_turn = false;
    }


    public void AddStatus(Status s)
    {
        status.Add(s);
    }

    public void RemoveStatus(Status s)
    {
        status.Remove(s);
    }

    private void OnMouseDown()
    {
        if (is_alive)
        {
            combat.fighter_list[combat.PlayerCharacter().target].me_body.HideSelectionCircleSpell();
            combat.PlayerCharacter().target = my_number;
            me_body.ShowSelectionCircleSpell();
            //SoundManager.RandomizeSfx(combat.characterSelectSound);
        }
    }

}
