using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;
    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;
    public GameObject bulletPrefab;
    public GameObject shieldVisual;
    public AudioClip powerUpSound;
    public AudioClip powerDownSound;
    public AudioClip shootSound;       
    private AudioSource audioSource;
    private bool isShieldActive = false;

    void Start()
    {
        playerSpeed = 6f;
        audioSource = GetComponent<AudioSource>();

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    void Shooting()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

            
            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        float clampedY = Mathf.Clamp(transform.position.y, -verticalScreenLimit, 0f);
        transform.position = new Vector3(transform.position.x, clampedY, 0f);

        if (transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        else if (transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }
    }

    public void ActivateShield()
    {
        isShieldActive = true;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        if (audioSource != null && powerUpSound != null)
        {
            audioSource.PlayOneShot(powerUpSound);
        }

        CancelInvoke("DeactivateShield");
        Invoke("DeactivateShield", 5f);
    }

    public void DeactivateShield()
    {
        if (!isShieldActive) return;

        isShieldActive = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }

        if (audioSource != null && powerDownSound != null)
        {
            audioSource.PlayOneShot(powerDownSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.GetComponent<Enemy>() != null || other.GetComponent<Enemy2>() != null)
        {
            Destroy(other.gameObject);

            if (isShieldActive)
            {
                CancelInvoke("DeactivateShield");
                DeactivateShield();
            }
            else
            {
                Debug.Log("Player took damage!");
            }
        }
    }
}
