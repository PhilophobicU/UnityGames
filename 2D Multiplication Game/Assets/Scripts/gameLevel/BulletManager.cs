using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    float bulletSpeed = 15f;
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
        Destroy(gameObject,2f);
    }
}
