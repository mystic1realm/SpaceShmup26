using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    public enum BoundsType
    {
        center,
        inset,
        offScreen
    }

    [Header("Inscribed")]
    public BoundsType boundsType = BoundsType.inset;
    public float radius = 1f;

    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        float offset = 0f;

        switch (boundsType)
        {
            case BoundsType.center:
                offset = 0f;
                break;

            case BoundsType.inset:
                offset = radius;
                break;

            case BoundsType.offScreen:
                offset = -radius;
                break;
        }

        if (pos.x > camWidth - offset)
        {
            pos.x = camWidth - offset;
        }

        if (pos.x < -camWidth + offset)
        {
            pos.x = -camWidth + offset;
        }

        if (pos.y > camHeight - offset)
        {
            pos.y = camHeight - offset;
        }

        if (pos.y < -camHeight + offset)
        {
            pos.y = -camHeight + offset;
        }

        transform.position = pos;
    }
}