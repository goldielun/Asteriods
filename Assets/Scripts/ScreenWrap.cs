using UnityEngine;

public class ScreenWrap : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        float rightSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

        float topOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        if (screenPos.x <= 0 && rb.velocity.x < 0)
        {
            transform.position = new Vector2(rightSideOfScreen, transform.position.y);
        }
        else if (screenPos.x >= Screen.width && rb.velocity.x > 0)
        {
            transform.position = new Vector2(leftSideOfScreen, transform.position.y);
        }
        else if (screenPos.y <= 0 && rb.velocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, topOfScreen);
        }
        else if (screenPos.y >= Screen.height && rb.velocity.y > 0)
        {
            transform.position = new Vector2(transform.position.x, bottomOfScreen);
        }
    }
}
