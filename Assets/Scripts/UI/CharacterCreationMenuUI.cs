using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationMenuUI : MonoBehaviour
{

	public int v_left=10;
	int v_con=10;
	int v_for=10;
	int v_mag=10;
	int v_mem=10;
	int v_agi=10;

	public Text left = null;
	public Text con = null;
	public Text forc = null;
	public Text mag = null;
	public Text mem = null;
	public Text agi = null;

	public AudioClip click;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        left.text = "Point(s) restant : " + v_left.ToString();
        con.text = v_con.ToString();
        forc.text = v_for.ToString();
        mag.text = v_mag.ToString();
        mem.text = v_mem.ToString();
        agi.text = v_agi.ToString();


    }

    public void ConUp() {
    	if (v_left > 0 && v_con < 20) { v_con += 1; v_left -= 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }
    public void ConDown() {
    	if (v_con > 6) { v_con -= 1; v_left += 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }

    public void ForcUp() {
    	if (v_left > 0  && v_for < 20) { v_for += 1; v_left -= 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }
    public void ForcDown() {
    	if (v_for > 6) { v_for -= 1; v_left += 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }

    public void MagUp() {
    	if (v_left > 0 && v_mag < 20) { v_mag += 1; v_left -= 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }
    public void MagDown() {
    	if (v_mag > 6) { v_mag -= 1; v_left += 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }

    public void MemUp() {
    	if (v_left > 0 && v_mem < 20) { v_mem += 1; v_left -= 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }
    public void MemDown() {
    	if (v_mem > 6) { v_mem -= 1; v_left += 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }

    public void AgiUp() {
           	if (v_left > 0 && v_agi < 20) { v_agi += 1; v_left -= 1; SoundManager.instance.RandomizeSfx(click);}
           	else {SoundManager.instance.RandomizeSfx(click);}
    }
    public void AgiDown() {
    	if (v_agi > 6) { v_agi -= 1; v_left += 1; SoundManager.instance.RandomizeSfx(click);}
    	else {SoundManager.instance.RandomizeSfx(click);}
    }
}
