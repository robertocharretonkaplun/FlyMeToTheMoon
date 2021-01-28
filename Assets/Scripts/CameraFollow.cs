using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [Header("Camera Attributes")]
  public GameObject target;
  public Vector3 offset;
  [Range(1, 10)]
  public float smoothFactor;
  private void FixedUpdate() {
    follow();
  }

  void follow()  {
    Vector3 targetPos = target.transform.position + offset;
    Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
    transform.position = smoothPos;

  }
}
