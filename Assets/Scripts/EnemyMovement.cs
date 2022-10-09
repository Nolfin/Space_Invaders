using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyMovement : MonoBehaviour
{
    private IEnumerator _coroutine;
    private Rigidbody2D _rb;
    private float speed = 0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coroutine = EnemyMoving();
        StartCoroutine(_coroutine);
    }

    IEnumerator EnemyMoving()
    {
        _rb.velocity = Vector2.down*speed;
        yield return new WaitForSeconds(0.8f/speed);
        while (true)
        {
            speed = (float)0.7 * 28 /GameObject.FindGameObjectsWithTag("Enemy").Length;
            _rb.velocity = Vector2.up*speed;
            yield return new WaitForSeconds(1.6f/speed);
            speed = (float)0.7 * 28 /GameObject.FindGameObjectsWithTag("Enemy").Length;
            _rb.velocity = Vector2.right*speed;
            yield return new WaitForSeconds(0.5f/speed);
            if (gameObject.transform.position.x > 5)
            {
                PointLogic.PointsProperty -= GameObject.FindGameObjectsWithTag("Enemy").Length * 2;
                Destroy(gameObject);
            }
            speed = (float)0.7 * 28 /GameObject.FindGameObjectsWithTag("Enemy").Length;
            _rb.velocity = Vector2.down*speed;
            yield return new WaitForSeconds(1.6f/speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.tag.Equals("Player")) return;
        PointLogic.PointsProperty -= GameObject.FindGameObjectsWithTag("Enemy").Length * 2;
        Destroy(gameObject);
    }
}
