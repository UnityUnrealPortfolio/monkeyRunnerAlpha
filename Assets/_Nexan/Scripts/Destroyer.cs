using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inactivates pooled items when they pass its trigger
/// resetting them for use by the pool
/// </summary>
public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "canyon")
        {
            other.transform.parent.gameObject.SetActive(false);
        }
    }
}
