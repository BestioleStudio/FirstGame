using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _currentHealth;
        public int currentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            currentHealth = maxHealth;
        }
    }

    public PlayerStats stats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start()
    {
        stats.Init();

        if( statusIndicator == null)
        {
            Debug.Log("nos status indicator refferenced on Player");
        } else
        {
            statusIndicator.setHealth(stats.currentHealth, stats.maxHealth);
        }
    }
    
    public void DamagePlayer(int damage)
    {
        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }

        statusIndicator.setHealth(stats.currentHealth, stats.maxHealth);
    }
}
