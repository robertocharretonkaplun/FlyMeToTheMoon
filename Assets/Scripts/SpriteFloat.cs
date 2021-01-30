using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFloat : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float horizontalFall = -1;
    public Rigidbody2D rigidBody;
    Vector2 movement;


    void ScreenWrap()
    {        
        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(rigidBody.position);
        var newPosition = rigidBody.position;

        if (viewportPosition.x > 1)
        {
            //newPosition.x = -newPosition.x + 0.1f;
        }

        if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewportPosition.y > 1)
        {
            //newPosition.y = -newPosition.y + 0.1f;
        }

        if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }


        transform.position = newPosition;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        movement.x = horizontalFall;
        movement.y = -1;
        ScreenWrap();
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        rigidBody.transform.Rotate(0, 0, 3, Space.Self);
    }
}
