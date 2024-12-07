using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed; // Move the bullet in the direction it's facing (up in 2D)
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Asteroid"))
        {
            // Instantiate explosion or apply damage here
            Destroy(gameObject); // Destroy bullet on collision
        }
    }
}
