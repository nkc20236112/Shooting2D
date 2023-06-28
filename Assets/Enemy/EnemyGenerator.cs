using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre;     //“GƒvƒŒƒnƒu‚ğ•Û‘¶‚·‚é•Ï”
    float delta;                    //Œo‰ßŠÔŒvZ—p
    float span;                     //“G‚ğo‚·ŠÔŠui•bj‚ğ•Û‘¶‚·‚é•Ï”

    void Start()
    {
        delta = 0;
        span = 1f;
    }

    void Update()
    {
        //Œo‰ßŠÔ‚ğ‰ÁZ
            delta += Time.deltaTime;

        if (delta > span)
        {
            //ŠÔŒo‰ß‚ğ•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ğ‚OƒNƒŠƒA
            delta = 0;

            //“Go‚·ŠÔŠu‚ğ™X‚É­‚È‚­‚·‚é
            span -= (span > 0.5f) ? 0.01f : 0f;

            //“G‚ğ¶¬‚·‚é
            GameObject go = Instantiate(enemyPre);

            float py = UnityEngine.Random.Range(-6f, 7f);
            go.transform.position = new Vector3(11, py, 5);
        }
    }
}
