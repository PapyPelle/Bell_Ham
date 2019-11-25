using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public AudioClip confirm;
 
    public AudioClip music;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start maps scene ");
        SoundManager.instance.PlaySingle(music);

    }

    public void Continue()
	{
        
        Debug.Log(" -- Continuer --");
        SoundManager.instance.RandomizeSfx(confirm);
      
    }

	public void NewGame()
	{
		SceneManager.LoadScene("CharacterCreationMenu");
        SoundManager.instance.RandomizeSfx(confirm);
    }

	public void Options()
	{
		Debug.Log(" -- Options --");
        SoundManager.instance.RandomizeSfx(confirm);
    }

    public void Quit()
    {
    	Debug.Log(" -- Quitter --");
        SoundManager.instance.RandomizeSfx(confirm);
        Application.Quit();
    }
}
