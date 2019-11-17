using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationMenuUI : MonoBehaviour
{

	int v_left=10;
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
    	if (v_left > 0) { v_con += 1; v_left -= 1; }
    }
    public void ConDown() {
    	if (v_con > 0) { v_con -= 1; v_left += 1; }
    }

    public void ForcUp() {
    	if (v_left > 0) { v_for += 1; v_left -= 1; }
    }
    public void ForcDown() {
    	if (v_for > 0) { v_for -= 1; v_left += 1; }
    }

    public void MagUp() {
    	if (v_left > 0) { v_mag += 1; v_left -= 1; }
    }
    public void MagDown() {
    	if (v_mag > 0) { v_mag -= 1; v_left += 1; }
    }

    public void MemUp() {
    	if (v_left > 0) { v_mem += 1; v_left -= 1; }
    }
    public void MemDown() {
    	if (v_mem > 0) { v_mem -= 1; v_left += 1; }
    }

    public void AgiUp() {
           	if (v_left > 0) { v_agi += 1; v_left -= 1; }
    }
    public void AgiDown() {
    	if (v_agi > 0) { v_agi -= 1; v_left += 1; }
    }
}
