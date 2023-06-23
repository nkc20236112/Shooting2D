using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public Text shotLabel;  // 弾の強さ表示テキストオブジェクト保存

    public Text kyorirabel;     //距離を表示するUI

    float lastTime;             //残り時間を保存

    public Image timeGauge;     //タイムゲージを保存する変数

    public GameObject itemPre; // アイテムプレハブ保存
    public GameObject bossPre;

    public static int kyori;

    PlayerController playerCon;


    public int Kyori
    {
        set
        {
            kyori = value;
            //値に制限をつけれる
            kyori = Mathf.Clamp(kyori, 0, 999999);
        }
        get { return kyori; }
    }

    void Start()
    {
        //BgmManager.Instance.Play("maou_game_medley01");
        kyori = 0;
        lastTime = 60;         //残り時間100秒
    }

    void Update()
    {
        kyori++;
        kyorirabel.text = "Score " + kyori.ToString("D6");

        // 距離が600kmで割り切れるときにアイテム出現
        if (kyori % 50 == 0)
        {
            Instantiate(itemPre);
        }
        shotLabel.text = "ShotLevel " + PlayerController.shotLevel.ToString("D2");
        //  残り時間を減らす処理
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 60f;
        //Debug.Log(lastTime);

        // プレーヤーの弾レベルを取得して表示
        //shotLabel.text = "ShotLevel " + playerCon.ShotLevel.ToString("D2");

        if (lastTime == 30)
        {
            GameObject go = Instantiate(bossPre);
            go.transform.position = new Vector3(0, 0, 0);
            Debug.Log(111);
        }

        //残り時間が0になったらタイトルへ
        if (lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
