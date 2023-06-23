using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    public float speed;
    Transform player;
    GameDirector gd;    // GameDirector�R���|�[�l���g�ۑ�

    void Start()
    {
        player = GameObject.Find("Player").transform;
        dir = player.position - transform.position;
        // GameDirector�R���|�[�l���g���擾
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        //����4�b
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // �ړ�����
        transform.position += dir.normalized * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //������500km���炷
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}