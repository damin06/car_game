using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [Header("CheckpoinList")]
    [SerializeField] private GameObject[] CheckpointList;
    public int CheckPointCount=0;
    public Vector3 ResetPos;



}
