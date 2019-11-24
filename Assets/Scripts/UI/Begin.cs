using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Begin : MonoBehaviour
{

	public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onClick() {
        SoundManager.instance.RandomizeSfx(click);

        if (GameObject.Find("Canvas").GetComponent<BookPopup>().comp1 == 1 &&
            GameObject.Find("Canvas").GetComponent<BookPopup>().comp2 == 1 &&
            GameObject.Find("Canvas").GetComponent<BookPopup>().comp3 == 1 &&
            GameObject.Find("Canvas").GetComponent<BookPopup>().comp4 == 1 &&
            GameObject.Find("Canvas/CanvasCharacteristics").GetComponent<CharacterCreationMenuUI>().v_left == 0)
        {
            SceneManager.LoadScene("Map");
        } 
    }
}
