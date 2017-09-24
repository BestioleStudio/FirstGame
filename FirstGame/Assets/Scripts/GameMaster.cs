using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
    }

    public static void KillEnemy( EnemyScript enemy )
    {
        Destroy(enemy.gameObject);
    }
}
