using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPopup : MonoBehaviour
{

	public GameObject popup;

	int num_capacity;


	

	public GameObject c1 = null;
	public GameObject c2 = null;
	public GameObject c3 = null;
	public GameObject c4 = null;

	public GameObject c1t = null;
	public GameObject c2t = null;
	public GameObject c3t = null;
	public GameObject c4t = null;

	public int comp1 = 0;
	public int comp2 = 0;
	public int comp3 = 0;
	public int comp4 = 0;

	Image img;
	Text txt;

	public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void capacity1() {
    	popup.SetActive(true);
    	num_capacity = 1;
    	SoundManager.instance.RandomizeSfx(click);
    }
    public void capacity2() {
    	popup.SetActive(true);
    	num_capacity = 2;
    	SoundManager.instance.RandomizeSfx(click);
    }
    public void capacity3() {
    	popup.SetActive(true);
    	num_capacity = 3;
    	SoundManager.instance.RandomizeSfx(click);
    }
    public void capacity4() {
    	popup.SetActive(true);
    	num_capacity = 4;
    	SoundManager.instance.RandomizeSfx(click);
    }


    public void SetCapacity(GameObject go) {
    	//vérification compétence déjà prise
    	if (c1.GetComponent<Image>().sprite == go.GetComponent<Image>().sprite)
    	{
    		SoundManager.instance.RandomizeSfx(click);
    	}
    	else if (c2.GetComponent<Image>().sprite == go.GetComponent<Image>().sprite)
    	{
    		SoundManager.instance.RandomizeSfx(click);
    	}
    	else if (c3.GetComponent<Image>().sprite == go.GetComponent<Image>().sprite)
    	{
    		SoundManager.instance.RandomizeSfx(click);
    	}
    	else if (c4.GetComponent<Image>().sprite == go.GetComponent<Image>().sprite)
    	{
    		SoundManager.instance.RandomizeSfx(click);
    	}
    	else
    	{
	    	popup.SetActive(false);
	    	SoundManager.instance.RandomizeSfx(click);
			if (num_capacity==1) {
				img = c1.GetComponent<Image>();
				comp1 = 1;
			}
			if (num_capacity==2) {
				img = c2.GetComponent<Image>();
				comp2 = 1;
			}
			if (num_capacity==3) {
				img = c3.GetComponent<Image>();
				comp3 = 1;
			}
			if (num_capacity==4) {
				img = c4.GetComponent<Image>();
				comp4 = 1;	
			}
			img.sprite = go.GetComponent<Image>().sprite;
		}
    }

    public void SetCapacity2(GameObject go) {
			if (num_capacity==1) {
				txt = c1t.GetComponent<Text>();
			}
			if (num_capacity==2) {
				txt = c2t.GetComponent<Text>();
			}
			if (num_capacity==3) {
				txt = c3t.GetComponent<Text>();
			}
			if (num_capacity==4) {
				txt = c4t.GetComponent<Text>();
			}
			txt.text = go.GetComponent<Text>().text;
    }

}
