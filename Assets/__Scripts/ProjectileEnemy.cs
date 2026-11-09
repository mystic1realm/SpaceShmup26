using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public float speed = 12f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move downward toward the Hero
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Hero hero = other.GetComponentInParent<Hero>();
        if (hero != null)
        {
            hero.TakeDamage();
            Destroy(gameObject);
        }
    }
}
