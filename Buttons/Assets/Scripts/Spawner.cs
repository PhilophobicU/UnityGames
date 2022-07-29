using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public KeyCode[] cla = {KeyCode.A,KeyCode.S,KeyCode.D,KeyCode.F};
    [SerializeField] public Color[] renkler = { Color.blue, Color.yellow, Color.red, Color.magenta };

    public Transform spawnPoint; // spawn noktasi

    public GameObject cube;     // kup prefab
    private GameObject A;       // kup variant

    private Vector3 scaleChange,positionChange; 

    Rigidbody rb;

    private int arraysirasi; // world x pozisyonuna gore array siralamasi

    private Renderer spawnRenderer;
    private Renderer cubeRenderer;


    void Start()
    {
        scaleChange = new Vector3(0, Time.deltaTime, 0);    // y yönünde boyut de?i?imi  !! 2 yönde uzar
        positionChange = new Vector3(0, Time.deltaTime, 0); // y yönünde pozisyon de?i?imi
       
        arraysirasi = ((int)this.transform.position.x);
        
        spawnRenderer = this.GetComponent<Renderer>();
        spawnRenderer.material.SetColor("_Color", renkler[arraysirasi]);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(cla[arraysirasi]))
        {
            //cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // küp olustur
            //cube.transform.position = new Vector3(0, Time.deltaTime, 0);     // küp spawnpoint



            A = Instantiate(cube,spawnPoint.transform.position,Quaternion.identity); // kup olustur

            cubeRenderer = A.GetComponent<Renderer>();                               // olu?turulan kupun renderer bilgisini al
            cubeRenderer.material = spawnRenderer.material;                         // kup rengini spawner rengine set et
            A.transform.localScale = new Vector3(1, 0, 1);                          // kupu spawnpointte yass? hale getir           
            rb = A.GetComponent<Rigidbody>();                                       // olu?turulan kupub rb bilgisini al

        }
        
        if (Input.GetKey(cla[arraysirasi]))
        {
            A.transform.localScale += scaleChange / 8;                             // local scale
            A.transform.position += positionChange / 16;                         // pozisyon otele


        }
        if (Input.GetKeyUp(cla[arraysirasi]))
        {
            rb.velocity = new Vector3(0, 2, 0);                                 // yukariya haraket

        }

    }
}
