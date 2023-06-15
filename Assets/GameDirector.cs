using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public Text kyorirabel;     //������\������UI
    int  kyori;                 //������ۑ�����

    public static float lastTime;             //�c�莞�Ԃ�ۑ�

    public Image timeGauge;     //�^�C���Q�[�W��ۑ�����ϐ�

    public float damage;

    void Start()
    {
        kyori = 0;
        lastTime = 100;         //�c�莞��100�b
    }

    void Update()
    {
        //  �c�莞�Ԃ����炷����
        lastTime -= Time.deltaTime + damage;
        timeGauge.fillAmount = lastTime / 100f;
        //Debug.Log(lastTime);

        damage = 0;

        //�c�莞�Ԃ�0�ɂȂ����烊���[�h
        if (lastTime < 0)
        {
            SceneManager.LoadScene("GameScene");
        }

        //�i�񂾋�����\��
        kyori++;
        kyorirabel.text = kyori.ToString("D6")+"km";
    }
}
