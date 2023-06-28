using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre;     //�G�v���n�u��ۑ�����ϐ�
    float delta;                    //�o�ߎ��Ԍv�Z�p
    float span;                     //�G���o���Ԋu�i�b�j��ۑ�����ϐ�

    void Start()
    {
        delta = 0;
        span = 1f;
    }

    void Update()
    {
        //�o�ߎ��Ԃ����Z
            delta += Time.deltaTime;

        if (delta > span)
        {
            //���Ԍo�߂�ۑ����Ă���ϐ����O�N���A
            delta = 0;

            //�G�o���Ԋu�����X�ɏ��Ȃ�����
            span -= (span > 0.5f) ? 0.01f : 0f;

            //�G�𐶐�����
            GameObject go = Instantiate(enemyPre);

            float py = UnityEngine.Random.Range(-6f, 7f);
            go.transform.position = new Vector3(11, py, 5);
        }
    }
}
