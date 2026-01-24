using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueShower : MonoBehaviour
{
    public string[] dialogueTexts;
    public TextMeshProUGUI dialogueTMP;

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
    }

    // Update is called once per frame
    public void Update()
    {
        dialogueUpdater();
    }

    public int getIndexOfDialogues() {
        return indexOfDialogues;
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