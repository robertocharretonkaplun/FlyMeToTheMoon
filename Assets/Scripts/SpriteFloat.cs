using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFloat : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Rigidbody2D rigidBody;
    Vector2 movement;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = -1;
        movement.y = -1;
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        rigidBody.transform.Rotate(0, 0, 3, Space.Self);
    }
}
