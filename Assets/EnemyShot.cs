using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    Vector3 dir = Vector3.zero;

    public float speed;

    Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        dir = player.position - transform.position;
        transform.position += dir * speed * Time.deltaTime;

        //寿命4秒
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        //画面内移動制限
        Vector3 pos = new Vector3(-speed, 0, 0);
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        pos.y = Mathf.Clamp(pos.y, -6f, 6f);
        transform.position += pos * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // プレイヤーだったら
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
