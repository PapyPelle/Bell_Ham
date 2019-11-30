using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Begin : MonoBehaviour
{

	public AudioClip click;

    public GameObject CON;
    public GameObject FOR;
    public GameObject MAG;
    public GameObject MEM;
    public GameObject AGI;


    public GameObject comp1;
    public GameObject comp2;
    public GameObject comp3;
    public GameObject comp4;

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

            //SAVE
            PlayerPrefs.SetInt("CON", int.Parse(CON.GetComponent<UnityEngine.UI.Text>().text));
            PlayerPrefs.SetInt("FOR", int.Parse(FOR.GetComponent<UnityEngine.UI.Text>().text));
            PlayerPrefs.SetInt("MAG", int.Parse(MAG.GetComponent<UnityEngine.UI.Text>().text));
            PlayerPrefs.SetInt("MEM", int.Parse(MEM.GetComponent<UnityEngine.UI.Text>().text));
            PlayerPrefs.SetInt("AGI", int.Parse(AGI.GetComponent<UnityEngine.UI.Text>().text));

            PlayerPrefs.SetString("comp1", comp1.GetComponent<UnityEngine.UI.Text>().text);
            PlayerPrefs.SetString("comp2", comp2.GetComponent<UnityEngine.UI.Text>().text);
            PlayerPrefs.SetString("comp3", comp3.GetComponent<UnityEngine.UI.Text>().text);
            PlayerPrefs.SetString("comp4", comp4.GetComponent<UnityEngine.UI.Text>().text);

            PlayerPrefs.SetInt("PV", 100+(int.Parse(CON.GetComponent<UnityEngine.UI.Text>().text)*3));
            PlayerPrefs.SetInt("ENERGIE", 100+(int.Parse(AGI.GetComponent<UnityEngine.UI.Text>().text)*3));
            PlayerPrefs.SetInt("MANA", 100+(int.Parse(MEM.GetComponent<UnityEngine.UI.Text>().text)*3));

            PlayerPrefs.SetInt("GOLD", 10);

            PlayerPrefs.Save();

            SceneManager.LoadScene("Map");
        } 
    }
}
