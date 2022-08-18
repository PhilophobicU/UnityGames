using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairCollisionCut : MonoBehaviour
{

    public int checkPointCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hair"))
        {
            other.gameObject.SetActive(false);
            checkPointCount++;
        }
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            checkPointCount++;
            Destroy(other.gameObject);
        }
    }
}
