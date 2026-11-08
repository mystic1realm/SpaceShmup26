using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 3f;

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
            // Add the enemy's point value to the score
            if (ScoreManager.S != null)
            {
                ScoreManager.S.AddScore(enemy.score);
            }
            
            Destroy(enemy.gameObject);
            Destroy(gameObject);
        }
    }
}
