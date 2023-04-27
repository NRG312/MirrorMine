using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQFunction : MonoBehaviour
{
    public static EQFunction instance;
    public GameObject[] Slots;
    public GameObject ItemPrefab;

    private void Start()
    {
        instance = this;
    }
    public void AddItemToEQ(Item item)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            GameObject CheckSlot = Slots[i];
            if (CheckSlot.GetComponentInChildren<ItemPrefab>() == false)
            {
                GameObject CreatedItem = Instantiate(ItemPrefab, CheckSlot.transform);
                CreatedItem.GetComponent<ItemPrefab>().SwitchParameters(item);
                return;
            }
            else if (CheckSlot.GetComponentInChildren<ItemPrefab>() == true &&
                CheckSlot.GetComponentInChildren<ItemPrefab>().item == item)
            {
                CheckSlot.GetComponentInChildren<ItemPrefab>().AddAmount(1);
                return;
            }
        }
    }
}
