using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    public float Speed;
    public int ShotLevel;
    public static int shotLevel;  // 武器のレベル
    public GameObject ShotPre;
    float timer;    // 自弾の発射間隔計算用
    GameDirector gd;            // GameDirectorコンポーネントを保存
    Animator  anim;

    //{
    //    set
    //    {
    //        shotLevel = value;
    //        shotLevel = Mathf.Clamp(shotLevel, 0, 12);
    //    }
    //    get { return shotLevel; }
    //}

    void Start()
    {
        anim = GetComponent<Animator>();
        shotLevel = 0;  // 弾レベル
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        timer = 0;  // 時間初期化
        Speed = 10;
    }

void Update()
    {
        //移動方向をリセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * Speed * Time.deltaTime;

        //画面内移動制限
        Vector3 pos=transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        // CキーでshotLevel変更(デバッグ用)
        if (Input.GetKeyDown(KeyCode.C))
        {
            shotLevel = (shotLevel + 1) % 13;
        }

        // Zキーが押されているとき弾を発射
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            shotLevel = (shotLevel < 0) ? 0 : shotLevel;

            for (int i = -shotLevel; i < shotLevel + 1; i++)
            {
                // 弾の生成位置はプレーヤーと同じ場所
                Vector3 p = transform.position;

                // プレーヤーの回転角度を取得し、15度ずつずらした方向に弾を回転させる
                //Vector3 r = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);
                //Quaternion rot = Quaternion.Euler(r);
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                // 位置と回転情報をセットして生成
                Instantiate(ShotPre, p, rot);
            }
        }

        //アニメーションの設定
        if (dir.y == 0)
        {
            //アニメショーンクリップ [Player] 再生
            anim.Play("Player");
        }
        else if (dir.y == 1)
        {
            anim.Play("PlayerL");
        }
        else if (dir.y == -1)
        {
            anim.Play("PlayerR");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //衝突したら距離を減らす
        if (col.gameObject.tag == "Enemy")
        {
            GameObject director = GameObject.Find("GameDirector");

            gd.Kyori -= 1000;
        }
        if (col.tag == "EnemyShot")
        {
            GameObject director = GameObject.Find("GameDirector");
            gd.Kyori -= 500;
        }
    }

    public void ShotLevelUp()   //shotlevelを増やす関数
    {
        shotLevel++;
    }
    public void SpeedLevelDown()    //speedlevelを増やす関数
    {
        Speed+=2;
    }
    public void LevelReset()    //levelリセットの関数
    {
        shotLevel = 0;
        Speed = 5;
    }
}