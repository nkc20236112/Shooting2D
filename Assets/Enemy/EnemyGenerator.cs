using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre;     //敵プレハブを保存する変数
    float delta;                    //経過時間計算用
    float span;                     //敵を出す間隔（秒）を保存する変数

    void Start()
    {
        delta = 0;
        span = 1f;
    }

    void Update()
    {
        //経過時間を加算
            delta += Time.deltaTime;

        if (delta > span)
        {
            //時間経過を保存している変数を０クリア
            delta = 0;

            //敵出す間隔を徐々に少なくする
            span -= (span > 0.5f) ? 0.01f : 0f;

            //敵を生成する
            GameObject go = Instantiate(enemyPre);

            float py = UnityEngine.Random.Range(-6f, 7f);
            go.transform.position = new Vector3(11, py, 5);
        }
    }
}
