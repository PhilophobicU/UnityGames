using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Commander com;

    public float speed = 6f;
    public Transform cam;
    private CharacterController controller;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3 (horizontal, 0f , vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;                          // gidilen yönün aç?s?
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);      // aç?y? yumu?atma
            transform.rotation = Quaternion.Euler(0f,angle, 0f);                                                                        // gidilen yere döndür
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;                                                  // gidilen yön
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
