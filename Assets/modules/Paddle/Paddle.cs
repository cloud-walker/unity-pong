
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    bool isPlayer = false;

    int offset = 1;

    Vector2? lastMousePosition;

    Camera cam;

    Rigidbody2D rb;

    void HandlePlayerMovement()
    {
        if (!this.isPlayer)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            var mousePosition = this.cam.ScreenToWorldPoint(Input.mousePosition);

            if (this.lastMousePosition != null)
            {
                var delta = new Vector2(mousePosition.x - (float)this.lastMousePosition?.x, 0f);
                this.rb.velocity += delta;
            }

            this.lastMousePosition = mousePosition;
        }
        else
        {
            this.lastMousePosition = null;
        }
    }

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.cam = Camera.main;
        var bottomLeftCorner = (Vector2)this.cam.ScreenToWorldPoint(new Vector2(0, 0));
        var topRightCorner = (Vector2)this.cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var bottomRightCorner = (Vector2)this.cam.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        var width = Vector2.Distance(bottomLeftCorner, bottomRightCorner);
        var center = Vector2.Lerp(bottomLeftCorner, topRightCorner, 0.5f);

        this.transform.localScale = new Vector2(width / 4, 0.5f);
        this.transform.position = new Vector2(center.x, this.isPlayer ? bottomLeftCorner.y + this.offset : topRightCorner.y - this.offset);

        GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update()
    {
        this.HandlePlayerMovement();
    }
}