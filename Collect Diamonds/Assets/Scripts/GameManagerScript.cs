using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public Text text;
    private PlayerController playerc;
    private int skor = 5;
    public GameObject door;
    public GameObject player;
    public float speed;
    public Vector3 position;
    public Vector3 position2;
    private bool isDoor = false;
    private bool win = false;

    float timeElapsed;
    float lerpDuration = 1000f;
    

    private void Start()
    {
        position = new Vector3(0.4f, -1.175f, -9.7f);
        position2 = new Vector3(0.4f, -1.4f, -9.7f);
        
    }

    public void DiamondCollect()
    {
        skor--;
        if (skor == 1)
        {
            isDoor = true;
        }
        if (skor == 0)
        {
            win = true;
        }
    }
    private void Update()
    {
        DoorMovement();
        Win();
    }
    void DoorMovement()
    {
        if (isDoor)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, position2, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            if (Vector3.Distance(door.transform.position, position2) < 0.001f)
            {
                isDoor = false;
            }
        }
    }
    void Win()
    {
        if (win)
        {
            text.text = "Kazandin!!!";
            Time.timeScale = 0;
        }
    }
    
}