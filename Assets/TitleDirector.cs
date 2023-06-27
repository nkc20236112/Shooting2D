using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleDirector : MonoBehaviour
{
    public Text scoreLabel; // 前回のスコア（距離）表示

    void Start()
    {
        //float a = sceneload.hp;
        scoreLabel.text = "Score\n" + GameDirector.score.ToString("D6");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
