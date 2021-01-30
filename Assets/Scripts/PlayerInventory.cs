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
  public GameObject particleInstance;

  private GameObject objectCollition;
  private Inventory playerInventory;
  private GameObject aux;
  public GameObject Etex;
  public GameObject dometex;
  public GameObject MsgImg;
  public TMPro.TextMeshProUGUI textCount;
  public spawn spawner;

  public GameObject winScreen;
  void Start()
  {
    playerInventory = new Inventory();
    pickUpLostItem = false;
    pickUpFlag = false;
    //Debug.Log(playerInventory.getFlagsCount().ToString());

    playerInventory.setFlagInstance(flagInstance);
    playerInventory.lostItemsCount = spawner.g_numberToGears;
  }

  void Update()
  {
    if (pickUpFlag && Input.GetKeyDown(KeyCode.E))
    {
      //Debug.Log("FlagPicked");
      Destroy(objectCollition);

      playerInventory.takeFlag();


      pickUpFlag = false;
    }
    else if (pickUpLostItem && Input.GetKeyDown(KeyCode.E))
    {

      //Debug.Log("LostItemPicked");
      Destroy(objectCollition);

      playerInventory.takeLostItem();
      pickUpLostItem = false;
    }
    else if (Input.GetKeyDown(KeyCode.Q) && playerInventory.getFlagsCount() > 0)
    {

      // Debug.Log("DroppedFlag");
      playerInventory.DropInstanceFlag(playerInstance.transform.position);
      playerInventory.dropFlag();
      particleInstance.GetComponent<Renderer>().sortingLayerName = "Default";
      aux = GameObject.Instantiate(particleInstance, playerInstance.transform.position - new Vector3(0.45f, 0.93f, 0), particleInstance.transform.rotation);
      Destroy(aux, 1.5f);
    }

    textCount.text = "x" + playerInventory.lostItemsCount.ToString();

    // Win condition
    if (playerInventory.lostItemsCount  == 0) {
      winScreen.SetActive(true);
    }


  }



  //-------------- collisions -----------------//
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Flag"))
    {
    MsgImg.SetActive(true);
      MsgImg.GetComponent<SpriteRenderer>().sprite = Etex.GetComponent<SpriteRenderer>().sprite;
      pickUpFlag = true;
      objectCollition = collision.gameObject;
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Flag"))
    {
    MsgImg.SetActive(false);
      pickUpFlag = false;
      objectCollition = null;
    }
  }

  //-------------------- triggers ---------------------/
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("LostItem"))
    {
    MsgImg.SetActive(true);
      MsgImg.GetComponent<SpriteRenderer>().sprite = Etex.GetComponent<SpriteRenderer>().sprite;
      pickUpLostItem = true;
      objectCollition = collision.gameObject;
      //Debug.Log("OnTriggerEnterLostItem");
    }

    if (collision.gameObject.CompareTag("Dome"))
    {
      MsgImg.GetComponent<SpriteRenderer>().sprite = dometex.GetComponent<SpriteRenderer>().sprite;

    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("LostItem"))
    {
    MsgImg.SetActive(false);
      pickUpLostItem = false;
      objectCollition = null;
      //Debug.Log("OnTriggerExitLostItem");
    }
  }

}
