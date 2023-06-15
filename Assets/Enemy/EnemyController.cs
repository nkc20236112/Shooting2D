using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; //�ړ�����

    float speed = 5;            //�ړ����x

    public GameObject ExplosionPre;

    void Start()
    {
        //����4�b
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        //�ړ�����������
        dir = Vector3.left;

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //�������Ԃ�10�b���炷
        if (col.gameObject.tag == "Player")
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().damage += 10f;
            //�����ق��̃I�u�W�F�N�g�ɏd�Ȃ�����폜
            Destroy(gameObject);
        }
        if (col.tag == "Shot")
        {
            Destroy(gameObject);
            Instantiate(ExplosionPre, transform.position, transform.rotation);
        }
    }
}