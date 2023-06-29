using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 5;
    public GameObject ExplosionPre;// 爆発のプレハブを保存
    public GameObject ItemPre;  //アイテムプレハブ
    public GameObject ShotPre;  // 弾のプレハブを保存
    Vector3 dir;                // 移動方向を保存
    int enemyType;              // 敵の種類を保存
    float rad;                  // 敵の動きサインカーブ用
    float shotTime;             // 弾の発射間隔計算用
    float shotInterval = 2f;    // 弾の発射間隔
    GameDirector gd;            // GameDirectorコンポーネントを保存
    Transform player;   // プレーヤーのトランスフォームコンポーネントを保存

    void Start()
    {
        //寿命4秒
        Destroy(gameObject, 6f);
        dir = Vector3.left;             // 移動方向
        enemyType = Random.Range(0, 3); // 敵の種類
        speed = 5;                      // 移動速度
        rad = Time.time;                // サインカーブの動きをずらす用
        shotTime = 0;                   // 弾発射間隔計算用

        // GameDirectorコンポーネントを取得
        //gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        Destroy(gameObject, 6);		    // 寿命
    }

    void Update()
    {
        // エネミータイプ２だけ縦移動（サインカーブ）追加
        if (enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f); //時間を掛けてずらしている
        }

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        // 敵の弾の生成
        shotTime += Time.deltaTime;
        if (shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //衝突したらエフェクトを流して消える
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(ExplosionPre, transform.position, transform.rotation);
            PlayerController.shotLevel--;
            //PlayerController.Speed-=1;

        }
        if (col.tag == "Shot")
        {
            Destroy(gameObject);
            Instantiate(ExplosionPre, transform.position, transform.rotation);
            Instantiate(ItemPre, transform.position, transform.rotation);
        }
    }
}