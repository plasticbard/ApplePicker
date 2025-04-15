using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numberOfBaskets = 3;
    public float basketBottomY = -14f; // Y position of the bottom of the basket
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public void AppleDestroyed()
    {
        //one apple miss,all apple disapear
        GameObject[]tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tApple in tAppleArray)
        {
            Destroy(tApple);
        }
        GameObject[] tBombArray = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject tBomb in tBombArray)
        {
            Destroy(tBomb);
        }
        int basketIndex = basketList.Count - 1;
        //remove the last basket
        GameObject tBasket = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasket);
        if (basketIndex == 0)
        {
            Basket tBasketComponent = tBasket.GetComponent<Basket>();
            tBasketComponent.GameOver();
            Debug.Log("Game Over");
            
        }
    }

    void Start()
    {
        for (int i = 0;i < numberOfBaskets; i++)
        {
            GameObject tBasket=Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasket.transform.position = pos;
            basketList.Add(tBasket);
        }
    }

    private void LoadCurrScore()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
