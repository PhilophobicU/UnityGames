using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed = 2f;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        float xDirection = xInput * speed;
        float zDirection = zInput * speed;

        float xVelocity = xDirection * Time.deltaTime;
        float zVelocity = zDirection * Time.deltaTime;

        rb.velocity = new Vector3 (xVelocity, 0, zVelocity);


    }
}
