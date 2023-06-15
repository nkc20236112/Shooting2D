using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    Vector3 dir = Vector3.zero;

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
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        pos.y = Mathf.Clamp(pos.y, -6f, 6f);
        transform.position += pos * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        // ìGÇæÇ¡ÇΩÇÁ
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
