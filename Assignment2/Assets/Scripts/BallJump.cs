using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    [SerializeField] float bounce = 15f;
    private void OnCollisionEnter(Collision other) 
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounce, ForceMode.Impulse);
        }
    }
}
