using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    public int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit Enemy");

            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                enemy.DamageEnemy(damage);
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit myself");

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.DamagePlayer(damage);
            }
        }
    }
}
