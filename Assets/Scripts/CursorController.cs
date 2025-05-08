using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorController : MonoBehaviour
{
    private Dictionary<string, Texture2D> cursors = new();
    public CursorState cursorState;

    public static CursorController Instance {get; private set;}
    private bool isInitialCursorSet = false;

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
        this.LoadCursorSprites();
    }

    
    void Update()
    {
        if(!isInitialCursorSet){
            isInitialCursorSet = true;
            SetCursorState(CursorState.POINT);
        }
    }

    
    public void SetCursorState(CursorState updated){
        if(this.cursorState == updated){
            return;
        }
        
        this.cursorState = updated;
        Cursor.SetCursor(this.cursors[cursorState.ToString().ToLower()], Vector2.zero, CursorMode.Auto);
        
    }

    public CursorState GetCursorState(){
        return this.cursorState;
    }


    private void LoadCursorSprites(){
        this.cursors["default"] = Resources.Load<Texture2D>("Cursors/cursor_default");
        this.cursors["point"] = Resources.Load<Texture2D>("Cursors/cursor_point");
        this.cursors["hold"] = Resources.Load<Texture2D>("Cursors/cursor_hold");
        this.cursors["reticle"] = Resources.Load<Texture2D>("Cursors/cursor_reticle");
        this.cursors["marked"] = Resources.Load<Texture2D>("Cursors/cursor_reticle_marked");
    }

    private void OnDestroy()
    {
        cursors.Clear();
    }


}




public enum CursorState {
    DEFAULT,
    POINT,
    HOLD,
    RETICLE,
    MARKED

}
