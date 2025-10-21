using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Settings")]
    public int health = 100;

    [Header("UI References")]
    public TextMeshProUGUI healthText;   
    public GameObject gameOverUI;       
    public GameObject restartButton; 

    void Start()
    {
        Time.timeScale = 1f;

        
        if (gameOverUI != null) gameOverUI.SetActive(false);
        if (restartButton != null) restartButton.SetActive(false);

        if (healthText != null)
            healthText.text = "Health: " + health;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
            TakeDamage(10);
    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;

        if (healthText != null)
            healthText.text = "Health: " + health;

        if (health <= 0)
            GameOver();
    }

    void GameOver()
    {
        if (healthText != null) healthText.gameObject.SetActive(false);
        if (gameOverUI != null) gameOverUI.SetActive(true);
        if (restartButton != null) restartButton.SetActive(true);

        Time.timeScale = 0f; // عشان توقف اللعبه
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
