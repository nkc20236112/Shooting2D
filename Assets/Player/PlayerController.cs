using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;

    Animator  anim;

    public float power;

    public GameObject ShotPre;

    void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {

        float speed = 5;

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
}
