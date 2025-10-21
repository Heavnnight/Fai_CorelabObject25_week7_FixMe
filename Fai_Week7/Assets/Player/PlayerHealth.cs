using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int health = 100;

    [Header("UI")]
    public TextMeshProUGUI healthText; // ???? ?? ?????? ???
    public GameObject gameOverUI;       // ???? Panel ?? Text ????? ??? GAME OVER (???? Disabled ????????)

    void Start()
    {
        Time.timeScale = 1f;                 // ???? ?? ????? ??? ?????
        if (gameOverUI) gameOverUI.SetActive(false);
        if (healthText) healthText.text = "Health: " + health;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;

        if (healthText) healthText.text = "Health: " + health;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (healthText) healthText.gameObject.SetActive(false);
        if (gameOverUI) gameOverUI.SetActive(true);
        Time.timeScale = 0f; // ????? ??????
    }
}
