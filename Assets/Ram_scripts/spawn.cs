using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public int g_numberToGears;
    public int g_numberToCraters;
    public List<GameObject> g_elementToSpawn;
    public GameObject g_field;
    public Collider2D[] g_colliders;
    public float g_radius;


    void Start()
    {
        spawnObjects();
    }

    //Functión to spawn our objects that the user gives you
    public void spawnObjects()
    {
        //Restart the field
        destroyObjects();

        int total = g_numberToCraters + g_numberToGears;
        //Cicle for gears
        cicleForItems(total);
    }

    //Call this function if you want show a N number of items in screen
    private void cicleForItems(int numberOf)
    {
        int randomItem = 0;
        float screenX, screenY;

        Vector2 position = new Vector2(0, 0);
        GameObject toSpawn = new GameObject();
        MeshCollider collider = g_field.GetComponent<MeshCollider>();

        bool canSpawnHere = false;

        for (int i = 0; i < numberOf; ++i)
        {
            randomItem = Random.Range(0, g_elementToSpawn.Count);
            toSpawn = g_elementToSpawn[randomItem];

            screenX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            screenY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);

            position = new Vector2(screenX, screenY);

            canSpawnHere = PreventSpawnOverlap(position);

            if (!canSpawnHere)
            {
                while (!canSpawnHere)
                {
                    screenX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
                    screenY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);

                    position = new Vector2(screenX, screenY);

                    canSpawnHere = PreventSpawnOverlap(position);

                    if (canSpawnHere)
                    {
                        break;
                    }
                }
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

    bool PreventSpawnOverlap(Vector2 position)
    {
        g_colliders = Physics2D.OverlapCircleAll(transform.position, g_radius);

        for (int i = 0; i < g_colliders.Length; i++)
        {
            Vector2 centerPoint = g_colliders[i].bounds.center;
            float width = g_colliders[i].bounds.extents.x;
            float height = g_colliders[i].bounds.extents.y;
            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if ((position.x >= leftExtent) && 
                (position.x <= rightExtent))
            {
                if ((position.y >= lowerExtent) &&
                    (position.y <= upperExtent)) 
                {
                    return false;
                }
            }
        }
        return true;
    }
}
