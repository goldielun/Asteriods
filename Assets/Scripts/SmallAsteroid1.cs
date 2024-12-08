using UnityEngine;

public class SmallAsteroid1 : MonoBehaviour
{
    public GameObject explosion;

    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Laser") || collider.CompareTag("Player"))
        {
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);

            Destroy(gameObject);
        }
    }

}
