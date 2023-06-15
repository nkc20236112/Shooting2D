using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; //移動方向

    float speed = 5;            //移動速度

    public GameObject ExplosionPre;

    void Start()
    {
        //寿命4秒
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        //移動方向を決定
        dir = Vector3.left;

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //制限時間を10秒減らす
        if (col.gameObject.tag == "Player")
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().damage += 10f;
            //何かほかのオブジェクトに重なったら削除
            Destroy(gameObject);
        }
        if (col.tag == "Shot")
        {
            Destroy(gameObject);
            Instantiate(ExplosionPre, transform.position, transform.rotation);
        }
    }
}