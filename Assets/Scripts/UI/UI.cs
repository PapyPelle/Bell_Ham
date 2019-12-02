using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{


	public GameObject InventoryPanel;
	public GameObject DescriptionEq1;
	public GameObject DescriptionEq2;


	int description1AFF = 0;
	int description2AFF = 0;



    public GameObject c1;
	public GameObject c2;
	public GameObject c3;
	public GameObject c4;
	public GameObject ci1;
	public GameObject ci2;
	public GameObject ci3;
	public GameObject ci4;

	public Sprite feu;
	public Sprite attaque;
	public Sprite poison;
	public Sprite soin;

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.SetActive(false);
        DescriptionEq1.SetActive(false);
        DescriptionEq2.SetActive(false);
        SetComp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickInventory() {
    	InventoryPanel.SetActive(true);
    	Debug.Log("test");
    }
    public void OnQuitInventory() {
    	InventoryPanel.SetActive(false);
    	DescriptionEq1.SetActive(false);
        DescriptionEq2.SetActive(false);
    }

    public void clickDescription1() {
    	if (description1AFF==1) {
			DescriptionEq1.SetActive(false);
			description1AFF = 0;
		} else {
			DescriptionEq2.SetActive(false);
			description2AFF = 0;
			DescriptionEq1.SetActive(true);
			description1AFF = 1;
		}
    }

    public void clickDescription2() {
    	if (description2AFF==1) {
			DescriptionEq2.SetActive(false);
			description2AFF = 0;
		} else {
			DescriptionEq1.SetActive(false);
			description1AFF = 0;
			DescriptionEq2.SetActive(true);
			description2AFF = 1;
		}
    }

    void SetComp() {
		string comp1 = PlayerPrefs.GetString("comp1", "1");
	    string comp2 = PlayerPrefs.GetString("comp2", "2");
	    string comp3 = PlayerPrefs.GetString("comp3", "3");
	    string comp4 = PlayerPrefs.GetString("comp4", "4");

	    Image imgC1, imgC2, imgC3, imgC4, imgCi1, imgCi2, imgCi3, imgCi4;

		imgC1 = c1.GetComponent<Image>();
		imgC2 = c2.GetComponent<Image>();
		imgC3 = c3.GetComponent<Image>();
		imgC4 = c4.GetComponent<Image>();

		imgCi1 = ci1.GetComponent<Image>();
		imgCi2 = ci2.GetComponent<Image>();
		imgCi3 = ci3.GetComponent<Image>();
		imgCi4 = ci4.GetComponent<Image>();

		if (comp1=="Attaque basique") {
			imgC1.sprite = attaque;
		} else if (comp1=="Boule de feu") {
			imgC1.sprite = feu;
		} else if (comp1=="Flaque de poison") {
			imgC1.sprite = poison;
		} else if (comp1=="Premier soin") {
			imgC1.sprite = soin;
		}

		if (comp2=="Attaque basique") {
			imgC2.sprite = attaque;
		} else if (comp2=="Boule de feu") {
			imgC2.sprite = feu;
		} else if (comp2=="Flaque de poison") {
			imgC2.sprite = poison;
		} else if (comp2=="Premier soin") {
			imgC2.sprite = soin;
		}

		if (comp3=="Attaque basique") {
			imgC3.sprite = attaque;
		} else if (comp3=="Boule de feu") {
			imgC3.sprite = feu;
		} else if (comp3=="Flaque de poison") {
			imgC3.sprite = poison;
		} else if (comp3=="Premier soin") {
			imgC3.sprite = soin;
		}

		if (comp4=="Attaque basique") {
			imgC4.sprite = attaque;
		} else if (comp4=="Boule de feu") {
			imgC4.sprite = feu;
		} else if (comp4=="Flaque de poison") {
			imgC4.sprite = poison;
		} else if (comp4=="Premier soin") {
			imgC4.sprite = soin;
		}

		if (comp1=="Attaque basique") {
			imgCi1.sprite = attaque;
		} else if (comp1=="Boule de feu") {
			imgCi1.sprite = feu;
		} else if (comp1=="Flaque de poison") {
			imgCi1.sprite = poison;
		} else if (comp1=="Premier soin") {
			imgCi1.sprite = soin;
		}

		if (comp2=="Attaque basique") {
			imgCi2.sprite = attaque;
		} else if (comp2=="Boule de feu") {
			imgCi2.sprite = feu;
		} else if (comp2=="Flaque de poison") {
			imgCi2.sprite = poison;
		} else if (comp2=="Premier soin") {
			imgCi2.sprite = soin;
		}

		if (comp3=="Attaque basique") {
			imgCi3.sprite = attaque;
		} else if (comp3=="Boule de feu") {
			imgCi3.sprite = feu;
		} else if (comp3=="Flaque de poison") {
			imgCi3.sprite = poison;
		} else if (comp3=="Premier soin") {
			imgCi3.sprite = soin;
		}

		if (comp4=="Attaque basique") {
			imgCi4.sprite = attaque;
		} else if (comp4=="Boule de feu") {
			imgCi4.sprite = feu;
		} else if (comp4=="Flaque de poison") {
			imgCi4.sprite = poison;
		} else if (comp4=="Premier soin") {
			imgCi4.sprite = soin;
		}



		

    }
}
