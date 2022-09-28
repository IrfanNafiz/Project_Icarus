using UnityEngine;

public class SceneBegin : MonoBehaviour
{
    public GameManager gameManager;

    public void SceneBeginTransitionEnd()
    {
        gameManager.StartSceneTransitionClose();
    }
}
