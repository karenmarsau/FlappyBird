using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollected : MonoBehaviour{
    public AudioSource lifeSource;

    private void OnTriggerEnter2D(Collider2D collision){

        lifeSource = GetComponent<AudioSource>();
        
        if (collision.CompareTag("Player")){
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            lifeSource.Play();
            Destroy(gameObject, 0.5f);
        }
    }
}
