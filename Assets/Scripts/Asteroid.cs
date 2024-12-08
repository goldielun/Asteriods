using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;

    float speed;
    float angle;

    Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = Random.Range(1f, 2f);
        angle = Random.Range(-180f * Mathf.Deg2Rad, 180f * Mathf.Deg2Rad);
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 change = direction * speed;
        rb.velocity = change;
    }
}
