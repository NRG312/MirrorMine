using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemPrefab : MonoBehaviour
{
    [HideInInspector]
    public Item item;
    private Image image;

    private TMP_Text AmountTxt;
    private int AmountItem = 1;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        AmountTxt = transform.Find("Amount").GetComponent<TMP_Text>();
        AmountTxt.transform.gameObject.SetActive(true);
        AmountTxt.text = "X" + AmountItem.ToString();
    }
    public void SwitchParameters(Item Item)
    {
        item = Item;
        image.sprite = Item.ImageItemInEQ;
    }
    public void AddAmount(int amount)
    {
        AmountTxt = transform.Find("Amount").GetComponent<TMP_Text>();
        AmountItem += amount;
        AmountTxt.text = "X" + AmountItem.ToString();
    }
}
