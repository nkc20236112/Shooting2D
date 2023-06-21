using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;

    Animator  anim;

    public float power;

    public GameObject ShotPre;

    public float speed = 7;

    void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {

        //移動方向をリセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;

        //画面内移動制限
        Vector3 pos=transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        //アニメーションの設定
        if (dir.y == 0)
        {
            //アニメショーンクリップ [Player] 再生
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

        if(Input.GetKey(KeyCode.C)) 
        {
            power += 1;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            GameObject tama = Instantiate(ShotPre);
            tama.transform.position = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //衝突したら距離を減らす
        if (col.gameObject.tag == "Enemy")
        {
            GameObject director = GameObject.Find("GameDirector");

            GameDirector.kyori -= 1000;
        }
        if (col.tag == "EnemyShot")
        {
            GameObject director = GameObject.Find("GameDirector");
            GameDirector.kyori -= 500;
        }
    }
}