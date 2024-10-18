using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] float invicibilityTime = 2f;
    bool invincible = false;

    void DisableInvincibility()
    {
        invincible = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (invincible == true)
            {
                return;
            }
            if (playerHealth > 0)
            {
                playerHealth--;
                invincible = true;
                Invoke("DisableInvincibility", invicibilityTime);
                Debug.Log("Player's Health: " + playerHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
