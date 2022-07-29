using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public event System.Action OnPlayerDeath;
    private float screenHalfWidhtInWorldUnits;
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidhtInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidhtInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidhtInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidhtInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidhtInWorldUnits, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy (gameObject);
        }
    }
}
