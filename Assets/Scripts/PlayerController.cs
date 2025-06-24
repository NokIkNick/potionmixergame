using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    
    private CursorController cursorController;
    private InputAction interactAction;
    private bool isHolding = false;
    private Vector3 mousePosition;
    private Rigidbody2D heldObject;
    
    [SerializeField] private float moveForce = 50f;
    [SerializeField] private float maxVelocity = 30f;


    public static PlayerController Instance {get; private set;}
    
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
        this.cursorController = CursorController.Instance;
        this.interactAction = InputSystem.actions.FindAction("Click");
    }


    private void FixedUpdate()
    {   

        
            //Make heldobject follow the cursor
            if(IsHoldingObject()){
                Vector2 direction = (Vector2)mousePosition - heldObject.position;
                Vector2 force = direction * moveForce;

                heldObject.linearVelocity = Vector2.ClampMagnitude(force, maxVelocity);
            }
        

        

    }

    void Update()
    {
        CalculateMousePosition();
        
        if(!isHolding){
            CheckForPickableItem();
        } 
        
        Interact();
        
    }

    //Method for handling mouse inputs and updating the cursor accordingly 
    private void Interact(){
        if(interactAction.IsPressed()){

            //If we arent holding anything, start holding. This is the initial click.
            if(!isHolding){
                isHolding = true;

                //We can try and pickup
                TryPickup();

            }

            //This happens when we're already holding down the mouse.
            if(IsHoldingObject()){
                cursorController.SetCursorState(CursorState.HOLD);
            }
            

        }else {

            //If we aren't currently pressing / holding mouse 1, we should stop holding an item, and drop it.
            if(isHolding){
                    isHolding = false;

                    //Try and drop, if item is being held
                    Drop();
                }
        }
    }


    private void TryPickup(){
        int itemLayer = LayerMask.GetMask("Pickupable");
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, itemLayer);

        if(hit.collider != null && hit.rigidbody != null){
            heldObject = hit.rigidbody;
            heldObject.MoveRotation(0f);
            heldObject.freezeRotation = true;
            heldObject.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }

    private void Drop(){
        if(heldObject != null){
            heldObject.freezeRotation = false;
            heldObject.linearVelocity *= 0.5f;
            heldObject = null;
        }
    }

    private void CheckForPickableItem(){
    
        int itemLayer = LayerMask.GetMask("Pickupable");
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, itemLayer);
        
        if(hit){
            cursorController.SetCursorState(CursorState.POINT);
        }else {
            cursorController.SetCursorState(CursorState.DEFAULT);
        }
    }
    
    private bool IsHoldingObject(){
        return isHolding && heldObject != null;
    }

    private void CalculateMousePosition(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
    }

}






