using UnityEngine;

public class LargeAsteroid2 : MonoBehaviour
{

    public GameObject explosion;
    public GameObject mediumAsteroid2;
    AudioManager audioManager;

    float spawnRadius = 1f;

    int health;

    Vector3 randomOffset1;
    Vector2 spawnPosition1;
    Vector3 randomOffset2;
    Vector2 spawnPosition2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        randomOffset1 = new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0f);
        spawnPosition1 = transform.position + randomOffset1;

        randomOffset2 = new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0f);
        spawnPosition2 = transform.position + randomOffset2;

        if (health < 1)
        {
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);
            GameObject.Instantiate(mediumAsteroid2, spawnPosition1, Quaternion.identity);
            GameObject.Instantiate(mediumAsteroid2, spawnPosition2, Quaternion.identity);
           
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Laser") || collider.CompareTag("Player"))
        {
            health--;
            

            /*GameObject.Instantiate(mediumAsteroid1, spawnPosition1, Quaternion.identity);
            GameObject.Instantiate(mediumAsteroid1, spawnPosition2, Quaternion.identity);
            Destroy(gameObject);*/
        }
    }

}
