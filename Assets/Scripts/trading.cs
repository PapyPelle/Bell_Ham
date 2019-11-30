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

    public Sprite [] Listsprites = null;
    public Button[] ListVentes = null;
    public Button[] ListAchat = null;

    public AudioClip confirm;
    public AudioClip cancel;
    public AudioClip aLaCaisse;


    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i< 3;i++)
        {
            //ListVentes[i].GetComponent<Image>().sprite = Listsprites[Random.Range(0, Listsprites.Length)];
           ListVentes[i].transform.GetChild(1).GetComponent<Image>().sprite = Listsprites[Random.Range(0, Listsprites.Length)];
           
        }

        ListAchat[0].transform.GetChild(1).GetComponent<Image>().sprite = Or;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void clickAchat(Button btn)
    {
        if (achat.GetComponent<Image>().sprite.Equals(emptyExchangeCase))
        {
            Debug.Log("first Object Achat");
        }
        else
        {
            int i = 0;
            while (!ListVentes[i].transform.GetChild(1).GetComponent<Image>().sprite.Equals(emptyInventoryCase))
            {
                i++;
                Debug.Log("i = "+i);
            }
            ListVentes[i].transform.GetChild(1).GetComponent<Image>().sprite = achat.GetComponent<Image>().sprite;

        }
        achat.GetComponent<Image>().sprite = btn.transform.GetChild(1).GetComponent<Image>().sprite;
        btn.transform.GetChild(1).GetComponent<Image>().sprite = emptyInventoryCase;
        
      
        
    }

    public void clickVente(Button btn)
    {
        if (vente.GetComponent<Image>().sprite.Equals(emptyExchangeCase))
        {
            Debug.Log("first Object Vente");
        }
        else
        {
            int i = 0;
            while (!ListAchat[i].transform.GetChild(1).GetComponent<Image>().sprite.Equals(emptyInventoryCase))
            {
                i++;
                Debug.Log("i = " + i);
            }
            ListAchat[i].transform.GetChild(1).GetComponent<Image>().sprite = vente.GetComponent<Image>().sprite;

        }
        vente.GetComponent<Image>().sprite = btn.transform.GetChild(1).GetComponent<Image>().sprite;
        btn.transform.GetChild(1).GetComponent<Image>().sprite = emptyInventoryCase;

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
            while (!ListAchat[i].transform.GetChild(1).GetComponent<Image>().sprite.Equals(emptyInventoryCase))
            {
                i++;
                Debug.Log("i = " + i);
            }
            ListAchat[i].transform.GetChild(1).GetComponent<Image>().sprite = achat.GetComponent<Image>().sprite;

            // flush exchange
            achat.GetComponent<Image>().sprite = emptyInventoryCase;
        vente.GetComponent<Image>().sprite = emptyInventoryCase;
            SoundManager.instance.RandomizeSfx(aLaCaisse);
        }


       
    }
}
