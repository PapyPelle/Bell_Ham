using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{


	public GameObject InventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        InventoryPanel.SetActive(false);
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
    }
}
