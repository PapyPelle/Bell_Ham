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

	public GameObject a1 = null;
	public GameObject a2 = null;
	public GameObject a3 = null;
	public GameObject a4 = null;
	public GameObject a5 = null;
	public GameObject a6 = null;

	Image img;

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
    	popup.SetActive(false);
    	SoundManager.instance.RandomizeSfx(click);
		if (num_capacity==1) {
			img = c1.GetComponent<Image>();
		}
		if (num_capacity==2) {
			img = c2.GetComponent<Image>();
		}
		if (num_capacity==3) {
			img = c3.GetComponent<Image>();
		}
		if (num_capacity==4) {
			img = c4.GetComponent<Image>();	
		}
		img.sprite = go.GetComponent<Image>().sprite;
    }



}
