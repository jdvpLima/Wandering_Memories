using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement; // Required for scene management

public class TextFader : MonoBehaviour
{
    public TextMeshProUGUI text; // Drag your TextMeshPro UI object here
    public float fadeDuration = 1f; // Duration for fading in/out
    public float displayDuration = 2f; // Duration to display the text before fading out
    public string[] messages; // Array of messages to display
    public string nextSceneName; // Name of the next scene to load

    private int currentMessageIndex = 0;

    void Start()
    {
        if (messages.Length > 0)
        {
            StartCoroutine(FadeTextSequence());
        }
    }

    IEnumerator FadeTextSequence()
    {
        while (currentMessageIndex < messages.Length)
        {
            // Set the text
            text.text = messages[currentMessageIndex];

            // Fade in
            yield return StartCoroutine(FadeTextAlpha(0, 1, fadeDuration));

            // Display for a duration
            yield return new WaitForSeconds(displayDuration);

            // Fade out
            yield return StartCoroutine(FadeTextAlpha(1, 0, fadeDuration));

            // Move to the next message
            currentMessageIndex++;
        }

        // Load the next scene after all messages are shown
        LoadNextScene();
    }

    IEnumerator FadeTextAlpha(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        Color color = text.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            text.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure the final alpha is set
        text.color = new Color(color.r, color.g, color.b, endAlpha);
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set!");
        }
    }
}
