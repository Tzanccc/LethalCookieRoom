using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogbookResponseControl : ResponseControl {
    public override void triggerClickResponse() {
        if (Time.time - lastClickTime < 1) { return; } else if (Time.time - lastClickTime < 1) { timesClicked = 0; }
        playAudio(triggerAudio, 1f);
        // startAnimation();

        if (anomalyStateMachine != null && anomalyStateMachine.getState() == AnomalyStateMachine.AnomalyState.Active) {
            lastClickTime = Time.time;
            timesClicked++;
            if (timesClicked == timesToClick) {
                Debug.Log("anamoly complete");
                playAudio(completeAudio, 0.05f);
                anomalyStateMachine.TriggerEvent(AnomalyStateMachine.AnomalyEvent.ResponseTriggered);
                timesClicked = 0;
            }
        }
    }
}