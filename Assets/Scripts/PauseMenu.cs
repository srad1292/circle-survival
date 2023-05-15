using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }


    [SerializeField] Button resumeButton;
    [SerializeField] Button statisticsButton;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] InGameUI inGameUi;



    public bool isPaused { get; private set; }

    public void ResumeGame() {
        isPaused = false;
        inGameUi.gameObject.SetActive(true);
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        isPaused = true;
        inGameUi.gameObject.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void TogglePauseState() {
        if(isPaused) {
            ResumeGame();
        } else {
            PauseGame();
        }
    }

    public void ViewStatistics() {
        print("View Statistics pressed");
        print("Total Enemies Killed: " + StatisticsManager.Instance.enemiesKilled);
        print("Total Kill Score: " + StatisticsManager.Instance.totalKillScore);

        print("Enemies Killed By Type");
        if(StatisticsManager.Instance.enemyKilledByType.Count == 0) {
            print("No enemies killed yet.");
        } else {
            foreach(string key in StatisticsManager.Instance.enemyKilledByType.Keys) {
                print(key + ": " + StatisticsManager.Instance.enemyKilledByType[key]);
            }
        }

        print("Bullets Fired: " + StatisticsManager.Instance.bulletsFired);
        print("Bullets Hit: " + StatisticsManager.Instance.bulletsHit);
        print("Accuracy: " + StatisticsManager.Instance.GetAccuracy().ToString("F") + "%");
    }

    public void QuitGame() {
        Application.Quit();
    }





}
