using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

	public void Continue()
	{
		Debug.Log(" -- Continuer --");
	}

	public void NewGame()
	{
		Debug.Log(" -- Nouvelle partie --");
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
