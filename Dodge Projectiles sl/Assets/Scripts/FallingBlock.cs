using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    public float speed;
    float visibleHeightThreshold;
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent()) ;
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }
    void Update()
    {
        print(speed);
        transform.Translate(Vector3.down * speed * Time.deltaTime,Space.Self);
        
        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
