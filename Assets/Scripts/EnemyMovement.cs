using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyMovement : MonoBehaviour
{
    private IEnumerator _coroutine;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coroutine = EnemyMoving();
        StartCoroutine(_coroutine);
    }

    IEnumerator EnemyMoving()
    {
        _rb.velocity = Vector2.down;
        yield return new WaitForSeconds(0.8f);
        while (true)
        {
            _rb.velocity = Vector2.up;
            yield return new WaitForSeconds(1.6f);
            _rb.velocity = Vector2.right;
            yield return new WaitForSeconds(0.5f);
            _rb.velocity = Vector2.down;
            yield return new WaitForSeconds(1.6f);
        }
    }
}
