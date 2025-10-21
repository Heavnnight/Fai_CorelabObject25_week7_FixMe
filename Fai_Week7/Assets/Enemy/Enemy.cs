using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public float speedFactor = 1f;

    private HurtSound hurtSound;

    void Awake()
    {
        hurtSound = FindFirstObjectByType<HurtSound>();
    }

    void Update()
    {
        transform.position += new Vector3(xSpeed, ySpeed, 0f) * speedFactor * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (hurtSound != null)
            hurtSound.DisplayARandomHurtText();
    }
}
