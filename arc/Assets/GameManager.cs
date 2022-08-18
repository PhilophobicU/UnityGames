using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List <GameObject> gameObjects = new List <GameObject> ();

    private void Start()
    {
        foreach (var item in gameObjects)
        {
            item.AddComponent(typeof(BoxCollider));
            item.GetComponent<BoxCollider>().isTrigger = true;
        }

    }
}
