using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private GameState currentGameState;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private HuntingController huntingController;
    public static GameStateController Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


    }
    void Start()
    {
        SetGameState(GameState.BREWING);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(GameState gameState){
        if(currentGameState == gameState) return;


        switch(gameState){
            case GameState.BREWING:
                playerController.enabled = true;
                huntingController.enabled = false;
                break;
            case GameState.HUNTING:
                playerController.enabled = false;
                huntingController.enabled = true;
                break;
        }

        UIController.Instance.UpdateUI(currentGameState);
    }


    public GameState GetGameState(){
        return currentGameState;
    }


    public void SetGameStateToHunting(){
        SetGameState(GameState.HUNTING);
    }
}

    

public enum GameState {
    BREWING,
    HUNTING,
    PAUSED,
    MENU
}

