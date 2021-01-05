
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    bool isBottom = false;

    int offset = 1;
    Camera cam;

    void Start()
    {
        this.cam = Camera.main;
        var bottomLeftCorner = (Vector2)this.cam.ScreenToWorldPoint(new Vector2(0, 0));
        var topRightCorner = (Vector2)this.cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var bottomRightCorner = (Vector2)this.cam.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        var width = Vector2.Distance(bottomLeftCorner, bottomRightCorner);
        var center = Vector2.Lerp(bottomLeftCorner, topRightCorner, 0.5f);

        this.transform.localScale = new Vector2(width / 3, 0.5f);
        this.transform.position = new Vector2(center.x, this.isBottom ? bottomLeftCorner.y + this.offset : topRightCorner.y - this.offset);

        GetComponent<SpriteRenderer>().enabled = true;
    }
}