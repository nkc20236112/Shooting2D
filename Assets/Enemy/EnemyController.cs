using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 5;
    public GameObject ExplosionPre;// �����̃v���n�u��ۑ�
    public GameObject ItemPre;  //�A�C�e���v���n�u
    public GameObject ShotPre;  // �e�̃v���n�u��ۑ�
    Vector3 dir;                // �ړ�������ۑ�
    int enemyType;              // �G�̎�ނ�ۑ�
    float rad;                  // �G�̓����T�C���J�[�u�p
    float shotTime;             // �e�̔��ˊԊu�v�Z�p
    float shotInterval = 2f;    // �e�̔��ˊԊu
    GameDirector gd;            // GameDirector�R���|�[�l���g��ۑ�
    Transform player;   // �v���[���[�̃g�����X�t�H�[���R���|�[�l���g��ۑ�

    void Start()
    {
        //����4�b
        Destroy(gameObject, 6f);
        dir = Vector3.left;             // �ړ�����
        enemyType = Random.Range(0, 3); // �G�̎��
        speed = 5;                      // �ړ����x
        rad = Time.time;                // �T�C���J�[�u�̓��������炷�p
        shotTime = 0;                   // �e���ˊԊu�v�Z�p

        // GameDirector�R���|�[�l���g���擾
        //gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        Destroy(gameObject, 6);		    // ����
    }

    void Update()
    {
        // �G�l�~�[�^�C�v�Q�����c�ړ��i�T�C���J�[�u�j�ǉ�
        if (enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f); //���Ԃ��|���Ă��炵�Ă���
        }

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;

        // �G�̒e�̐���
        shotTime += Time.deltaTime;
        if (shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //�Փ˂�����G�t�F�N�g�𗬂��ď�����
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