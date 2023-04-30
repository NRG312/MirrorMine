using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bartender : MonoBehaviour
{
    public string[] Texts;
    [HideInInspector]
    public TMP_Text MainText;
    [HideInInspector]
    public Canvas UiConversation;
    [HideInInspector]
    public bool CollisionWithPlayer;
    private void Start()
    {
        MainText = GameObject.Find("UIConversationBartender").transform.Find("MainText").GetComponent<TMP_Text>();
        UiConversation = GameObject.Find("UIConversationBartender").GetComponent<Canvas>();
    }
    private void Update()
    {
        if (CollisionWithPlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlaySounds("BartenderSound");
                Player.instance.BlockMovement = true;
                StartConversation();
                CollisionWithPlayer = false;
            }
        }
    }
    public void StartConversation()
    {
        UiConversation.enabled = true;
        string pickeduptext = Texts[Random.Range(0,Texts.Length)];
        MainText.text = pickeduptext;      
    }
    public void EndConversation()
    {
        Player.instance.BlockMovement = false;
    }
    public void SellCrystals()
    {
        EQFunction.instance.SellForCoins();
        AudioManager.instance.PlaySounds("BuySomething");
    }
    public void BuyPower()
    {
        if (EQFunction.instance.AmountCoins >= 10)
        {
            Power.instance.PowerSlider.value = 100;
            EQFunction.instance.BuySomething(10);
            AudioManager.instance.PlaySounds("BuySomething");
        }
        else
        {
            Debug.Log("brak hajsu");
        }
    }
    public void BuyBatteries()
    {
        if (EQFunction.instance.AmountCoins >= 20)
        {
            Flashlight.instance.FlashSlider.value = 100;
            EQFunction.instance.BuySomething(20);
            AudioManager.instance.PlaySounds("BuySomething");
        }
        else
        {
            Debug.Log("brak hajsu");
        }
    }
}
