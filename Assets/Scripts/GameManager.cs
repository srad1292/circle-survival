using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] NightMenu nightMenu; 
    [SerializeField] LevelPlayer levelPlayer;
    [SerializeField] CutscenePlayer cutscenePlayer;

    private int day = 0;
    public static int killScore { get; private set; }
    private LevelManager levelManager;

    void Start()
    {
        killScore = 50;
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
        levelPlayer.PlayLevel(day, levelManager.GetLevelByDay(day));
    }

    
    private void HandleLevelComplete(int day) {
        if(levelManager.GetLevelByDay(day+1).Count == 0) {
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

    public void EnemyKilled(int worth) {
        killScore += worth;
    }

    public void HandleItemBought(GunSO gun) {
        killScore -= gun.cost;
    }
}
