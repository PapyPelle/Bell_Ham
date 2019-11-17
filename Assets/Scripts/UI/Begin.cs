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
    	SceneManager.LoadScene("Map");
    }
}
