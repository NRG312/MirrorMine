using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="Item",menuName ="NewItem")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Image ImageItemInEQ;
    public GameObject Mineral;

}
