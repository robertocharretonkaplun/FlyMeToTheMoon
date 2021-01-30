using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFloat : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float horizontalFall = -1;
    public Rigidbody2D rigidBody;
    Vector2 movement;

    private Renderer[] renderers;
    private bool isWrappingX = false;
    private bool isWrappingY = false;

    bool CheckRenderers()
    {
        foreach (Renderer renderer in renderers)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }

        return false;
    }

    void ScreenWrap()
    {
        var isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }

        if (isWrappingX && isWrappingY)
        {
            return;
        }

        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(rigidBody.position);
        var newPosition = rigidBody.position;
        
        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }

        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;

            isWrappingY = true;
        }

        transform.position = newPosition;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {        
        movement.x = horizontalFall;
        movement.y = -1;
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        rigidBody.transform.Rotate(0, 0, 3, Space.Self);

        ScreenWrap();
    }    
}
