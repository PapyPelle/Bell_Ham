using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{


	public GameObject InventoryPanel;
	public GameObject DescriptionEq1;
	public GameObject DescriptionEq2;

	int description1AFF = 0;
	int description2AFF = 0;

    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.SetActive(false);
        DescriptionEq1.SetActive(false);
        DescriptionEq2.SetActive(false);
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
}
