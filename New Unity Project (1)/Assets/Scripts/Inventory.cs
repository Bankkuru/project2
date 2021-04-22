using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<itemdo> itemList;

    public Inventory ()
    {
        itemList = new List<itemdo>();

      //  AddItem(new itemdo { itemType = itemdo.ItemType.Multiply, amount = 1 });
       // AddItem(new itemdo { itemType = itemdo.ItemType.Multiply, amount = 1 });
    }


    public void AddItem (itemdo item)
    {
        itemList.Add(item);
    }

    public List<itemdo> GetItemList()
    {
        return itemList;
    }
}
