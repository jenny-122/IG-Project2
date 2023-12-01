# Tage References

## Checking Tag 

```cs
void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("energyBar"))
    {
        // Your existing code for power-up handling

        // Check the tag of the player GameObject
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the energyBar!");
            // Additional actions specific to the player, if needed
        }
    }
}
```

## Changeing Tag

```cs
void ChangePlayerTag(GameObject playerObject, string newTag)
{
    playerObject.tag = newTag;
    Debug.Log("Player's tag changed to: " + newTag);
}

// Example usage:
// ChangePlayerTag(playerGameObject, "NewTag");

```