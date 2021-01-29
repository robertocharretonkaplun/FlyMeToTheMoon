using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<GameObject> lostItems;
    private List<GameObject> flags; 

    private int lostItemsCount;      // How many lost items are remain to found
    private int flagsCount;           //how many items are in inventory 

    public Inventory()
    {
        lostItems = new List<GameObject>();
        flags = new List<GameObject>();
        lostItemsCount = 0;              // start with 0 items spawned 
        flagsCount = 3;                  // start with flags that u can use
    }



    public void AddLostItem(GameObject lostItem)    {
        lostItems.Add(lostItem);
    }
    public void addFlagList(GameObject lostItem)    {
        lostItems.Add(lostItem);
    }


    //------------------- getters ------------------------//
    public List<GameObject> getLostItemsList()  {
        return lostItems;
    }
    public List<GameObject> getFlagList()  {
        return flags;
    }
    public int  getFlagsCount()   {
        return flagsCount;
    }
    public int  getlostItemsCount() {
        return lostItemsCount;
    }

    //------------------- setters --------------------//

    public void setLostItemCount (int newLostItemCount)     { 
        lostItemsCount = newLostItemCount;
    }
    public void setFlagsCount(int newFlagCount)      { 
        flagsCount = newFlagCount;
    } 
}
