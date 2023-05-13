using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] NightMenu nightMenu; 
    [SerializeField] LevelPlayer levelPlayer;
    [SerializeField] CutscenePlayer cutscenePlayer;

    private int day = 0;
    private int killScore = 0;
    private LevelManager levelManager;

    void Start()
    {
        print("I am in GameManager.Start");
        levelManager = GetComponent<LevelManager>();
        levelPlayer.OnLevelComplete += HandleLevelComplete;

        cutscenePlayer.onCutsceneFinished += HandleCutsceneComplete;

        StartDayLevel(day);
        //PerformCutscene(day);
    }

    private void PerformCutscene(int day) {
        cutscenePlayer.PlayCutsceneForDay(day);
    }

    private void HandleCutsceneComplete(int day) {
        if(day == 0) {
            StartDayLevel(day);
        } else {
            StartCoroutine(ShowMenuCO());
        }
    }

    private void StartDayLevel(int day) {
        print("I am in GameManager.StartDayLevel");
        levelPlayer.PlayLevel(day, levelManager.GetLevelByDay(day));
    }

    
    private void HandleLevelComplete(int day) {
        print("Day " + day + " complete!");
        if(levelManager.GetLevelByDay(day+1).Count == 0) {
            print("Game Complete!");
        } else {
            if(day > 0) {
                PerformCutscene(day);
            } else {
                StartCoroutine(ShowMenuCO());
            }
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

    public void EnemyKilled(int killScore) {
        this.killScore += killScore;
        print("Current kill score: " + this.killScore);
    }

    public void HandleItemBought(GunSO gun) {
        killScore -= gun.cost;
    }
}
