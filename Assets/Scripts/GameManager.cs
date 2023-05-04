using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] NightMenu nightMenu; 
    [SerializeField] LevelPlayer levelPlayer;

    private int day = 0;
    private LevelManager levelManager;

    void Start()
    {
        print("I am in GameManager.Start");
        levelManager = GetComponent<LevelManager>();

        levelPlayer.OnLevelComplete += HandleLevelComplete;
        StartDayLevel(day);
    }

    private void StartDayLevel(int day) {
        print("I am in GameManager.StartDayLevel");
        levelPlayer.PlayLevel(day, levelManager.GetLevelByDay(day));
    }

    
    private void HandleLevelComplete(int day) {
        print("Day " + day + " complete!");
        if(levelManager.GetLevelByDay(day+1).Count == 0) {
            print("Game Complete!");
            // Game complete
        } else {
            // if cutscene, show
            // else nighttime menu

            StartCoroutine(ShowMenuCO());
        }

    }

    IEnumerator ShowMenuCO() {
        yield return new WaitForSeconds(0.8f);
        nightMenu.gameObject.SetActive(true);
    }


    public void GoToNextDay() {
        nightMenu.gameObject.SetActive(false);
        day += 1;
        StartDayLevel(day);
    }
}
