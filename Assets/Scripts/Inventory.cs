using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
  public int lostItemsCount;      // How many lost items are remain to found
  private int flagsCount;           //how many items are in inventory 

  private GameObject flagInstance;

  
  public void setFlagInstance(GameObject newFlagInstance)
  {
    flagInstance = newFlagInstance;
  }


  public Inventory()
  {
    //lostItemsCount = spawner.g_numberToGears;              // start with 0 items spawned 
    flagsCount = 3;                  // start with flags that u can use

    int rand = 10;                     //make it random
    
  }

  public void DropInstanceFlag(Vector3 droptoPos)
  {
    GameObject.Instantiate(flagInstance, droptoPos, flagInstance.transform.rotation);
  }
  //Quaternion.identity

  //------------------- getters ------------------------//

  public int getFlagsCount()
  {
    return flagsCount;
  }
  public int getlostItemsCount()
  {
    return lostItemsCount;
  }

  //------------------- setters --------------------//

  public void takeFlag()
  {
    flagsCount++;
  }
  public void dropFlag()
  {
    flagsCount--;
  }
  public void takeLostItem()
  {
    lostItemsCount--;
  }

}
