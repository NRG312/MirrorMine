using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShardOre : MonoBehaviour
{
    public Item item;

    public Slider MiningEvent;
    private bool isMining;
    
    [HideInInspector]
    public bool CollisionWithPlayer;
    private void RefreshTimerMining()
    {
        Player.instance.TimerSpeedMining = Player.instance.SpeedMining;
    }
    private void Update()
    {
        if (CollisionWithPlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isMining = true;
                MiningEvent = UIManager.instance.MiningSlider;
                UIManager.instance.DisableInteractionE();
                UIManager.instance.ShowMiningEvent();

                RefreshTimerMining();
                CollisionWithPlayer = false;
            }
        }
        if (isMining == true)
        {
            Player.instance.BlockMovement = true;
            MiningEvent.value = Player.instance.TimerSpeedMining;
            
            if (Player.instance.TimerSpeedMining > 0)
            {
                Player.instance.TimerSpeedMining -= Time.deltaTime;
            }
            else if (Player.instance.TimerSpeedMining <= 0)
            {
                Player.instance.TimerSpeedMining = Player.instance.SpeedMining;
                Player.instance.BlockMovement = false;
                isMining = false;

                GameObject Shard = Instantiate(item.Mineral, transform.position,Quaternion.identity,GameObject.Find("Shards").transform);
                Shard.AddComponent<Shard>();

                Destroy(gameObject);
            }
        }
    }
    public void OnDestroy()
    {
        Player.instance.TimerSpeedMining = Player.instance.SpeedMining;
    }
}
