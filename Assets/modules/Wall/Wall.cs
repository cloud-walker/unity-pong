using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    bool isWest = true;

    Vector2 offset = new Vector2(0.5f, 0);

    void Start()
    {
        var cam = Camera.main;
        var bottomLeftCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(0, 0));
        var topRightCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var height = Vector2.Distance(bottomLeftCorner, new Vector2(bottomLeftCorner.x, topRightCorner.y));


        this.transform.localScale = new Vector2(1, height);

        this.transform.position = isWest
            ? new Vector2(bottomLeftCorner.x, 0) - this.offset
            : new Vector2(topRightCorner.x, 0) + this.offset;

        GetComponent<SpriteRenderer>().enabled = true;
    }
}