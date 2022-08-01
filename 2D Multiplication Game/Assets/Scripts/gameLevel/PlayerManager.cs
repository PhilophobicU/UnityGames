using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform cannon;
    [SerializeField] private GameObject[] bulletPrefab;
    [SerializeField] private Transform bulletPosition;
    float angle;
    float turnSpeed = 5f;
    float bulletBetweenTime = 200f;
    float nextTime;
    void Update()
    {
        RotateCannon();
    }
    
    void RotateCannon()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - cannon.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;

        if (angle < 60 && angle > -60)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            cannon.transform.rotation = Quaternion.Slerp(cannon.transform.rotation, rotation, turnSpeed * Time.deltaTime);
        }

       

        

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + bulletBetweenTime / 1000;
                Bullet();
            }
        }
    }
    
    void Bullet()
    {
        GameObject bullet = Instantiate(bulletPrefab[Random.Range(0,bulletPrefab.Length)],bulletPosition.position,bulletPosition.rotation) as GameObject;
    }
   
}
