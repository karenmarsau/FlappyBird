using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour{

public GameObject [] playerObjects;
public int selectedCharacter = 0;
public string gameScene = "Color";
public string selectedCharacterDataName = "SelectedCharacter";


    void Start(){
        hideAllCharacters();

        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName, 0);
        playerObjects[selectedCharacter].SetActive(true);
    }


    private void hideAllCharacters(){
        foreach (GameObject g in playerObjects){
            g.SetActive(false);
        }
    }

    private void nextCharacter(){
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter++;

        if(selectedCharacter >= playerObjects.Length){
            selectedCharacter = 0;
        }

        playerObjects[selectedCharacter].SetActive(true);
    }

    public void previousCharacter(){
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter--;

        if(selectedCharacter < 0){
            selectedCharacter = playerObjects.Length-1;
        }

        playerObjects[selectedCharacter].SetActive(true);
    }

    public void startGame(){
        PlayerPrefs.SetInt(selectedCharacterDataName, selectedCharacter);
        SceneManager.LoadScene(gameScene);
    }
}
