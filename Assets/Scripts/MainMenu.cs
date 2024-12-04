using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private PlaySounds sm;
    private GameManager gm;
    public GameObject pauseMenu;
    public bool gamePaused = false;

    private void Start()
    {
        sm = FindObjectOfType<PlaySounds>();
        gm = FindObjectOfType<GameManager>();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(4);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        sm.ChangeMusic(sm.overworld);
        gm.unlockedSpells = 1;
        gm.playerHealth = gm.playerMaxHealth;
        gm.playerMana = gm.playerMaxMana;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPauseValues(gamePaused);
        }
    }

    public void SetPauseValues(bool gameIsPaused)
    {
        pauseMenu.SetActive(!gameIsPaused);
        gamePaused = !gameIsPaused;
        Time.timeScale = !gameIsPaused ? 0f : 1f;
    }
}
