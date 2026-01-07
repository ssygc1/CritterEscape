using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManagerGame2 : HPManager
{
    public GameObject[] healthPointUi2;
    public GameObject[] healthPointUi3;

    override protected void showObjectsDependingHP() {
        for (int i = 0; i < getHealthPointStatic(); i++) {
            healthPointUi[i].SetActive(true);
            healthPointUi2[i].SetActive(true);
            healthPointUi3[i].SetActive(true);
        }
    }

    override protected void enableOrDisableGO(bool activeness) {
        for (int i = 0; i < healthPointUi.Length; i++) {
            healthPointUi[i].SetActive(activeness);
            healthPointUi2[i].SetActive(activeness);
            healthPointUi3[i].SetActive(activeness);
        }
    }
}
