using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour {
    public AudioClip soundDeath;
    public AudioClip soundDash;
    public AudioClip soundAttack;
    private static BattleHandler instance;

    public static BattleHandler GetInstance() {
        return instance;
    }


    [SerializeField] private Transform pfCharacterBattle;
    public Texture2D playerSpritesheet;
    public Texture2D enemySpritesheet;

    public int characterNumber; // player include
    private CharacterBattle[] characterBattle;
    private int activeIndice = 0;
    private CharacterBattle activeCharacterBattle;
    private State state;

    private enum State {
        WaitingForPlayer,
        Busy,
    }

    private void Awake() {
        instance = this;
    }

    private void Start() {
        characterBattle = new CharacterBattle[characterNumber];
        characterBattle[0] = SpawnCharacter(true, 0);
        for (int i=1; i < characterNumber; i++)
            characterBattle[i] = SpawnCharacter(false, i);

        SetActiveCharacterBattle(characterBattle[0]);
        state = State.WaitingForPlayer;
    }

    private void Update() {
        if (state == State.WaitingForPlayer) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                int i = 1;
                while (characterBattle[i].IsDead())
                    i++;
                state = State.Busy;
                characterBattle[0].Attack(10, characterBattle[i], () => {
                    ChooseNextActiveCharacter();
                });
                SoundManager.instance.RandomizeSfx(soundDash);
                SoundManager.instance.RandomizeSfx(soundAttack);

            }
        }
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

        return characterBattle;
    }

private void SetActiveCharacterBattle(CharacterBattle characterBattle) {
        if (activeCharacterBattle != null) {
            activeCharacterBattle.HideSelectionCircle();
        }

        activeCharacterBattle = characterBattle;
        activeCharacterBattle.ShowSelectionCircle();
    }

    private void ChooseNextActiveCharacter() {
        if (TestBattleOver()) {
            return;
        }

        do {
            activeIndice = (activeIndice + 1) % characterNumber;
        } while (characterBattle[activeIndice].IsDead());
        SetActiveCharacterBattle(characterBattle[activeIndice]);

        if (activeIndice != 0) {
            // debut atck
            state = State.Busy;
            
            characterBattle[activeIndice].Attack(10, characterBattle[0], () => {
                ChooseNextActiveCharacter();
            });
            SoundManager.instance.RandomizeSfx(soundDash);
            SoundManager.instance.RandomizeSfx(soundAttack);
            // fin atck
        } else {
            state = State.WaitingForPlayer;
        }
    }

    private bool TestBattleOver() {
        if (characterBattle[0].IsDead()) {
            // Player dead, enemy wins
            //CodeMonkey.CMDebug.TextPopupMouse("Enemy Wins!");
            // BattleOverWindow.Show_Static("Enemy Wins!");
            SoundManager.instance.RandomizeSfx(soundDeath);
            return true;
        }

        bool ennemiesDed = true;
        for (int i = 1; i < characterNumber; i++)
            ennemiesDed &= characterBattle[i].IsDead();
        if (ennemiesDed) {
            // Enemy dead, player wins
            //CodeMonkey.CMDebug.TextPopupMouse("Player Wins!");
            // BattleOverWindow.Show_Static("Player Wins!");
            SoundManager.instance.RandomizeSfx(soundDeath);
            return true;
        }

        return false;
    }
}
