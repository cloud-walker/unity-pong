using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    bool isNorth = true;

    Vector2 offset = new Vector2(0, 0.5f);

    void Start()
    {
        var cam = Camera.main;
        var bottomLeftCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(0, 0));
        var topRightCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var bottomRightCorner = new Vector2(topRightCorner.x, bottomLeftCorner.y);
        var width = Vector2.Distance(bottomLeftCorner, bottomRightCorner);

        this.transform.localScale = new Vector2(width, 1);

        this.transform.position = isNorth
            ? new Vector2(0, topRightCorner.y) + this.offset
            : new Vector2(0, bottomLeftCorner.y) - this.offset;

        GetComponent<SpriteRenderer>().enabled = true;
    }
}