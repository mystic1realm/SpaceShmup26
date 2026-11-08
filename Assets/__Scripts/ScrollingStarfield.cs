using UnityEngine;

public class ScrollingStarfield : MonoBehaviour
{
    public float scrollSpeed = 0.1f;

    private Material starfieldMaterial;
    private Vector2 offset;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        starfieldMaterial = rend.material;
    }

    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime;
        starfieldMaterial.mainTextureOffset = offset;
    }
}
