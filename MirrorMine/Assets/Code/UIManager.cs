using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("InterfaceParameters")]
    public GameObject PressE;
    public GameObject MiningEvent;
    public Slider MiningSlider;

    private void Start()
    {
        instance = this;
    }
    public void ShowInteractionE()
    {
        PressE.SetActive(true);
    }
    public void DisableInteractionE()
    {
        PressE.SetActive(false);
    }
    public void ShowMiningEvent()
    {
        MiningEvent.SetActive(true);
    }
    public void DisableMiningEvent()
    {
        MiningEvent.SetActive(false);
    }
}
