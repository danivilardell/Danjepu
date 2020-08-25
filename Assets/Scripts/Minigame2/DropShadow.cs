using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropShadow : MonoBehaviour
{
    public Vector2 ShadowOffset;
    public Material ShadowMaterial;

    SpriteRenderer spriteRenderer;
    public GameObject shadowGameobject;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        shadowGameobject = new GameObject("Shadow");

        SpriteRenderer shadowSpriteRenderer = shadowGameobject.AddComponent<SpriteRenderer>();

        shadowSpriteRenderer.sprite = null;
        shadowSpriteRenderer.material = ShadowMaterial;

        shadowSpriteRenderer.sortingLayerName = spriteRenderer.sortingLayerName;
        shadowSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;
    }

    void LateUpdate()
    {
        shadowGameobject.transform.localPosition = transform.localPosition + (Vector3)ShadowOffset;
        shadowGameobject.transform.localRotation = transform.localRotation;
    }
}