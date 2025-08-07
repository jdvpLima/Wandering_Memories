using TMPro;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText; // UI Text component
    [SerializeField] private float displayDuration = 2.0f; // Time to display message
    [SerializeField] private string nextSceneName; // Name of the next scene to load
    [SerializeField] private SceneController sceneController; // Reference to the SceneController
    private SpriteRenderer objectRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component
        objectRenderer = GetComponent<SpriteRenderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("Object Renderer not found! Ensure this GameObject has a SpriteRenderer component.");
        }

        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // Ensure the message starts hidden
        }

        if (sceneController == null)
        {
            Debug.LogError("SceneController is not assigned! Please assign it in the Inspector.");
        }
        gameObject.SetActive(false); // Start inactive
    }

    public void ActivateSpecialObject()
    {
        gameObject.SetActive(true);
        Debug.Log("SpecialObject has been activated.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collision detected with: {other.gameObject.name}");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            MakeObjectInvisible();
            ShowMessage();
            Invoke(nameof(DestroyObject), displayDuration); // Delay destruction
        }
    }

    private void MakeObjectInvisible()
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = false; // Make the object invisible
        }
        else
        {
            Debug.LogError("Object Renderer not found!");
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject); // Remove the special object after interaction and message duration
    }

    private void ShowMessage()
    {
        Debug.Log("ShowMessage called.");
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true); // Display the message
            Invoke(nameof(TriggerSceneTransition), displayDuration); // Trigger scene transition after duration
        }
        else
        {
            Debug.LogError("MessageText is not assigned!");
        }
    }

    private void TriggerSceneTransition()
    {
        if (sceneController != null && !string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log($"Triggering scene transition to: {nextSceneName}");
            sceneController.LoadScene(nextSceneName); // Use SceneController to handle scene transition
        }
        else
        {
            Debug.LogError("SceneController or nextSceneName is not properly assigned!");
        }
    }
}
