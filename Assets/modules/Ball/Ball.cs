using UnityEngine;

public class Ball : MonoBehaviour
{
    float minusPlusOne()
    {
        return Random.Range(-1f, 1f);
    }

    Vector2 RandomVector(int speed)
    {
        return new Vector2(this.minusPlusOne() * speed, this.minusPlusOne() * speed);
    }

    void Start()
    {
        var speed = 1;
        var cam = Camera.main;
        var rb = GetComponent<Rigidbody2D>();
        var bottomLeftCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(0, 0));
        var topRightCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        this.transform.position = Vector2.Lerp(bottomLeftCorner, topRightCorner, 0.5f);
        rb.AddForce(this.RandomVector(speed), ForceMode2D.Impulse);

        GetComponent<SpriteRenderer>().enabled = true;
    }
}