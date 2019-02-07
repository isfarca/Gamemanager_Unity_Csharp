using UnityEngine;
using UnityEngine.UI;

public class GameStateLabel : MonoBehaviour
{
    // Reference types
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
        GameManager.Instance.OnCurrentStateChanged += UpdateGameStateLabel;
    }

    /// <summary>
    /// Deactivate the event.
    /// </summary>
    private void OnDisable()
    {
        // Function isn't running.
        GameManager.Instance.OnCurrentStateChanged -= UpdateGameStateLabel;
    }

    /// <summary>
    /// Update the gamestate value and output this in the textbox.
    /// </summary>
    /// <param name="newGamestate">Pass the new gamestate value.</param>
    private void UpdateGameStateLabel(GameManager.GameState newGamestate)
    {
        // Write the score in the textbox.
        textComponent.text = "Gamestate: " + newGamestate;
    }
}