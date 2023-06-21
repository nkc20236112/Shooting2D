using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    Animator anim;

    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        //éıñΩ4ïb
        Destroy(gameObject, 4f);

    }

    // Update is called once per frame
    void Update()
    {
        //âÊñ ì‡à⁄ìÆêßå¿
        Vector3 pos = new Vector3(speed, 0, 0);
       
        transform.position += transform.up * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // ìGÇæÇ¡ÇΩÇÁ
        if (col.gameObject.tag == "Enemy")
        {
            GameObject director = GameObject.Find("GameDirector");
            GameDirector.kyori += 200;
            Destroy(gameObject);
        }
    }
}
