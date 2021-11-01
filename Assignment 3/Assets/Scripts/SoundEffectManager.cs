using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEffectManager : MonoBehaviour
{

    //Create a variable to store audio clip
   private AudioSource _audioSource;

    private void Awake()
    {
        //_audioSource gets the 'AudioSource'  component attached to the 'Music' gameobject.
        _audioSource = GetComponent<AudioSource>();

        //This section of code was referenced: https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
        //Create an array of the GameObject that looks for gameobjects with the tag "Music"
        GameObject[] soundEffect = GameObject.FindGameObjectsWithTag("SoundEffects");

        //This if statement will destroy the music game object if it has already been created
        //When switching from the lose screen back to the game screen, the 'soundEffect' variable will be greater then 1.Therefore, we destroy the object so the '_audioSource' will be re-invoked without a null value
        if (soundEffect.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //If the amount of game objects is less then or equal to one, the object with the music tag is not destroyed
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

      //Audio is played on the first shot. 'has_Shot' is invoked and the PlayAudio clip is called on Awake.
        Player.has_Shot += PlayAudio;

    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        { 

            //Audio is played when the player press' the spacebar. The has_Shot action is called from the player class
            //and then calls the PlayAudio function. This will play the audio clip
             Player.has_Shot += PlayAudio;
            Debug.Log("kerplam");

        }
    }


    //Playaduio function which is called when the 'shoot' action is true
    private void PlayAudio()
        {
            //The audiosource variable calls the play function. This function will play the audio attached to the audio source component
            _audioSource.Play();

    }
}
