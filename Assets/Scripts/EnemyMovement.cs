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
            _rb.velocity = Vector2.up*speed;
            yield return new WaitForSeconds(1.6f/speed);
            _rb.velocity = Vector2.right*speed;
            yield return new WaitForSeconds(0.5f/speed);
            _rb.velocity = Vector2.down*speed;
            yield return new WaitForSeconds(1.6f/speed);
        }
    }
}
