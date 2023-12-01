using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerUpdates : MonoBehaviour
{
    public GameObject Player;
    // Player rigid body input
    public Rigidbody playerRb;

    int powerUp, chestsCollected, livesCount;
    public Text powerUpCounter;
    public Text livesLeftCounter;
    public Text chestsCollectedCounter;
    public AudioSource powerUpSound, chestCollectedSound, playerDamagedSound, playerKillSound;

    void Start()
    {
        // Need to get component in the Start function
        playerRb = GetComponent<Rigidbody>();
        powerUp = 0;
        chestsCollected = 0;
        livesCount = 3;

        livesLeftCounter.text = "";
        powerUpCounter.text = "";
        chestsCollectedCounter.text = "";

        SetPowerUpText();
        SetChestsCollectedText();
        SetLivesLeftText();
    }

    // Update is called once per frame
    void Update()
    {
        // Leave it here
    }

    // OnTrigger should not be nested inside Update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("energyBar"))
        {
            powerUpSound.Play();
            other.gameObject.SetActive(false);
            powerUp += 1;
            SetPowerUpText();
        }
        else if (other.gameObject.CompareTag("chest"))
        {
            chestCollectedSound.Play();
            other.gameObject.SetActive(false);
            chestsCollected += 1;
            SetChestsCollectedText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            playerDamagedSound.Play();
            other.gameObject.SetActive(false);
            livesCount += 1;
            SetLivesLeftText();
        }
        else { 
            //nothing
        }
    }

    void SetPowerUpText()
    {
        powerUpCounter.text = "Power Up: " + powerUp.ToString();
        Debug.Log("Power Up Text Updated");
        Debug.Log(powerUpCounter.text);
    }

    void SetLivesLeftText()
    {
        livesLeftCounter.text = "Lives Left: " + livesCount.ToString();
        Debug.Log("Lives Left Text Updated");
        Debug.Log($"{livesLeftCounter.text}");
    }

    void SetChestsCollectedText()
    {
        chestsCollectedCounter.text = "Chests Collected: " + chestsCollected.ToString();
        Debug.Log("Chests Collected Text Updated");
        Debug.Log (chestsCollectedCounter.text);
    }

}
