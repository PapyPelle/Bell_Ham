using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trading : MonoBehaviour
{

    public GameObject achat =null;
    public GameObject vente = null;
    public GameObject boxDialog = null;
    public Sprite emptyInventoryCase = null;
    public Sprite emptyExchangeCase = null;
    public Sprite Or = null;

    public Sprite Attaque_basique = null; 
    public Sprite Boule_de_feu = null;
    public Sprite Flaque_de_poison = null;
    public Sprite Premier_soin = null;

    public Sprite [] Listsprites = null;
    public Button[] ListVentes = null;
    public Button[] ListAchat = null;

    public AudioClip confirm;
    public AudioClip cancel;
    public AudioClip aLaCaisse;


    // Start is called before the first frame update
    void Start()
    {
        ListVentes[0].transform.GetChild(0).GetComponent<Image>().sprite = Or;
        ListVentes[0].transform.GetChild(1).GetComponent<Text>().text = "0";
        for (int i =1; i<=3;i++)
        {
            //ListVentes[i].GetComponent<Image>().sprite = Listsprites[Random.Range(0, Listsprites.Length)];
           ListVentes[i].transform.GetChild(0).GetComponent<Image>().sprite = Listsprites[Random.Range(0, Listsprites.Length)];
            

        }
        /*
        Debug.Log("competence 1 : " + PlayerPrefs.GetString("comp1"));
        Debug.Log("competence 2 : " + PlayerPrefs.GetString("comp2"));
        Debug.Log("competence 3 : " + PlayerPrefs.GetString("comp3"));
        Debug.Log("competence 4 : " + PlayerPrefs.GetString("comp4"));*/

        for(int j = 1; j <= 4; j++)
        {
            string competence = "comp" + j;
 Debug.Log("sprite competence  "+j+" :" + PlayerPrefs.GetString(competence));
            switch (PlayerPrefs.GetString(competence))
            {
               
                case "Attaque basique":
                    ListAchat[j].transform.GetChild(0).GetComponent<Image>().sprite = Attaque_basique;
                    break;

                case "Boule de feu":
                    ListAchat[j].transform.GetChild(0).GetComponent<Image>().sprite = Boule_de_feu;
                    break;

                case "Flaque de poison":
                    ListAchat[j].transform.GetChild(0).GetComponent<Image>().sprite = Flaque_de_poison;
                    break;

                case "Premier soin":
                    ListAchat[j].transform.GetChild(0).GetComponent<Image>().sprite = Premier_soin;
                    break;


                default:
                    Debug.Log("competence not found");
                    ListAchat[j].transform.GetChild(0).GetComponent<Image>().sprite = Attaque_basique;
                    break;
            }

        }

        ListAchat[0].transform.GetChild(0).GetComponent<Image>().sprite = Or;
        ListAchat[0].transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt("GOLD").ToString();
        ListVentes[0].transform.transform.GetChild(1).GetComponent<Text>().text = "10";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void clickAchat(Button btn)
    {
        if (!achat.GetComponent<Image>().sprite.Equals(btn.transform.GetChild(0).GetComponent<Image>().sprite))
        {
            if (achat.GetComponent<Image>().sprite.Equals(emptyExchangeCase) || achat.GetComponent<Image>().sprite.Equals(Or))
            {
                Debug.Log("first Object Achat");
            }
            else
            {
                int i = 0;
                while (!ListVentes[i].transform.transform.GetChild(0).GetComponent<Image>().sprite.Equals(emptyInventoryCase))
                {
                    i++;
                    Debug.Log("i = " + i);
                }
                ListVentes[i].transform.GetChild(0).GetComponent<Image>().sprite = achat.GetComponent<Image>().sprite;

            }
            achat.GetComponent<Image>().sprite = btn.transform.GetChild(0).GetComponent<Image>().sprite;

            if (achat.GetComponent<Image>().sprite.Equals(Or))
            {
                achat.transform.GetChild(1).GetComponent<Text>().text = btn.transform.transform.GetChild(1).GetComponent<Text>().text;
                btn.transform.transform.GetChild(1).GetComponent<Text>().text = "0";
            }
            else
            {
                btn.transform.GetChild(0).GetComponent<Image>().sprite = emptyInventoryCase;
                achat.transform.transform.GetChild(1).GetComponent<Text>().text = "";
                ListVentes[0].transform.transform.GetChild(1).GetComponent<Text>().text = "10";
            }

        }
    }

    

    public void clickVente(Button btn)
    {
        if (!vente.GetComponent<Image>().sprite.Equals(btn.transform.GetChild(0).GetComponent<Image>().sprite))
        {
            if (vente.GetComponent<Image>().sprite.Equals(emptyExchangeCase) || vente.GetComponent<Image>().sprite.Equals(Or))
            {
                Debug.Log("first Object Vente");
            }
            else
            {
                int i = 0;
                while (!ListAchat[i].transform.GetChild(0).GetComponent<Image>().sprite.Equals(emptyInventoryCase))
                {
                    i++;
                    Debug.Log("i = " + i);
                }
                ListAchat[i].transform.GetChild(0).GetComponent<Image>().sprite = vente.GetComponent<Image>().sprite;

            }
            vente.GetComponent<Image>().sprite = btn.transform.GetChild(0).GetComponent<Image>().sprite;

            if (vente.GetComponent<Image>().sprite.Equals(Or))
            {
                vente.transform.transform.GetChild(1).GetComponent<Text>().text = btn.transform.transform.GetChild(1).GetComponent<Text>().text;
                btn.transform.transform.GetChild(1).GetComponent<Text>().text = "0";

            }
            else
            {
                btn.transform.GetChild(0).GetComponent<Image>().sprite = emptyInventoryCase;
                vente.transform.transform.GetChild(1).GetComponent<Text>().text = "";
                ListAchat[0].transform.transform.GetChild(1).GetComponent<Text>().text = "10";
            }
        }

    }


    

    public void clickQuit(GameObject canvas)
    {
        boxDialog.SetActive(true);
        canvas.SetActive(false);
        SoundManager.instance.RandomizeSfx(cancel);

    }

    public void ValidAchat()
    {
        if(vente.GetComponent<Image>().sprite.Equals(emptyExchangeCase) && achat.GetComponent<Image>().sprite.Equals(emptyExchangeCase))
        {
            SoundManager.instance.RandomizeSfx(cancel);  // son d'erreur
        }
        else // transacion autorisé
        {

            int i = 0;
            if (achat.GetComponent<Image>().sprite.Equals(Or)){ // si on echange de l'or
                ListAchat[0].transform.transform.GetChild(1).GetComponent<Text>().text = ""+ (System.Int32.Parse(ListAchat[0].transform.transform.GetChild(1).GetComponent<Text>().text) + System.Int32.Parse(achat.transform.transform.GetChild(1).GetComponent<Text>().text)).ToString();
                achat.transform.transform.GetChild(1).GetComponent<Text>().text = "";
            }
            else {
                i = 0;
                while (!ListAchat[i].transform.GetChild(0).GetComponent<Image>().sprite.Equals(emptyInventoryCase))
                {
                    i++;
                    Debug.Log("i = " + i);
                }
                ListAchat[i].transform.GetChild(0).GetComponent<Image>().sprite = achat.GetComponent<Image>().sprite;
            }
            if (vente.GetComponent<Image>().sprite.Equals(Or)){// si on echange de l'or
                ListVentes[0].transform.transform.GetChild(1).GetComponent<Text>().text = "" + (System.Int32.Parse(ListVentes[0].transform.transform.GetChild(1).GetComponent<Text>().text) + System.Int32.Parse(vente.transform.transform.GetChild(1).GetComponent<Text>().text)).ToString();
                vente.transform.transform.GetChild(1).GetComponent<Text>().text = "";
            }
            else
            {
                i = 0;
                while (!ListVentes[i].transform.GetChild(0).GetComponent<Image>().sprite.Equals(emptyInventoryCase))
                {
                    i++;
                    Debug.Log("i = " + i);
                }
                ListVentes[i].transform.GetChild(0).GetComponent<Image>().sprite = vente.GetComponent<Image>().sprite;
            }
            // flush exchange
            achat.GetComponent<Image>().sprite = emptyInventoryCase;
        vente.GetComponent<Image>().sprite = emptyInventoryCase;
            vente.transform.transform.GetChild(1).GetComponent<Text>().text = "";
            SoundManager.instance.RandomizeSfx(aLaCaisse);
        }


       
    }
}
