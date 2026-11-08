using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S {get; private set;}

    [Header("Inscribed")]

    public float speed = 30f;

    public GameObject projectilePrefab;
    public float fireDelay = 0.2f;

    private float nextFireTime = 0f;

    public float rollMult = -45f;

    public float pitchMult = 30f;

    [Header("Dynamic")] [Range(0, 4)]

    public float shieldLevel = 1;


    // Update is called once per frame
    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(vAxis*pitchMult, hAxis*rollMult, 0);

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireDelay;
        }
    }

      void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();

        if (enemy != null)
        {
            shieldLevel--;

            Destroy(enemy.gameObject);

            Debug.Log("Hero hit! Shield Level: " + shieldLevel);

            if (shieldLevel <= 0)
            {
                Debug.Log("Game Over!");
                Destroy(gameObject);
            }
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("Projectile prefab is not assigned!");
            return;
        }

        Vector3 spawnPos = transform.position + Vector3.up * 1.5f;
        Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
    }
}
