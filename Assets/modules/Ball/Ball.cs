using UnityEngine;

public class Ball : MonoBehaviour
{
    void Start()
    {
        var cam = Camera.main;
        var bottomLeftCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(0, 0));
        var topRightCorner = (Vector2)cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        this.transform.position = Vector2.Lerp(bottomLeftCorner, topRightCorner, 0.5f);

        GetComponent<SpriteRenderer>().enabled = true;
    }
}