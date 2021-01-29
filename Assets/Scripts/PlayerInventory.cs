using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //private Inventory playerInventory = new Inventory();
    private bool pickUpLostItem;
    private bool pickUpFlag;

    GameObject objectCollition;

    // Start is called before the first frame update
    void Start()
    {
        pickUpLostItem = false;
        pickUpFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (pickUpFlag && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("FlagPicked");
            Destroy(objectCollition);
        }
        if (pickUpLostItem && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("LostItemPicked");
            Destroy(objectCollition);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("flag"))
        {
            pickUpFlag = true;
            objectCollition = collision.gameObject;
        }
        if (collision.gameObject.name.Equals("itemLost"))
        {
            pickUpLostItem = true;
            Debug.Log("ItemLost is True");
            objectCollition = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("flag"))
        {
            pickUpFlag = false;
            Debug.Log("Flag is False");
            objectCollition = null;
        }
        else if (collision.gameObject.name.Equals("ItemLost"))
        {
            pickUpLostItem = false;
            Debug.Log("ItemLost is False");
            objectCollition = null;
        }
    }
}
