using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//with timer
public class PowerUpRef : MonoBehaviour
{
    // Player Movement Variable Initialization
    private Rigidbody playerRb;



    public float jumpForce = 5.0f;

    // Power-up variables
    private bool isPoweredUp = false;
    private float powerUpDuration = 10f; // Duration of the power-up in seconds
    private float powerUpTimer;

    // Canvas Variables

    // Start Game Values

    int powerUp = 0;
    public Text powerUpcount;

    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        powerUpcount.text = "Power Up Count: 0";
        powerUpTimer = 0f;
    }

    // Called Once per frame
    void Update()
    {
        // If the player is powered up, update the timer
        if (isPoweredUp)
        {
            powerUpTimer -= Time.deltaTime;

            // Check if the power-up has expired
            if (powerUpTimer <= 0f)
            {
                EndPowerUp();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("energyBar"))
        {
            powerupSound.Play();
            other.gameObject.SetActive(false);
            powerUp += 1;
            SetPowerUpText();

            // Start the power-up effect
            StartPowerUp();
        }
    }

    void SetPowerUpText()
    {
        powerUpcount.text = "Power Up Count: " + powerUp.ToString();
    }

    void StartPowerUp()
    {
        // Activate the power-up effect
        isPoweredUp = true;

        // Set the power-up duration timer
        powerUpTimer = powerUpDuration;

        // Apply the power-up effect (e.g., increase speed)
        // You can customize this based on your power-up effects
        speed = runSpeed;

        // StartCoroutine(EndPowerUpCoroutine()); // Use this if you want to end the power-up with a coroutine
    }

    void EndPowerUp()
    {
        // Deactivate the power-up effect
        isPoweredUp = false;

        // Revert the changes made during the power-up
        speed = walkSpeed;
    }

    // Optional: If you want to use a coroutine to end the power-up after a delay
    IEnumerator EndPowerUpCoroutine()
    {
        yield return new WaitForSeconds(powerUpDuration);
        EndPowerUp();
    }
}
