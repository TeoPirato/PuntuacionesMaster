using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundScroller : MonoBehaviour
{
    [Header("Velocity")]
    [SerializeField] float horizontal = .05f;
    [SerializeField] float vertical = .05f;

    RawImage image;

    void Start()
    {
        image = GetComponent<RawImage>();
    }

    void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + Time.deltaTime * new Vector2(horizontal, vertical), image.uvRect.size);
    }
}
