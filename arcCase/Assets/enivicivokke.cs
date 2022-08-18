using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enivicivokke : MonoBehaviour
{
    [SerializeField] private GameObject blade;
    //[SerializeField] private Transform child;
    [SerializeField] private LayerMask layer;
    
    private float speed = 10f;
    
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,100,layer))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
        }

        

        blade.transform.position = Vector3.Lerp(blade.transform.position, hit.point+new Vector3(0,.25f,0), Time.deltaTime * speed);
        blade.transform.rotation = Quaternion.Lerp(blade.transform.rotation , hit.transform.rotation, Time.deltaTime * speed);
        blade.transform.LookAt(hit.point+new Vector3(0,0.2f,0));
        
    }
}
