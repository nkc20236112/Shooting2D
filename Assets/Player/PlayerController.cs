using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    public float Speed;
    public int ShotLevel;
    public static int shotLevel;  // ����̃��x��
    public GameObject ShotPre;
    float timer;    // ���e�̔��ˊԊu�v�Z�p
    GameDirector gd;            // GameDirector�R���|�[�l���g��ۑ�
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
        shotLevel = 0;  // �e���x��
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        timer = 0;  // ���ԏ�����
        Speed = 10;
    }

void Update()
    {
        //�ړ����������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * Speed * Time.deltaTime;

        //��ʓ��ړ�����
        Vector3 pos=transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        // C�L�[��shotLevel�ύX(�f�o�b�O�p)
        if (Input.GetKeyDown(KeyCode.C))
        {
            shotLevel = (shotLevel + 1) % 13;
        }

        // Z�L�[��������Ă���Ƃ��e�𔭎�
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            shotLevel = (shotLevel < 0) ? 0 : shotLevel;

            for (int i = -shotLevel; i < shotLevel + 1; i++)
            {
                // �e�̐����ʒu�̓v���[���[�Ɠ����ꏊ
                Vector3 p = transform.position;

                // �v���[���[�̉�]�p�x���擾���A15�x�����炵�������ɒe����]������
                //Vector3 r = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);
                //Quaternion rot = Quaternion.Euler(r);
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                // �ʒu�Ɖ�]�����Z�b�g���Đ���
                Instantiate(ShotPre, p, rot);
            }
        }

        //�A�j���[�V�����̐ݒ�
        if (dir.y == 0)
        {
            //�A�j���V���[���N���b�v [Player] �Đ�
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
        //�Փ˂����狗�������炷
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

    public void ShotLevelUp()   //shotlevel�𑝂₷�֐�
    {
        shotLevel++;
    }
    public void SpeedLevelDown()    //speedlevel�𑝂₷�֐�
    {
        Speed+=2;
    }
    public void LevelReset()    //level���Z�b�g�̊֐�
    {
        shotLevel = 0;
        Speed = 5;
    }
}