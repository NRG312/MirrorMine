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

    private CharacterController chara;

    //UI Taps && Canvas
    Canvas Menu;
    Canvas EQ;
    int TapEQ;
    int TapMenu;
    [HideInInspector]
    public bool BlockMovement;

    void Start()
    {
        instance = this;
        //
        chara = GetComponent<CharacterController>();
        //
        EQ = GameObject.Find("EQ").GetComponent<Canvas>();
        Menu = GameObject.Find("Menu").GetComponent<Canvas>();
    }

    
    void Update()
    {
        if (BlockMovement == false)
        {
            //MovementPlayer
            float horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            Vector3 Move = transform.forward * Vertical * SpeedMov * Time.deltaTime +
                transform.right * horizontal * SpeedMov * Time.deltaTime;

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
        }

        //Open EQ
        if (Input.GetKeyDown(KeyCode.Tab) && Menu.enabled == false)
        {
            TapEQ++;
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
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ShardOre"))
        {
            other.GetComponent<ShardOre>().CollisionWithPlayer = true;
        }
        if (other.CompareTag("Shard"))
        {
            other.GetComponent<Shard>().CollisionWithPlayer = true;
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
    }
}
