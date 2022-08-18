using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HairCollisionCut hc;

    public Vector3 bladeIdlePosition;
    public Vector3 CanIdlePosition;
    [SerializeField] Vector3 offSet;

    [SerializeField] private LayerMask sprayMask;
    [SerializeField] private LayerMask bladeMask;

    [SerializeField] private ParticleSystem ps, end;

    [SerializeField] private float speed = 1f;

    private GameObject sprayCan;
    private GameObject blade;

    private bool a;
    private bool b;

    [SerializeField] private GameObject spriteMask;
    [SerializeField] private GameObject bladeCollider;
    [SerializeField] private GameObject maskParent;


    [SerializeField] private Transform spriteMaskSpawnLocation;

    [SerializeField][Range(0, 1000)] private float randomNumber;

    public float xValue ;
    public float yValue;

    private void Awake()
    {
        end.Stop();
        sprayCan = GameObject.FindGameObjectWithTag("Spray");
        blade = GameObject.FindGameObjectWithTag("Blade");
        hc = GameObject.FindObjectOfType<HairCollisionCut>();

    }

    private void Update()
    {


        if (!a && ps.GetComponent<ParticleSystem>().particleCount <= 249)
        {
            //RayControl(sprayCan,sprayMask);
            MobileControl(sprayCan);
            blade.transform.position = bladeIdlePosition;
        }
        else if (!b && ps.GetComponent<ParticleSystem>().particleCount >= 249)
        {
            a = true;
            //RayControl(blade,bladeMask);
            MobileControl(blade);
            GameObject spritem = Instantiate(spriteMask, spriteMaskSpawnLocation.position, spriteMaskSpawnLocation.rotation);
            spritem.transform.parent = GameObject.Find("MaskParent").transform;
            sprayCan.transform.position = CanIdlePosition;
        }

        if (hc.checkPointCount > 594)
        {
            b = true;

            if (!end.isPlaying)
                end.Play();

            Destroy(maskParent);
            ps.Clear();
            ps.Stop();
            blade.transform.position = bladeIdlePosition;
        }
    }

    //private void RayControl(GameObject obj, LayerMask mask) // mouse control

    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 100, mask))
    //    {
    //        Debug.DrawLine(ray.origin, hit.point, Color.green);
    //    }
    //    else
    //    {
    //        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
    //    }


    //    if (obj == blade)
    //    {
    //        blade.transform.position = Vector3.Lerp(blade.transform.position, hit.point, Time.deltaTime * speed);
    //        blade.transform.rotation = Quaternion.LookRotation(hit.point - blade.transform.position, Vector3.up);

    //        bladeCollider.transform.position = blade.transform.position + offSet;
    //        bladeCollider.transform.rotation = blade.transform.rotation;
    //    }
    //    else
    //    {
    //        obj.transform.position = hit.point;
    //    }
    //}


    private void MobileControl(GameObject obj)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            xValue = touch.position.x;
            yValue = touch.position.y;


            Vector3 pos = new Vector3(xValue, yValue, 10f);


            Vector3 touchPos = Camera.main.ScreenToWorldPoint(pos);

            

            if (obj == blade)
            {
                blade.transform.position = Vector3.Lerp(blade.transform.position, touchPos, Time.deltaTime * speed);
                blade.transform.rotation = Quaternion.LookRotation(touchPos - blade.transform.position, Vector3.up);

                bladeCollider.transform.position = blade.transform.position + offSet;
                bladeCollider.transform.rotation = blade.transform.rotation;
            }
            else
            {
                obj.transform.position = touchPos;
            }

        }
    }




}
