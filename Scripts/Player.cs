using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerComponent,IHitable
{
    public GameObject deathScreen, winScreen;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth = 50;
        Debug.Log(health);
    }

    public void Hit(float value)
    {
        //Debug.Log(value);
        HealthChange(value);
    }

    public float GetHealth()
    {
        return this.health;
    }

    public void SetHealth(float value)
    {
        this.health = health + value;

    }

    public void HealthChange(float value)
    {
        if (GetHealth() + value > 0)
        {
            SetHealth(value);
            healthBar.fillAmount = health / maxHealth;
        }
        else
        {
            FindObjectOfType<GameSupervisor>().CheckGameState();
            healthBar.fillAmount = 0;
            deathScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
