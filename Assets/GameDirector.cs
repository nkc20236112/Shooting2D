using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public Text kyorirabel;     //距離を表示するUI
    int  kyori;                 //距離を保存する

    public static float lastTime;             //残り時間を保存

    public Image timeGauge;     //タイムゲージを保存する変数

    public float damage;

    void Start()
    {
        kyori = 0;
        lastTime = 100;         //残り時間100秒
    }

    void Update()
    {
        //  残り時間を減らす処理
        lastTime -= Time.deltaTime + damage;
        timeGauge.fillAmount = lastTime / 100f;
        //Debug.Log(lastTime);

        damage = 0;

        //残り時間が0になったらリロード
        if (lastTime < 0)
        {
            SceneManager.LoadScene("GameScene");
        }

        //進んだ距離を表示
        kyori++;
        kyorirabel.text = kyori.ToString("D6")+"km";
    }
}
