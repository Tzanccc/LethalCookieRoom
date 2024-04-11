﻿using UnityEngine;
using System.Collections;
using UnityEditor.Animations;

// TODO: this is a temporary fix for rotating the dial, remember to delete or replace this after M3
public class ButtonResponseControl : ResponseControl {
    private void Start() {
        // onAnomalyStart(8);
    }
    public override void triggerClickResponse() {
        if (Time.time - lastClickTime < 1) { return; }
        playAudio(triggerAudio, 1f);
        startAnimation();
        lastClickTime = Time.time;
        timesClicked++;
        Debug.Log(timesClicked + "/" + timesToClick);
        if (timesClicked == timesToClick) {
            Debug.Log("anamoly complete");
            playAudio(completeAudio, 0.2f);
            anomalyStateMachine.TriggerEvent(AnomalyStateMachine.AnomalyEvent.ResponseTriggered);
            timesClicked = 0;
        }
    }
}
