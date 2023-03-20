using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{

    static public bool found = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("PLAYER WAS DETECTED");
            found = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        found = false;
    }
}
