using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnMainMenu : MonoBehaviour
{

    public AudioClip music;

    public void returnMain() {
		SoundManager.instance.RandomizeSfx(music);
        Debug.Log(" -- LoadMenu --");
        SceneManager.LoadScene("MainMenu");
        
    }
}
