using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpenLevel : MonoBehaviour{

    public string levelName;
   
    void start(){
        if(Input.GetKey("space")){
            levelName=gameObject.name;  
            //SceneManager.LoadScene(levelName);
        }
    }
}
