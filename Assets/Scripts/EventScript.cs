using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{
   
    public AudioClip confirm;
    public AudioClip cancel;
    /* public AudioClip music;

    public GameObject canvas; // this*/
    public GameObject BoxDialog,TextDialog;
    // Start is called before the first frame update
    void Start()
    {
        string text="";

        switch(Random.Range(0, 2))
        {
            case 0:
                text = "Encore un pigeon a plumer ! ";
                break;
            case 1:
                text = "Bonjour étranger, serais tu interessés par quelques potions ? ! ";
                break;

            case 2:
                text = "Interessé par quelques choses ? ";
                break;


        }
        TextDialog.transform.GetComponent<Text>().text = text;//Changing text
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void btnYes()
    {
        SoundManager.instance.RandomizeSfx(confirm);
        BoxDialog.SetActive(false);

    }
    public void btnNo()
    {
        SoundManager.instance.RandomizeSfx(cancel);
        SceneManager.LoadScene("Map");
    }
}
