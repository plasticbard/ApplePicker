using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in Inspector")]
    public static float bottom = -20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < bottom)
        {
            Destroy(this.gameObject); // Destroy the apple if it falls below the screen
       
            ApplePicker applePicker = Camera.main.GetComponent<ApplePicker>();
            applePicker.AppleDestroyed(); // Notify the ApplePicker that an apple has been destroyed
        }
    }
}
