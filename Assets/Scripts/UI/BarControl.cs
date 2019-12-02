using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarControl : MonoBehaviour
{
    private Transform child;

    void Start()
    {
        child = transform.Find("fg");
    }


    public void SetBar(float amount) // amount := current / max value
    {
        // Debug.Log("VALEUR BAR : " + amount);
        child.localScale = new Vector3(amount, 1, 1);
    }
}
