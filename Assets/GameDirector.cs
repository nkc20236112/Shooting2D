using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public Text scoreLabel;     //������\������UI
    public Image hpGauge;     //���C�t�Q�[�W��ۑ�����ϐ�
    //public GameObject itemPre; // �A�C�e���v���n�u�ۑ�
    public GameObject bossPre;
    public static int score;
    public static float hp;
    bool boss;
    PlayerController playerCon;

    public float Hp
    {
        set
        {
            hp = value;
            //�l�ɐ����������
            hp = Mathf.Clamp(hp, 0, 100);
        }
        get {  return hp; }
    }

    void Start()
    {
        BgmManager.Instance.Play("maou_game_medley01");
        score = 0;
        hp = 100f;
        boss = false;
    }

    void Update()
    {
        scoreLabel.text = "Score " + score.ToString("D6");

        // ������600km�Ŋ���؂��Ƃ��ɃA�C�e���o��
        //if (score == 0)
        //{
        //    Instantiate(itemPre);
        //}
        //  �c�莞�Ԃ����炷����
        //hpGauge.fillAmount -= hp;
        //Debug.Log(lastTime);

        // �v���[���[�̒e���x�����擾���ĕ\��
        //shotLabel.text = "ShotLevel " + playerCon.ShotLevel.ToString("D2");

        hpGauge.fillAmount = hp / 100;
        hp = Mathf.Clamp(hp,0, 100);

        if (score >= 3000 && boss == false)
        {
            BgmManager.Instance.Stop();
            BgmManager.Instance.Play("maou_game_lastboss03");
            boss = true;
            GameObject go = Instantiate(bossPre);
            go.transform.position = new Vector3(6, 0, 0);
        }

        //�c�莞�Ԃ�0�ɂȂ�����^�C�g����
        if (Hp <= 0)
        {
            //sceneload.hp = Hp;
            SceneManager.LoadScene("TitleScene");
        }
    }
}