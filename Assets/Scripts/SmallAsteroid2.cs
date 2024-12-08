using UnityEngine;

public class SmallAsteroid2 : MonoBehaviour
{
    public GameObject explosion;

    AudioManager audioManager;

    int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Laser") || collider.CompareTag("Player"))
        {
            health--;
        }
    }
}
