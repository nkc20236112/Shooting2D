using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public Text shotLabel;  // �e�̋����\���e�L�X�g�I�u�W�F�N�g�ۑ�

    public Text kyorirabel;     //������\������UI

    float lastTime;             //�c�莞�Ԃ�ۑ�

    public Image timeGauge;     //�^�C���Q�[�W��ۑ�����ϐ�

    public GameObject itemPre; // �A�C�e���v���n�u�ۑ�
    public GameObject bossPre;

    public static int kyori;

    PlayerController playerCon;


    public int Kyori
    {
        set
        {
            kyori = value;
            //�l�ɐ����������
            kyori = Mathf.Clamp(kyori, 0, 999999);
        }
        get { return kyori; }
    }

    void Start()
    {
        //BgmManager.Instance.Play("maou_game_medley01");
        kyori = 0;
        lastTime = 60;         //�c�莞��100�b
    }

    void Update()
    {
        kyori++;
        kyorirabel.text = "Score " + kyori.ToString("D6");

        // ������600km�Ŋ���؂��Ƃ��ɃA�C�e���o��
        if (kyori % 50 == 0)
        {
            Instantiate(itemPre);
        }
        shotLabel.text = "ShotLevel " + PlayerController.shotLevel.ToString("D2");
        //  �c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 60f;
        //Debug.Log(lastTime);

        // �v���[���[�̒e���x�����擾���ĕ\��
        //shotLabel.text = "ShotLevel " + playerCon.ShotLevel.ToString("D2");

        if (lastTime == 30)
        {
            GameObject go = Instantiate(bossPre);
            go.transform.position = new Vector3(0, 0, 0);
            Debug.Log(111);
        }

        //�c�莞�Ԃ�0�ɂȂ�����^�C�g����
        if (lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
