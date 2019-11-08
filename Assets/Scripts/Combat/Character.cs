using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe des entité combattantes (joueur et ennemis)
// Heritage : protected override void TakeTurn() and GetCharacterInfo()
public abstract class Character : MonoBehaviour
{
    // Nom pour le débug ou une boite de display de l'attaque
    public string name_display; // Similaire à "gameobject.name" ?

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

    // Les spells disponibles
    public Skill[] list_of_skills = new Skill[4];


    // -- Fonctions à override -- //

    /**
     * Récupère les infos actuelles de vie/mana/stamina, spells etc.
     * pour l'instanciation du combattant
     */
    protected abstract void GetCharacterInfo();

    // Effectue son action du tour (ennemi = ai, joueur = inputs)
    protected abstract void TakeTurn();

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
        if (my_turn)
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


    /**
     * Termine le tour du combattant (récup energies et application d'effet ??)
     */
    private void EndTurn()
    {
        // foreach(affectation on me) affectation.affect(me); ?
        Debug.Log(name_display + "end turn");
        my_turn = false;
        current_stats[1] = max_energy;
        current_stats[2] = max_mana;
    }


}
