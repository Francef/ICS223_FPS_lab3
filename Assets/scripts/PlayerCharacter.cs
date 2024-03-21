using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    public int maxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit()
    {
        health -= 1;
        Debug.Log("Health: " + health);
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, ((float)health / maxHealth));
        if (health <= 0)
        {
            //Debug.Break();
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }
    }

    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }

    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }

    public void OnPickupHealth(int healthAdded)
    {
        health += healthAdded;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        float healthPercent = ((float)health / maxHealth);
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
    }
}
