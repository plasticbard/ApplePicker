using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("绑定 Canvas 的 RectTransform")]
    public RectTransform canvasRect;

    [Header("固定 Y 和 Z 值")]
    public float fixedY = -213f; // 根据需求调整
    public float fixedZ = 0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LoadScene when click
        if (Input.GetMouseButtonDown(0))
        {


            SceneManager.LoadScene("_Scene_0");
        }
    }
}
