using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in Inspector")]
    public static float bottom = -20f;
    void Start()
    {
        if (transform.position.y < bottom)
        {
            Destroy(this.gameObject); // Destroy the apple if it falls below the screen

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
