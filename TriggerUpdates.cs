using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TriggerUpdates : MonoBehaviour
{
    public GameObject Player;

    private Rigidbody playerRb;

    int powerUp, chestsCollected, livesCount, kills;
    public Text powerUpCounter;
    public Text livesLeftCounter;
    public Text chestsCollectedCounter;
    public Text powerUpTimerCounter;
    public Text killsCounter;
    public AudioSource powerUpSound, chestCollectedSound, playerDamagedSound, playerKillSound;

    bool isPoweredUp;
    float timerDur = 10.0f;
    float powerUpTimer = 0f;

    string defaultTag = "Weak";
    string powerUpTag = "Strong";

    public Vector3 respawnPoint = new Vector3(0, 1, 0); // Reference to the respawn point

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        powerUp = 0;
        chestsCollected = 0;
        livesCount = 3;
        kills = 0;

        livesLeftCounter.text = "";
        powerUpCounter.text = "";
        chestsCollectedCounter.text = "";
        powerUpTimerCounter.text = "";
        killsCounter.text = "";

        SetPowerUpText();
        SetChestsCollectedText();
        SetLivesLeftText();
        SetPowerUpTimerText();
        SetKillsText();

    }

    void Update()
    {
        if (isPoweredUp)
        {
            powerUpTimer -= Time.deltaTime;
            SetPowerUpTimerText();

            if (powerUpTimer <= 0f)
            {
                EndPowerUp();
                Debug.Log("Power-up expired");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            powerUpSound.Play();
            other.gameObject.SetActive(false);
            powerUp += 1;
            SetPowerUpText();
            StartPowerUp();
        }
        else if (other.gameObject.CompareTag("Chest"))
        {
            chestCollectedSound.Play();
            other.gameObject.SetActive(false);
            chestsCollected += 1;
            SetChestsCollectedText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (gameObject.tag == defaultTag)
            {
                playerDamagedSound.Play();
                livesCount -= 1;
                RespawnPlayer(Player);
                SetLivesLeftText();
            }
            else if (gameObject.tag == powerUpTag)
            {
                playerKillSound.Play();
                other.gameObject.SetActive(false);
                kills += 1;
                SetKillsText();
                //Debug.Log("Still missing a text update function for Kills");
            }
        }
    }

    void SetPowerUpText()
    {
        powerUpCounter.text = "Power Up: " + powerUp.ToString();
        Debug.Log("Power Up Text Updated");
        Debug.Log("Player Tag is " + gameObject.tag);
        Debug.Log(powerUpCounter.text);
    }

    void SetLivesLeftText()
    {
        livesLeftCounter.text = "Lives Left: " + livesCount.ToString();
        Debug.Log("Lives Left Text Updated");
        Debug.Log("Player Tag is " + gameObject.tag);
        Debug.Log($"{livesLeftCounter.text}");
    }

    void SetChestsCollectedText()
    {
        chestsCollectedCounter.text = "Chests Collected: " + chestsCollected.ToString();
        Debug.Log("Chests Collected Text Updated");
        Debug.Log("Player Tag is " + gameObject.tag);
        Debug.Log(chestsCollectedCounter.text);
    }

    void SetPowerUpTimerText()
    {
        powerUpTimerCounter.text = "Power Up Timer: " + Mathf.Ceil(powerUpTimer).ToString();
        Debug.Log("Power Up Timer Text Updated");
        Debug.Log("Player Tag is " + gameObject.tag);
        Debug.Log(powerUpTimerCounter.text);
    }

    void SetKillsText()
    {
        killsCounter.text = "Kills: " + kills.ToString();
        Debug.Log("Kills Text Updated");
        Debug.Log("Player Tag is " + gameObject.tag);
        Debug.Log(killsCounter.text);
    }

    //used to chang player tag
    void ChgTag(GameObject obj, string newTag)
    {
        obj.tag = newTag;
        Debug.Log("Player's tag changed to: " + newTag);
    }

    void StartPowerUp()
    {
        isPoweredUp = true;
        ChgTag(Player, powerUpTag);
        powerUpTimer = timerDur;
    }

    void EndPowerUp()
    {
        Debug.Log("Player Tag is " + gameObject.tag);
        isPoweredUp = false;
        ChgTag(Player, defaultTag);
        powerUpTimer = 0f;
        SetPowerUpTimerText(); // Ensure the UI reflects the end of the power-up
    }
    void RespawnPlayer(GameObject obj)
    {
        // Reset player position to the respawn point
        obj.transform.position = respawnPoint;
        //transform.rotation = respawnPoint.rotation;

        Debug.Log("Player Respawned");
    }
}
