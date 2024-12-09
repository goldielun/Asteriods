using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*float currentSpeed;
    float maxSpeed;

    float movementRate = 0.1f;
    public float dragCoefficient = 0.8f;

    //Vector3 dragForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = 0.0f;

        maxSpeed = currentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();

        MovementProcess();

        Rotation();
    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            maxSpeed = 1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            maxSpeed = 0.0f;
        }
    }

    void MovementProcess()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, movementRate * Time.deltaTime);
        Vector3 change = transform.up * currentSpeed;
        transform.position += change;

        //Vector3 dragForce = -change * dragCoefficient;
        //transform.position += dragForce;
    }*/

    public GameObject explosion;
    public GameObject bullet;

    Rigidbody2D rb;
    AudioManager audioManager;

    public float thrustPower;
    float maxSpeed = 10.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<PlayerShoot>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        Thrust();

        Rotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3 shootingposition = transform.position + transform.up;
            Instantiate(bullet, transform.position, transform.rotation);
            audioManager.PlaySFX(audioManager.fire);
        }
    }

    void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            audioManager.PlaySFX(audioManager.Engines);
            rb.AddForce(transform.up * thrustPower);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
          
        }
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, 150f * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -150f * Time.deltaTime, Space.Self);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Asteroid"))
        {

            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.explode);
            Destroy(gameObject);
        }
    }
}
