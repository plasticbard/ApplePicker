using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI isWorL;
    void Start()
    {
        isWorL = this.GetComponent<TextMeshProUGUI>();
        if (HighScore.prevHighScore < HighScore.highScore)//��ǰ����û������߷�
            isWorL.text = "Win! Win! Win!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
