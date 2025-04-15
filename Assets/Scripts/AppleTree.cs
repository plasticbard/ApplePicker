using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab; // Prefab of the apple
    public GameObject bombPrefab; // Prefab of the bomb
    public float speed = 1f; // Speed of the tree moves
    public float leftAndRightEdge = 10f; // Distance from the center to edge of the screen
    public float chanceToChangeDirections = 0.02f; // Chance to change direction
    public float chanceToGenerateBomb = 0.1f; // Chance to generate a bomb
    public float secondsBetweenAppleDrops = 1f; // Time between apple drops
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f); // Start dropping apples after 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        //Dropping apples every seconds
        //if (Application.isPlaying)
        //{
        //    InvokeRepeating("DropApple", 1f, 1f);
        //}
        Vector3 pos = transform.position;
        pos.x += speed*Time.deltaTime;
        transform.position = pos;
        // If the apple tree moves off the screen, reverse direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Reverse direction
        }
        if (chanceToGenerateBomb < 0.5)
        {
            chanceToGenerateBomb += Time.deltaTime*0.01f; // Increase the chance to change direction
        }
        speed += Time.deltaTime * 0.1f; // Increase the chance to change direction  
    }
    void DropApple()
    {
        // Create an apple
        if(Random.value < chanceToGenerateBomb)
        {
            GameObject bomb = Instantiate(bombPrefab) as GameObject;
            bomb.transform.position = transform.position;
            if(secondsBetweenAppleDrops>0.3f)
            secondsBetweenAppleDrops = secondsBetweenAppleDrops * 0.95f;
        }
        else
        {
            GameObject apple = Instantiate(applePrefab) as GameObject;
            apple.transform.position = transform.position;
        }
        Invoke("DropApple", secondsBetweenAppleDrops); // Call DropApple again after a delay   

    }
    
}
