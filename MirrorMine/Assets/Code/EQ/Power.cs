using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Power : MonoBehaviour
{
    public static Power instance;
    public Slider PowerSlider;
    public int DecreaseValue;
    public float TimeToDecrease;

    private TMP_Text Amount;

    private float Timer;
    private void Start()
    {
        Amount = PowerSlider.transform.Find("Amount").GetComponent<TMP_Text>();
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= TimeToDecrease)
        {
            PowerSlider.value -= DecreaseValue;
            Amount.text = PowerSlider.value.ToString() + "%";
            Timer = 0;
        }

    }
    public void RegenPower()
    {
        PowerSlider.value = 100;
    }
}
