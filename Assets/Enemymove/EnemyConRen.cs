using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConRen : MonoBehaviour
{
    Transform player;
    float speed = 5;
    Vector3 dir = Vector3.zero;

    void Start()
    {
        //プレイヤーの位置に突っ込む
        //player = GameObject.Find("Player").transform;
        //dir = player.position - transform.position;

    }

    void Update()
    {
        //プレイヤー見つけて追尾
        player = GameObject.Find("Player").transform;
        dir = player.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;

        //transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
