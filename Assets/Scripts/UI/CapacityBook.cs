using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityBook : MonoBehaviour
{

	public GameObject P1;
	public GameObject P2;
	public GameObject P3;
	public GameObject P4;

	public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        P1.SetActive(true);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void b1() {
        P1.SetActive(true);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
        SoundManager.instance.RandomizeSfx(click);
    }

    public void b2() {
        P1.SetActive(false);
        P2.SetActive(true);
        P3.SetActive(false);
        P4.SetActive(false);
        SoundManager.instance.RandomizeSfx(click);
    }

    public void b3() {
        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(true);
        P4.SetActive(false);
        SoundManager.instance.RandomizeSfx(click);
    }

    public void b4() {
        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(true);
        SoundManager.instance.RandomizeSfx(click);
    }
}
