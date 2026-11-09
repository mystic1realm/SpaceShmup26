using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 3f;

    // Damage dealt by each laser
    public float damage = 10f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();

        if (enemy != null)
        {
            // Reduce enemy health
            enemy.health -= damage;

            // Only destroy the enemy when health reaches zero
            if (enemy.health <= 0)
            {
                if (ScoreManager.S != null)
                {
                    ScoreManager.S.AddScore(enemy.score);
                    ScoreManager.S.PlayExplosion();
                }

                Destroy(enemy.gameObject);
            }

            // The projectile disappears after hitting
            Destroy(gameObject);
        }
    }
}