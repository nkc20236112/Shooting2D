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
        //�v���C���[�̈ʒu�ɓ˂�����
        //player = GameObject.Find("Player").transform;
        //dir = player.position - transform.position;

    }

    void Update()
    {
        //�v���C���[�����Ēǔ�
        player = GameObject.Find("Player").transform;
        dir = player.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;

        //transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
