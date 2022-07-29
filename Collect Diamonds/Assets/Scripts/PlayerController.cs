using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    private GameManagerScript gmanager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gmanager = GameManagerScript.FindObjectOfType<GameManagerScript>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb.AddForce(moveX, rb.velocity.y, moveZ,ForceMode.Force);
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            gmanager.DiamondCollect();
        }
        if (other.CompareTag("Fall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
