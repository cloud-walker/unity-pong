using UnityEngine;

public class PaddlePlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 lastMousePosition;
    Camera cam;
    Vector2 force = Vector2.zero;

    void Start()
    {
        this.cam = Camera.main;
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.AddForce(new Vector2(1000f, 0f), ForceMode2D.Impulse);
    }

    Vector2 GetWorldMousePosition()
    {
        return this.cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDown()
    {
        this.lastMousePosition = this.GetWorldMousePosition();
        this.rb.velocity = Vector2.zero;
    }

    void OnMouseDrag()
    {
        var mousePosition = this.GetWorldMousePosition();
        var delta = mousePosition - this.lastMousePosition;
        this.force = delta;
        this.lastMousePosition = mousePosition;
    }

    void OnMouseUp()
    {
        this.force = Vector2.zero;
    }

    void FixedUpdate()
    {
        this.rb.AddForce(this.force * this.rb.mass * 2, ForceMode2D.Impulse);
    }
}