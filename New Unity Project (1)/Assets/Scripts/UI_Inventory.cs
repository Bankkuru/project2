using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;



    private void Awake()
    {
      //  itemSlotContainer = transform.Find("itemSlotContainer");
      //  itemSlotTemplate = itemSlotTemplate.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefeshInventoryItem();
    } 

 private void RefeshInventoryItem()
    {
      
       

         foreach (itemdo item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            

        }
    }

}
