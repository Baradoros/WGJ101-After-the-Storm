using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFX : MonoBehaviour {
    public AudioClip[] audioClips;
    //public LayerMask collisionLayers;

    private AudioSource audioSource;
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private AudioClip ChooseRandomAudioClip() {
        return audioClips[Random.Range(0, audioClips.Length)];
    }

    private void OnCollisionEnter(Collision collision) {
        // No SFX if barely moving
        //if (rb?.velocity.magnitude <= 0.5f) {
        //    return;
        //}

        audioSource.clip = ChooseRandomAudioClip();

        audioSource.Play();
    }
}
