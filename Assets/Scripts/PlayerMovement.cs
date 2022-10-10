using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed, 0);
        while (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else rb.velocity = new Vector2(-speed, 0);
        }

        if (Input.touchCount == 0) rb.velocity = new Vector2(0, 0);
    }
    
}
