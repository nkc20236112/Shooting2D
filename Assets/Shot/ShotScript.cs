using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    Animator anim;
    float speed;
    void Start()
    {
        anim = GetComponent<Animator>();
        //Žõ–½4•b
        Destroy(gameObject, 4f);
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // “G‚¾‚Á‚½‚ç
        if (col.gameObject.tag == "Enemy")
        {
            GameObject director = GameObject.Find("GameDirector");
            GameDirector.score += 200;
            Destroy(gameObject);
        }
    }
}
