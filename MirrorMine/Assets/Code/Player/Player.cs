using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [Header("Parameters Speed Mov Player")]
    public float SpeedMov;
    public float SpeedRotation;
    [Header("Parameters Mining Player")]
    public float SpeedMining;
    [HideInInspector]public float TimerSpeedMining;
    [Header("ObjectsPlayer")]
    public GameObject LightFlashLight;
    public GameObject player;
    [HideInInspector]public GameObject NewPosition;

    //ChangePositionPlayer
    [HideInInspector]public bool Change;
    private CharacterController chara;
    [HideInInspector]public Animator Anim;
    //UI Taps && Canvas
    Canvas Menu;
    Canvas EQ;
    int TapEQ;
    int TapMenu;

    //timers
    float timer;
    [HideInInspector]
    public bool BlockMovement;

    void Start()
    {
        instance = this;
        //
        chara = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        //
        EQ = GameObject.Find("EQ").GetComponent<Canvas>();
        Menu = GameObject.Find("Menu").GetComponent<Canvas>();
    }

    
    void Update()
    {       
        if (BlockMovement == true)
        {
            //blocking animation walking
            Anim.SetBool("Walking", false);
        }
        if (BlockMovement == false)
        {
            //MovementPlayer
            float horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");
            Vector3 Move = transform.forward * Vertical * SpeedMov * Time.deltaTime +
                transform.right * horizontal * SpeedMov * Time.deltaTime;

            //Gravity
            if (!chara.isGrounded)
            {
                Move.y -= 1f * Time.deltaTime;
            }

            chara.Move(Move);
            
            
            //RotiationPlayer
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdistance;
            if (playerPlane.Raycast(ray, out hitdistance))
            {
                Vector3 targetPoint = ray.GetPoint(hitdistance);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, SpeedRotation * Time.deltaTime);
            }


            if (horizontal > 0 || horizontal < 0 || Vertical > 0 || Vertical < 0)
            {
                Anim.SetBool("Walking", true);
            }
            else
            {
                Anim.SetBool("Walking", false);
            }
        }
        //AudioMovement
        if (Anim.GetBool("Walking") == false)
        {
            AudioManager.instance.PlaySounds("Footsteps");
        }
        //Open EQ
        if (Input.GetKeyDown(KeyCode.Tab) && Menu.enabled == false)
        {
            TapEQ++;
            if (TapEQ == 1)
            {
                //Audio
                AudioManager.instance.PlaySounds("OpenBackpack");
            }
            BlockMovement = true;
            EQ.enabled = true;
            if (TapEQ == 2)
            {
                TapEQ = 0;
                EQ.enabled = false;
                BlockMovement = false;
            }
        }
        //Open Menu
        if (Input.GetKeyDown(KeyCode.Escape) && EQ.enabled == false)
        {
            TapMenu++;
            Menu.enabled = true;
            BlockMovement = true;
            if (TapMenu == 2)
            {
                TapMenu = 0;
                Menu.enabled = false;
                BlockMovement = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Flashlight.instance.FlashPowerOn == true)
            {
                AudioManager.instance.PlaySounds("FlashLightOff");
                Flashlight.instance.FlashPowerOn = false;
                LightFlashLight.GetComponent<Light>().enabled = false;
            }
            else if (Flashlight.instance.FlashPowerOn == false)
            {
                AudioManager.instance.PlaySounds("FlashLightOn");
                Flashlight.instance.FlashPowerOn = true;
                LightFlashLight.GetComponent<Light>().enabled = true;
            }
        }


        //Change Position on new Scene
        if (Change == true)
        {
            NewPosition = GameObject.Find("PositionToRespawn");
            if (NewPosition != null)
            {
                player.transform.position = NewPosition.transform.position;
                timer += Time.deltaTime;
                if (timer >= 1)
                {
                    timer = 0;
                    Change = false;
                }
            }
        }
    }
    public void StartMiningAnimation(bool isMining)
    {
        Anim.SetBool("Digging", true);
        Anim.SetBool("Walking", false);
        //Audio
        AudioManager.instance.StopSounds("Footsteps");
        AudioManager.instance.PlaySounds("Digging");
    }
    public void EndMiningAnimation(bool isMining)
    {
        Anim.SetBool("Digging", false);
        AudioManager.instance.StopSounds("Digging");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShardOre"))
        {
            UIManager.instance.ShowInteractionE();
        }
        if (other.CompareTag("Shard"))
        {
            UIManager.instance.ShowInteractionE();
        }
        if (other.CompareTag("Bartender"))
        {
            UIManager.instance.ShowInteractionE();
        }
        if (other.CompareTag("Guard"))
        {
            UIManager.instance.ShowInteractionE();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ShardOre"))
        {
            other.GetComponent<ShardOre>().CollisionWithPlayer = true;
        }
        if (other.CompareTag("Shard"))
        {
            other.transform.GetComponent<Shard>().CollisionWithPlayer = true;
        }
        if (other.CompareTag("Bartender"))
        {
            other.GetComponent<Bartender>().CollisionWithPlayer = true;
        }
        if (other.CompareTag("Guard"))
        {
            other.GetComponent<Guard>().CollisionWithPlayer = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShardOre"))
        {
            UIManager.instance.DisableInteractionE();
            other.GetComponent<ShardOre>().CollisionWithPlayer = false;
        }
        if (other.CompareTag("Shard"))
        {
            UIManager.instance.DisableInteractionE();
            other.GetComponent<Shard>().CollisionWithPlayer = false;
        }
        if (other.CompareTag("Bartender"))
        {
            UIManager.instance.DisableInteractionE();
            other.GetComponent<Bartender>().CollisionWithPlayer = false;
        }
        if (other.CompareTag("Guard"))
        {
            UIManager.instance.DisableInteractionE();
            other.GetComponent<Guard>().CollisionWithPlayer = false;
        }
    }

    public void ChangePositionPlayerOnNewScene()
    {
        GameObject startTeleport = GameObject.Find("PositionToRespawn");
        player.transform.position = startTeleport.transform.position;
    }
}
