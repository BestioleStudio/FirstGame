using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public class EnemyStats
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

    public EnemyStats stats = new EnemyStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start()
    {
        stats.Init();

        if( statusIndicator == null)
        {
            Debug.Log("nos status indicator refferenced on Enemy");
        } else
        {
            statusIndicator.setHealth(stats.currentHealth, stats.maxHealth);
        }
    }
    
    public void DamageEnemy(int damage)
    {
        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }

        statusIndicator.setHealth(stats.currentHealth, stats.maxHealth);
    }

}
