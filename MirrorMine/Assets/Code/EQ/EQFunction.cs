using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EQFunction : MonoBehaviour
{
    public static EQFunction instance;
    public GameObject[] Slots;
    public GameObject ItemPrefab;

    [Header("Coins")]
    public int AmountCoins;
    public TMP_Text CoinsTxt;
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
    public void SellForCoins()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            GameObject Slot = Slots[i];
            if (Slot.GetComponentInChildren<ItemPrefab>() == true)
            {
                AmountCoins += Slot.GetComponentInChildren<ItemPrefab>().AmountItem * 2;
                Destroy(Slot.transform.GetChild(0).gameObject);
                CoinsTxt.text = "Coins: " + AmountCoins.ToString();
            }
        }
    }
    public void BuySomething(int amount)
    {
        AmountCoins -= amount;
        CoinsTxt.text = "Coins: " + AmountCoins.ToString();
    }
}
