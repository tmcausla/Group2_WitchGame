using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private PlaySounds sm;
    private GameManager gm;

    void Start()
    {
        sm = FindObjectOfType<PlaySounds>();
        gm = FindObjectOfType<GameManager>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.newScene = true;
            sm.PlaySoundEffect("victory");
            SceneManager.LoadScene(5);
        }
    }
}
