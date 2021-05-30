using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour{

    public string levelName;

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            levelName=gameObject.name;
            Destroy(collision.gameObject, 0.1f);
            
        }
    }

    public void update(){
        //SceneManager.LoadScene(levelName);
    }

}
