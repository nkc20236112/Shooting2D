using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConRen : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    void Start()
    {
        
    }

    void Update()
    {
        float speed = 5;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir * speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;
    }
}
