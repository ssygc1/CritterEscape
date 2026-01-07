using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class ObjectSlideShowSeconds : MonoBehaviour
{
    public GameObject[] slideshowObjects;
    public long showingSeconds = 5;
    public long hidingSeconds = 5;

    private long lastTickShownOrHidden;
    private long showingSecondsMillisecond;
    private long hidingSecondsMillisecond;
    private int isaver = -1;
    private bool isObjectShown;

    public UnityEvent onSlidesFinished;

    
    // Start is called before the first frame update
    void Start()
    {
        showingSecondsMillisecond = showingSeconds * 1000;
        hidingSecondsMillisecond = hidingSeconds * 1000;
        hideAllObjects();
        lastTickShownOrHidden = currentTimeCalculator();
    }

    // Update is called once per frame
    void Update()
    {
        decideObjectVisibility();
    }

    private void hideAllObjects() {
        foreach (GameObject hiding in slideshowObjects) {
            hiding.SetActive(false);
        }
        isObjectShown = false;
    }
    
    private void decideObjectVisibility() {
        if (isObjectShown && !hasTimePast(showingSecondsMillisecond)) {
            return;
        }
        if (!isObjectShown && !hasTimePast(hidingSecondsMillisecond)) {
            return;
        }
        
        if (!isObjectShown) {
            //if it is hidden, show
            showSelectedObject();
            
        }
        else if (isObjectShown) {
            //if it is shown, hide
            hideSelectedObject();
        }
    }

    private void hideSelectedObject() {
        slideshowObjects[isaver].SetActive(false);
        this.lastTickShownOrHidden = currentTimeCalculator();
        isObjectShown = false;
    }

    private void showSelectedObject() {
        isaver++;
        iReset();
        this.lastTickShownOrHidden = currentTimeCalculator();
        slideshowObjects[isaver].SetActive(true);
        isObjectShown = true;
    }

    private void iReset() {
        //if it is showing the last picture,
        if (this.isaver >= slideshowObjects.Length) {
            this.isaver = 0; //can delete this line
            //Add Scene transition
            if (PhotonNetwork.IsMasterClient)
            {
                onSlidesFinished?.Invoke();
            }
            
        }
    }

    private long currentTimeCalculator() {
        return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }

    private bool hasTimePast() {
        long currentTick = currentTimeCalculator();
        return ((currentTick - lastTickShownOrHidden) > showingSecondsMillisecond);
    }

    private bool hasTimePast(long thisTime) {
        long currentTick = currentTimeCalculator();
        return ((currentTick - lastTickShownOrHidden) > thisTime);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
