using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed; 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Asteroid"))
        {
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject); 
            Destroy(collider.gameObject);
        }
    }

    void Update()
    {
        Destroy(gameObject, 2);
    }
}
