using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    bool isWest = true;

    float offset = 0.5f;

    void Start()
    {
        var cam = Camera.main;
        var bottomLeftCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(0, 0));
        var topRightCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var height = Vector2.Distance(bottomLeftCorner, new Vector2(bottomLeftCorner.x, topRightCorner.y));

        this.transform.localScale = new Vector2(1, height);
        this.transform.position = new Vector2(this.isWest ? bottomLeftCorner.x - this.offset : topRightCorner.x + this.offset, 0);

        GetComponent<SpriteRenderer>().enabled = true;
    }
}