using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform cannon;
    float angle;
    float turnSpeed = 5f;
    void Update()
    {
        RotateCannon();
    }
    
    void RotateCannon()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - cannon.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        cannon.transform.rotation = Quaternion.Slerp(cannon.transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
}
