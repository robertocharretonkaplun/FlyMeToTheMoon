using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
  public int g_numberToGears;
  public int g_numberToCraters;
  public List<GameObject> g_elementToSpawn;
  public GameObject g_field;

  void Start()
  {
    spawnObjects();
  }

  //Functión to spawn our objects that the user gives you
  public void spawnObjects()
  {
    //Restart the field
    destroyObjects();

    //Cicle for gears
    cicleForItems(g_numberToCraters);
    //Cicle for craters
    cicleForItems(g_numberToCraters);
  }

  //Call this function if you want show a N number of items in screen
  private void cicleForItems(int numberOf)
  {
    int randomItem = 0;
    float screenX, screenY;

    Vector3 position;
    GameObject toSpawn;
    MeshCollider collider = g_field.GetComponent<MeshCollider>();

    for (int i = 0; i < numberOf; ++i)
    {
      randomItem = Random.Range(0, g_elementToSpawn.Count);
      toSpawn = g_elementToSpawn[randomItem];

      screenX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
      screenY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);

      position = new Vector3(screenX, screenY, 1);

      if (toSpawn.CompareTag("Crater"))
      {
        float size = Random.Range(1, 3);
        toSpawn.gameObject.transform.localScale = new Vector3(size, size);
      }
      Instantiate(toSpawn, position, toSpawn.transform.rotation);
    }
  }

  private void destroyObjects()
  {
    foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawneable"))
    {
      Destroy(o);
    }
  }
}
