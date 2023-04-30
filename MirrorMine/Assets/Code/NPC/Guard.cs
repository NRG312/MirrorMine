using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Guard : MonoBehaviour
{
    public string[] Texts;
    [HideInInspector]
    public TMP_Text MainText;
    [HideInInspector]
    public Canvas UiConversation;
    [HideInInspector]
    public bool CollisionWithPlayer;
    [Header("ConversationButton")]
    public TMP_Text nextLevel;

    private GameObject PositionGuard;

    private bool Pass2Level;
    private void Start()
    {
        MainText = GameObject.Find("UIConversationGuard").transform.Find("MainText").GetComponent<TMP_Text>();
        UiConversation = GameObject.Find("UIConversationGuard").GetComponent<Canvas>();
    }
    private void Update()
    {
        if (CollisionWithPlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlaySounds("GuardSound");
                Player.instance.BlockMovement = true;
                StartConversation();
                CollisionWithPlayer = false;
            }
        }
        if (SceneManager.GetActiveScene().name == "Pub")
        {
            PositionGuard = GameObject.Find("GuardPosition");
            transform.position = PositionGuard.transform.position;
        }
        else
        {
            transform.position = new Vector3(0, -50, 0);
        }
    }
    public void StartConversation()
    {
        UiConversation.enabled = true;
        string pickeduptext = Texts[Random.Range(0, Texts.Length)];
        MainText.text = pickeduptext;
    }
    public void EndConversation()
    {
        Player.instance.BlockMovement = false;
    }
    public void NextLevel()
    {
        if (Pass2Level == true)
        {
            SceneManager.LoadScene("EndingScene");
            AudioManager.instance.StopSounds("TavernSounds");
            AudioManager.instance.StopSounds("CaveSounds");
        }
        else
        {
            GameObject.Find("UIConversationGuard").GetComponent<Canvas>().enabled = false;
            AudioManager.instance.isPub = false;
            AudioManager.instance.isLevel1 = false;
            AudioManager.instance.isLevel2 = true;
            AudioManager.instance.CheckingScenesForMusic();

            Player.instance.Change = true;
            SceneManager.LoadScene("Level 2");
            Player.instance.BlockMovement = false;
            Pass2Level = true;
            nextLevel.text = "End Game";
        }
    }
}
