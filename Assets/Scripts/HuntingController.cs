using UnityEngine;
using UnityEngine.InputSystem;

public class HuntingController : MonoBehaviour
{
    private Vector3 mousePosition;
    private CursorController cursorController;
    private InputAction interactAction;
    private HuntingController Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


    }

    void OnEnable()
    {
        if(cursorController){
            cursorController.SetCursorState(CursorState.RETICLE);
        }
    }

    void Start()
    {
        cursorController = CursorController.Instance;
        interactAction = InputSystem.actions.FindAction("Click");
        Shoot();
    }

    
    void Update()
    {
        CalculateMousePosition();
        if(CheckForShootable()){
            Shoot();
        }
    }

    private void Shoot(){
        if(interactAction.IsPressed()){
            Debug.Log("test");
            int shootableLayer = LayerMask.GetMask("Shootable");
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, shootableLayer);
            if(hit.collider != null && hit.rigidbody != null){
                hit.collider.gameObject.GetComponent<HealthScript>().TakeDamage();
                Debug.Log(hit.collider.gameObject.name+ ", hit!");
            }
        }
    }

    private bool CheckForShootable(){
    
        int itemLayer = LayerMask.GetMask("Shootable");
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, itemLayer);
        
        if(hit){
            cursorController.SetCursorState(CursorState.MARKED);
            return true;
        }else {
            cursorController.SetCursorState(CursorState.RETICLE);
            return false;
        }
    }


    private void CalculateMousePosition(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
    }
}
