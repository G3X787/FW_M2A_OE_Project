using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretBoxScript : MonoBehaviour
{
    // Define the name of the scene you want to switch to
    public string targetSceneName = "YourTargetSceneName";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the secret box
        if (other.CompareTag("Player"))
        {
            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
