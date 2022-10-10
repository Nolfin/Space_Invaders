using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = Vector2.up*3;
        if(this.transform.position.y>5) Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("Enemy")) return;
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        PointLogic.PointsProperty++;
    }
}
