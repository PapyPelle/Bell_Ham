using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnMainMenu : MonoBehaviour
{

    public AudioClip music;
    // Start is called before the first frame update
    void Start()
    {
        //SoundManager.instance.PlaySingle(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnMain() {
       
        Debug.Log(" -- LoadMenu --");
        SceneManager.LoadScene("MainMenu");
        
    }
}
