using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void OnButtonPressed()
    {
        SceneManager.GetSceneByName("Main Menu");
    }
}
