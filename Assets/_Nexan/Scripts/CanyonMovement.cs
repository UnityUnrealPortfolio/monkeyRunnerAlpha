using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonMovement : MonoBehaviour
{
  
    void Update()
    {
        transform.Translate(Vector3.back * 5f *  Time.deltaTime);   
    }
}
