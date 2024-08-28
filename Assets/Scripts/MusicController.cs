using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    [SerializeField] internal AudioClip[] audioClips;
    [SerializeField] internal AudioSource audioSource;
    public void SwitchSong(int switchToTarget) {
        audioSource.resource = audioClips[switchToTarget];
        audioSource.Play();
    }
}
