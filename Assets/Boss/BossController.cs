using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public GameObject ExplosionPre;// 爆発のプレハブを保存
    int BossHp = 60;
    float span = 4;
    float delta = 0;
    void Start()
    {

    }

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            float a =Random.Range(0,3);
            if(a == 0)
            {
                transform.position = new Vector3(6, 0, 0);
            }
            else if(a == 1)
            {
                transform.position = new Vector3(6, 3, 0);
            }
            else
            {
                transform.position = new Vector3(6, -3, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Hp0でエフェクトを流して消える
        if (col.gameObject.tag == "Shot")
        {
            BossHp--;
            if(BossHp < 0)
            {
                Destroy(gameObject);
                BgmManager.Instance.Play("maou_game_medley01");
                Instantiate(ExplosionPre, transform.position, transform.rotation);
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}

