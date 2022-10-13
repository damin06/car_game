using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.Find("CheckPointManager").GetComponent<CheckPoint>();
        }
    }
}
