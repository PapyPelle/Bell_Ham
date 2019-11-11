using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPopup : MonoBehaviour
{

	public GameObject popup;

	int num_capacity;

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
    }
    public void capacity2() {
    	popup.SetActive(true);
    	num_capacity = 2;
    }
    public void capacity3() {
    	popup.SetActive(true);
    	num_capacity = 3;
    }
    public void capacity4() {
    	popup.SetActive(true);
    	num_capacity = 4;
    }


    public void SetCapacity() {
    	popup.SetActive(false);
		if (num_capacity==1) {

		}
		if (num_capacity==2) {
			
		}
		if (num_capacity==3) {
			
		}
		if (num_capacity==4) {
			
		}
    }



}
