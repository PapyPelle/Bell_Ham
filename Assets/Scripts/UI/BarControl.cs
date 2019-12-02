using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarControl : MonoBehaviour
{
    public void SetBar(float amount) // amount := current / max value
    {
        // Debug.Log("VALEUR BAR : " + amount);
        transform.Find("fg").transform.localScale = new Vector3(amount, 1, 1);
    }
}
