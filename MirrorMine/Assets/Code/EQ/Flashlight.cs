using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public static Flashlight instance;
    public Slider FlashSlider;
    public int DecreaseValue;
    public float TimeToDecrease;
    [HideInInspector]public bool FlashPowerOn = true;

    private TMP_Text Amount;
    private float Timer;
    private void Start()
    {
        instance = this;
        Amount = FlashSlider.transform.Find("Amount").GetComponent<TMP_Text>();
    }
    
    private void Update()
    {
        if (FlashPowerOn == true && FlashSlider.value > 0)
        {
            Timer += Time.deltaTime;
            if (Timer >= TimeToDecrease)
            {
                FlashSlider.value -= DecreaseValue;
                Amount.text = FlashSlider.value.ToString() + "%";
                Timer = 0;
            }
        }
        if (FlashSlider.value <= 0)
        {
            Player.instance.LightFlashLight.GetComponent<Light>().enabled = false;
        }
    }

    public void RegenBatteries()
    {
        FlashSlider.value = 100;
    }
    
}
