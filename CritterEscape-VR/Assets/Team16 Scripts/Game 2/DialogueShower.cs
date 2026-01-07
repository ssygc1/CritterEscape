using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueShower : MonoBehaviour
{
    public string[] dialogueTexts;
    public TextMeshProUGUI dialogueTMP;
    public Button nextButton;
    public Button previousButton;
    private int indexOfDialogues;
    private int maxIndexNumber;
    // Start is called before the first frame update
    void Start()
    {
        starter();
    }

    private void starter() {
        indexOfDialogues = 0;
        maxIndexNumber = dialogueTexts.Length - 1;
        nextButton?.onClick.AddListener(nextDialogue);
        previousButton?.onClick.AddListener(previousDialogue);
        nextButton.gameObject.SetActive(false);
        previousButton.gameObject.SetActive(false);
    }

    protected void OnEnable() {
        indexOfDialogues = 0;
        dialogueTMP.gameObject.SetActive(true);
    }

    protected void OnDisable() {
        nextButton.gameObject.SetActive(false);
        previousButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        dialogueUpdater();
        decideButtonVisibility();
    }

    public int getIndexOfDialogues() {
        return indexOfDialogues;
    }

    private void decideButtonVisibility() {
        nextButton.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(true);
        if (indexOfDialogues == maxIndexNumber) {
            nextButton.gameObject.SetActive(false);
        }
        else if (indexOfDialogues == 0) {
            previousButton.gameObject.SetActive(false);
        }

        if (maxIndexNumber == 0) {
            nextButton.gameObject.SetActive(false);
            previousButton.gameObject.SetActive(false);
        }
    }

    private void dialogueUpdater() {
        dialogueTMP.text = dialogueTexts[indexOfDialogues];
    }

    public void nextDialogue() {
        if (indexOfDialogues < maxIndexNumber) {
            indexOfDialogues++;
        }
    }

    public void previousDialogue() {
        if (indexOfDialogues > 0) {
            indexOfDialogues--;
        }
    }
}