using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public Text scoreLabel;     //距離を表示するUI
    public Image hpGauge;     //ライフゲージを保存する変数
    //public GameObject itemPre; // アイテムプレハブ保存
    public GameObject bossPre;
    public static int score;
    public static float hp;
    bool boss;
    PlayerController playerCon;

    public float Hp
    {
        set
        {
            hp = value;
            //値に制限をつけれる
            hp = Mathf.Clamp(hp, 0, 100);
        }
        get {  return hp; }
    }

    void Start()
    {
        BgmManager.Instance.Play("maou_game_medley01");
        score = 0;
        hp = 100f;
        boss = false;
    }

    void Update()
    {
        scoreLabel.text = "Score " + score.ToString("D6");

        // 距離が600kmで割り切れるときにアイテム出現
        //if (score == 0)
        //{
        //    Instantiate(itemPre);
        //}
        //  残り時間を減らす処理
        //hpGauge.fillAmount -= hp;
        //Debug.Log(lastTime);

        // プレーヤーの弾レベルを取得して表示
        //shotLabel.text = "ShotLevel " + playerCon.ShotLevel.ToString("D2");

        hpGauge.fillAmount = hp / 100;
        hp = Mathf.Clamp(hp,0, 100);

        if (score >= 3000 && boss == false)
        {
            BgmManager.Instance.Stop();
            BgmManager.Instance.Play("maou_game_lastboss03");
            boss = true;
            GameObject go = Instantiate(bossPre);
            go.transform.position = new Vector3(6, 0, 0);
        }

        //残り時間が0になったらタイトルへ
        if (Hp <= 0)
        {
            //sceneload.hp = Hp;
            SceneManager.LoadScene("TitleScene");
        }
    }
}