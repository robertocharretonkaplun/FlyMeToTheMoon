using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5f;
  public Rigidbody2D rigidBody;
  public Animator animator;
  AudioSource audioSrc;
  Vector2 movement;
  bool isMoving = false;

  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
    audioSrc = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    animator.SetFloat("Speed", movement.sqrMagnitude);
    animator.SetFloat("Horizontal", movement.x);
    animator.SetFloat("Vertical", movement.y);

    if (movement.x == 0 && movement.y == 0)
    {
      isMoving = false;
    }
    else
    {
      isMoving = true;
    }

    if (isMoving)
    {
      if (!audioSrc.isPlaying)
      {
        audioSrc.Play();
      }
    }
    else
    {
      audioSrc.Stop();
    }


  }

  void FixedUpdate()
  {
    rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
    rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Crater"))
    {
      Debug.Log("Si paso We");
      moveSpeed /= 2;
    }
  }
  
  private void OnTriggerExit2D(Collider2D collision)
  {
    //if (collision.gameObject.name == "Crater")
    if (collision.gameObject.CompareTag("Crater"))
    {
      moveSpeed *= 2;
    }
  }
}
