using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("�� Canvas �� RectTransform")]
    public RectTransform canvasRect;

    [Header("�̶� Y �� Z ֵ")]
    public float fixedY = -213f; // �����������
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
