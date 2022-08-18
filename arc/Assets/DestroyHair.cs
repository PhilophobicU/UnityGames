using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHair : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("hair") && Input.GetMouseButton(0))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }
}
