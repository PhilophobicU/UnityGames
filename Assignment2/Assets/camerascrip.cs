using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascrip : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 50f)] private float speed = 10f;
    public Transform pota;
    public Transform ball;
    public Vector3 offset;
    void Update()
    {
        transform.RotateAround(pota.position, transform.up, Input.GetAxisRaw("Horizontal") * Time.deltaTime * -90f);
        transform.LookAt(pota.position);

        float zDisplacement = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        transform.Translate(0, 0, zDisplacement);

        transform.position += ball.transform.position + offset;
    }
}
