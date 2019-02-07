using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Value types
    private int score;

    // Reference types
    private GameState currentState;

    // Events
    public event System.Action<int> OnScoreChanged;
    public event System.Action<GameState> OnCurrentStateChanged;

    /// <summary>
    /// States from current game.
    /// </summary>
    public enum GameState
    {
        idle = 0,
        loading = 1,
        playing = 2,
        paused = 3
    }

    /// <summary>
    /// Check the instance of a game.
    /// </summary>
    private void Awake()
    {
        // When exists the instance of a game, then destroy this, otherwise don't destroy this.
        if (Instance != null)
        {
            // There is already another instance of 'GameManager'.
            Destroy(gameObject);
        }
        else
        {
            // This is the 'GameManager' instance.
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // By pressing 'Space', count the score around 5.
        if (Input.GetButtonDown("Jump"))
            Score += 5;

        // By pressing 'Return', switch the gamestate.
        if (Input.GetButtonDown("Fire1"))
            CurrentState = CurrentState == GameState.playing ? GameState.paused : GameState.playing;
    }

    /// <summary>
    /// Get or Set the score value.
    /// </summary>
    public int Score
    {
        get { return score; }
        private set
        {
            if (value != score)
            {
                score = value;

                if (OnScoreChanged != null)
                    OnScoreChanged(score);
            }
        }
    }

    /// <summary>
    /// Get or Set the currentstate.
    /// </summary>
    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            if (value != currentState)
            {
                currentState = value;

                if (OnCurrentStateChanged != null)
                    OnCurrentStateChanged(currentState);
            }
        }
    }

    /// <summary>
    /// Define the instance of game.
    /// </summary>
    public static GameManager Instance
    {
        get;
        private set;
    }
}