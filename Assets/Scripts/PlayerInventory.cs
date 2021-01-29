using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //private Inventory playerInventory = new Inventory();
    private bool pickUpLostItem;
    private bool pickUpFlag;

    public GameObject playerInstance;
    public GameObject flagInstance;

    private GameObject objectCollition;
    private Inventory playerInventory;

   


    void Start()
    {
        playerInventory = new Inventory();
        pickUpLostItem = false;
        pickUpFlag = false;
        Debug.Log(playerInventory.getFlagsCount().ToString());

        playerInventory.setFlagInstance(flagInstance);
    }

    void Update()
    {
        if (pickUpFlag && Input.GetKeyDown(KeyCode.E)  )
        {
            Debug.Log("FlagPicked");
            Destroy(objectCollition);

            playerInventory.takeFlag();
            pickUpFlag = false;
        }
        else if (pickUpLostItem && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("LostItemPicked");
            Destroy(objectCollition);

            playerInventory.takeLostItem();
            pickUpLostItem = false;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && playerInventory.getFlagsCount() > 0)
        {
            
            Debug.Log("DroppedFlag");
            playerInventory.DropInstanceFlag(playerInstance.transform.position);
            playerInventory.dropFlag();
        }
    }



    //-------------- collisions -----------------//
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flag"))
        {
            pickUpFlag = true;
            objectCollition = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("LostItem"))
        {
            pickUpLostItem = true;
            objectCollition = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flag"))
        {
            pickUpFlag = false;
            objectCollition = null;
        }
        else if (collision.gameObject.CompareTag("LostItem"))
        {
            pickUpLostItem = false;
            objectCollition = null;
        }
    }
}
