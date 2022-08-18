using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutController : MonoBehaviour
{
    public GameObject mask;
    public Transform spawnpo;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject ob = Instantiate(mask,spawnpo.position,Quaternion.EulerRotation(-200,0,0));
            ob.transform.parent = GameObject.Find("cuts").transform;
        }
    }

   
}
