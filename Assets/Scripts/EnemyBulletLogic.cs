using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = Vector2.down*3;
        if(this.transform.position.y<-5) Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("Player")) return;
        Destroy(this.gameObject);
        PointLogic.PointsProperty -= GameObject.FindGameObjectsWithTag("Enemy").Length * 2;
    }
}
