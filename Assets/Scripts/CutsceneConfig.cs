using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CutsceneConfig {
/*
    static string actionMove = "Move";
    static string actionSpeak = "Speak";
    static string actorPlayer = "Player";
    static string actorCaptor = "Captor";
    static string captorDestInView = "In View";
    static string captorDestOutOfView = "Out of View";

    static string[] actions = { actionMove, actionSpeak };
    static string[] actors = { actorPlayer, actorCaptor };
    static string[] captorDestination = { captorDestInView, captorDestOutOfView };
*/
    public enum Action { Move, Speak };
    public enum Actor { Player, Captor };
    public enum CaptorDestination { InView, OutOfView, Current };

}
