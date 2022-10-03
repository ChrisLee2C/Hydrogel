using UnityEngine;

public class Resize : MonoBehaviour
{
    [SerializeField] private RectTransform canvas;
    private BoxCollider2D boxCollider2D;
    private float sizeX;
    private float sizeY;
    private float max;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        sizeX = boxCollider2D.size.x;
        sizeY = boxCollider2D.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(sizeX > sizeY)
        {
            sizeX = canvas.rect.width;
            boxCollider2D.size = new Vector2(sizeX,sizeY);
        }
        else
        {
            sizeY = canvas.rect.height;
            boxCollider2D.size = new Vector2(sizeX, sizeY);
        }
    }
}
