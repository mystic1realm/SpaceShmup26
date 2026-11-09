using UnityEngine;

[RequireComponent ( typeof(BoundsCheck))]

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]

    public float speed = 10;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;
    public GameObject projectilePrefab;

    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos {
        get {
            return this.transform.position;
        }
        set {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();
        if ( bndCheck.LocIs( BoundsCheck.eScreenLocs.offDown ) )
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void Shoot()
    {
        if (projectilePrefab == null)
        {
            return;
        }
        
        Vector3 spawnPos = transform.position + Vector3.down * 1.5f;
        Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
    }

    void Start()
    {
        if (projectilePrefab != null && fireRate > 0)
        {
            InvokeRepeating(nameof(Shoot), 1f / fireRate, 1f / fireRate);
        }
    }
}