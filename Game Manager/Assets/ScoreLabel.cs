using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{
    // Declare variables
    private Text textComponent;

    /// <summary>
    /// Get the textbox.
    /// </summary>
    private void Awake()
    {
        // Get the 'Text'-Component.
        textComponent = GetComponent<Text>();
    }

    /// <summary>
    /// Activate the event.
    /// </summary>
    private void OnEnable()
    {
        // Functions is running.
        GameManager.Instance.OnScoreChanged += UpdateScoreLabel;
    }

    /// <summary>
    /// Deactivate the event.
    /// </summary>
    private void OnDisable()
    {
        // Function isn't running.
        GameManager.Instance.OnScoreChanged -= UpdateScoreLabel;
    }

    /// <summary>
    /// Update the score value and output this in the textbox.
    /// </summary>
    /// <param name="newScore">Pass the new score value.</param>
    private void UpdateScoreLabel(int newScore)
    {
        // Write the score in the textbox.
        textComponent.text = "Score: " + newScore;
    }
}