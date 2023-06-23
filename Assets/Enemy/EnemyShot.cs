using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    public float speed;
    Transform player;
    GameDirector gd;    // GameDirectorコンポーネント保存

    void Start()
    {
        player = GameObject.Find("Player").transform;
        dir = player.position - transform.position;
        // GameDirectorコンポーネントを取得
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        //寿命4秒
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // 移動処理
        transform.position += dir.normalized * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //距離を500km減らす
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}