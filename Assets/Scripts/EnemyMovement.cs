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
    private float _speed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coroutine = EnemyMoving();
        StartCoroutine(_coroutine);
    }

    IEnumerator EnemyMoving()
    {
        _rb.velocity = Vector2.left*_speed;
        yield return new WaitForSeconds(0.8f/_speed);
        while (true)
        {
            _speed = (float)0.7 * (28+GameObject.FindGameObjectsWithTag("Enemy").Length) /56;
            _rb.velocity = Vector2.right*_speed;
            yield return new WaitForSeconds(1.6f/_speed);
            _speed = (float)0.7 * (28+GameObject.FindGameObjectsWithTag("Enemy").Length) /56;
            _rb.velocity = Vector2.down*_speed;
            yield return new WaitForSeconds(0.5f/_speed);
            if (gameObject.transform.position.y < -5)
            {
                PointLogic.PointsProperty -= GameObject.FindGameObjectsWithTag("Enemy").Length * 2;
                Destroy(gameObject);
            }
            _speed = (float)0.7 * (28+GameObject.FindGameObjectsWithTag("Enemy").Length) /56;
            _rb.velocity = Vector2.left*_speed;
            yield return new WaitForSeconds(1.6f/_speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (!collision2D.gameObject.tag.Equals("Player")) return;
        PointLogic.PointsProperty -= GameObject.FindGameObjectsWithTag("Enemy").Length * 2;
        Destroy(gameObject);
    }
}
