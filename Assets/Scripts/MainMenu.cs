using System.Collections;
using System.Collections.Generic;
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
            if (gamePaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0f;
    }
}
