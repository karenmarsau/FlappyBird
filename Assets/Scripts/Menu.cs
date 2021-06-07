using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour{

    public AudioSource music;
    public AudioSource musicButton;

    public void nextLevel(){
        musicButton = GetComponent<AudioSource>();
        musicButton.Play();
        SceneManager.LoadScene(1);
    }

    public void onOffMusic(){
        music = GetComponent<AudioSource>();
        music.mute = !music.mute;
    }

    public void onOffEffects(){
       
    }
}
