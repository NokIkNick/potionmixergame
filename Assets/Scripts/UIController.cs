using UnityEngine;

public class UIController : MonoBehaviour
{
    
    [SerializeField] GameObject brewingUI;
    [SerializeField] GameObject huntingUI;
    [SerializeField] GameObject testingUI;


    public static UIController Instance {get; private set;}

    void OnEnable()
    {
        GameStateController.OnGameStateChanged += UpdateUI;
    }

    void OnDisable()
    {
        GameStateController.OnGameStateChanged -= UpdateUI;
    }

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
        
    }

    
    void Update()
    {
        
    }


    public void UpdateUI(GameState gameState){
        switch(gameState){
            case GameState.BREWING:
                this.brewingUI.SetActive(true);
                this.huntingUI.SetActive(false);
                this.testingUI.SetActive(false);
                
                break;
            case GameState.HUNTING:
                this.brewingUI.SetActive(false);
                this.huntingUI.SetActive(true);
                this.testingUI.SetActive(false);
                break;
            case GameState.TESTING:
                this.testingUI.SetActive(true);
                this.huntingUI.SetActive(false);
                this.brewingUI.SetActive(false);
                break;
        }
    }
}
