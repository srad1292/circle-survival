using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour
{

    public System.Action<int> onCutsceneFinished;
    
    [SerializeField] GameObject captor;
    [SerializeField] GameObject player;
    [SerializeField] Transform captorInView;
    [SerializeField] Transform captorOutOfView;
    [SerializeField] CutsceneSO[] cutscenes;


    private Rigidbody2D captorRigidBody;

    private void Start() {
        captorRigidBody = captor.GetComponent<Rigidbody2D>();
       
        //StartCoroutine(ShowSpeechBubble());    
    }

    IEnumerator ShowSpeechBubble() {
        SpeechBubble bubble = SpeechBubble.Create(captor.transform, new Vector3(1.5f, 1.5f, 0f), "Ah.  You're awake.");
        yield return new WaitForSeconds(1.5f);
        bubble.Setup("I have been waiting.");
        yield return new WaitForSeconds(1.5f);
        Destroy(bubble.gameObject);
    }

    public void PlayCutsceneForDay(int day) {
        CutsceneSO cutsceneToPlay = null;
        foreach (CutsceneSO cutscene in cutscenes) {
            if(cutscene.dayToPlay == day) {
                cutsceneToPlay = cutscene;
                break;
            }
        }

        if(cutsceneToPlay == null) {
            if(onCutsceneFinished != null) {
                onCutsceneFinished.Invoke(day);
            }
        } else {
            StartCoroutine(PlayCutscene(day, cutsceneToPlay));
        }
       
    }

    IEnumerator PlayCutscene(int day, CutsceneSO cutscene) {
        foreach(CutsceneSegment segment in cutscene.segments) {
            if(segment.action == CutsceneConfig.Action.Move) {
                yield return PerformMove(segment);
            } else if(segment.action == CutsceneConfig.Action.Speak) {
                yield return PerformDialog(segment);
            }
        }
        if(onCutsceneFinished != null) {
            onCutsceneFinished.Invoke(day);
        }
    }

    IEnumerator PerformMove(CutsceneSegment segment) {
        if(segment.actor == CutsceneConfig.Actor.Captor) {
            Vector3 destination = captor.transform.position;
            if(segment.captorDestination == CutsceneConfig.CaptorDestination.InView) {
                destination = captorInView.position;
            } else if (segment.captorDestination == CutsceneConfig.CaptorDestination.OutOfView) {
                destination = captorOutOfView.position;
            }
            bool arrived = false;
            while(!arrived) {
                captorRigidBody.transform.position = Vector2.MoveTowards(captor.transform.position, destination, segment.moveSpeed * Time.deltaTime);
                if (Vector2.Distance(captor.transform.position, destination) <= 0.1f) {
                    arrived = true;
                }
                yield return null;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator PerformDialog(CutsceneSegment segment) {
        print("I am in perform dialog!");
        if(segment.dialog.Length == 0) {
            yield return null;
        }
        Transform parent = segment.actor == CutsceneConfig.Actor.Player ? player.transform : captor.transform;
        SpeechBubble bubble = SpeechBubble.Create(parent, new Vector3(1.5f, 1.5f, 0f), "");
        print("Calling TraverseDialog");
        yield return StartCoroutine(TraverseDialog(bubble, segment.dialog));
        print("TraverseDialog Ended");
        Destroy(bubble.gameObject);
    }

    IEnumerator TraverseDialog(SpeechBubble bubble, string[] dialog) {
        foreach(string line in dialog) {
            bubble.Setup(line);
            yield return new WaitForSeconds(4f);
            print("Went through line");
        }
    }


}
