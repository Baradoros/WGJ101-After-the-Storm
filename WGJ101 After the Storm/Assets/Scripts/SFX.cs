using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFX : MonoBehaviour {
    public AudioClip[] audioClips;
    //public LayerMask collisionLayers;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private AudioClip ChooseAudioClip() {
        return audioClips[Random.Range(0, audioClips.Length)];
    }

    private void OnCollisionEnter(Collision collision) {
        audioSource.clip = ChooseAudioClip();
        audioSource.Play();
    }
}
