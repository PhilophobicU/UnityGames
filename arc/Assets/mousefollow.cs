using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousefollow : MonoBehaviour
{
    public GameObject blade;
    public Camera cam;
    public LayerMask mask;



    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100,mask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
        }

        blade.transform.position = hit.point;
    }
}
