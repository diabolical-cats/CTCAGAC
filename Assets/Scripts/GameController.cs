using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {
    private string correctCode;
    private bool playerCanType = true;
    private int oldSong;
    [SerializeField] private TextMeshProUGUI codeInputText;
    [SerializeField] private TextMeshProUGUI placeholderText;
    [SerializeField] private MusicController musicController;
    [SerializeField] private GameObject[] gameObjectsToDissapearUponGameOver;
    private void Start() {
        oldSong = UnityEngine.Random.Range(0, musicController.audioClips.Length);
        musicController.SwitchSong(oldSong);
        SetCode();
    }
    private void Update() {
        if (codeInputText.text.Length >= correctCode.Length) {
            if (codeInputText.text == correctCode && playerCanType) {
                CorrectCode();
                EndGame();
            }
            else if (codeInputText.text != correctCode && playerCanType) {
                IncorrectCode();
                musicController.SwitchSong(RandomSong());
                SetCode();
                Invoke("ResetInput", 1.5f);
            }
        }
    }
    /// <summary>
    /// Write into input.
    /// </summary>
    public void AddToInput(int number) {
        if (playerCanType) {
            codeInputText.text += number.ToString();
        }
    }
    /// <summary>
    /// Overrides the current correct code.
    /// </summary>
    private void SetCode() {
        float songLengthInSeconds = musicController.audioSource.clip.length;
        int songLengthSubstractedMinutes = SubstractMinutes(songLengthInSeconds);
        correctCode = ReturnMinutes(songLengthInSeconds).ToString() + "58" + SongLengthInSecondsCorrection(songLengthSubstractedMinutes);
        SetPlaceholderTextForInput();
    }
    /// <summary>
    /// Overrides the placeholder text to fit correct code's length.
    /// </summary>
    private void SetPlaceholderTextForInput() {
        placeholderText.text = string.Empty;
        for (int i = 0; i < correctCode.Length; i++) {
            placeholderText.text += "0";
        }
    }
    private int ReturnMinutes(float seconds) {
        int result = (int)seconds;
        do {
            result /= 60;
        } while (result >= 60);
        return result;
    }
    private int SubstractMinutes(float seconds) {
        int result = (int)seconds;
        do {
            result -= 60;
        } while (result >= 60);
        return result;
    }
    /// <summary>
    /// Checks if the song's length seconds are under 10 seconds, so it could put a zero before the number.
    /// </summary>
    private string SongLengthInSecondsCorrection(int seconds) {
        if (seconds < 10) {
            return "0" + seconds.ToString();
        } else { 
            return seconds.ToString(); 
        }
    }
    /// <summary> 
    /// Returns a random int for song, also makes sure that the same song cant be picked twice in a row.
    /// </summary>
    private int RandomSong() {
        int random = oldSong;
        while (oldSong == random) {
        random = UnityEngine.Random.Range(0, musicController.audioClips.Length);
        }
        oldSong = random;
        return oldSong;
    }
    private void EndGame() {
        for (int i = 0; i < gameObjectsToDissapearUponGameOver.Length; i++) {
            gameObjectsToDissapearUponGameOver[i].SetActive(false); 
        }
    }
    private void IncorrectCode() {
        playerCanType = false;
        codeInputText.text = "Incorrect!";
    }
    private void CorrectCode() {
        playerCanType = false;
        codeInputText.text = "Correct!";
    }
    private void ResetInput() {
        codeInputText.text = string.Empty;
        playerCanType = true;
    }
}
