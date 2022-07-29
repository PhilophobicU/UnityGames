using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    void Start()
    {
        posOffset = transform.position;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * 15f, 0f), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * 0.5f) * 0.1f;

        transform.position = tempPos;
    }
}
