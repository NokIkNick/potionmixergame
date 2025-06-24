using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(int id){
        StartCoroutine(LoadSceneMode(id));
    }

    IEnumerator LoadSceneMode(int id){

        AsyncOperation scene = SceneManager.LoadSceneAsync(id);
        

        while(!scene.isDone){
            yield return null;
        }

        if(scene.isDone){
            switch(id){
            case 0:
                GameStateController.Instance.SetGameState(GameState.BREWING);
                break;
            case 1:
                GameStateController.Instance.SetGameState(GameState.HUNTING);
                break;
            case 2:
                GameStateController.Instance.SetGameState(GameState.TESTING);
                break;
        }
        }
    }
}
