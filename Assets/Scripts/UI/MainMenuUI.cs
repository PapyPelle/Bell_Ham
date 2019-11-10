using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{

	public void Continue()
	{
		Debug.Log(" -- Continuer --");
	}

	public void NewGame()
	{
		SceneManager.LoadScene("CharacterCreationMenu");
	}

	public void Options()
	{
		Debug.Log(" -- Options --");
	}

    public void Quit()
    {
    	Debug.Log(" -- Quitter --");
        Application.Quit();
    }
}
