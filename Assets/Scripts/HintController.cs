using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintController : MonoBehaviour {
    [SerializeField] GameObject[] gameObjectsToHide;
    [SerializeField] GameObject hintScreen;
    [SerializeField] TextMeshProUGUI text;
    public void OpenHintScreen(int hintNumber) {
        CloseHintScreen();
        for (int i = 0; i < gameObjectsToHide.Length; i++) {
            gameObjectsToHide[i].SetActive(false);
        }
        hintScreen.SetActive(true);
        switch (hintNumber) {
            case 0:
                text.text = "Kevin Macleod, born in 1972 Green Bay, Wisconsin, U.S., is a legendary composer and a music producer. Many have never heard of him, but have listened to his music.";
                break;
            case 1:
                text.text = "ASCII is a 7-bit character set containing 128 characters. Many modern character sets in computers, in HTML and on the internet are based on ASCII.";
                break;
            default:
                text.text = "You have reached the default value somehow.";
                break;
        }
    }
    public void CloseHintScreen() {
        for (int i = 0; i < gameObjectsToHide.Length; ++i) {
            gameObjectsToHide[i].SetActive(true);
        }
        hintScreen.SetActive(false);
    }
}
