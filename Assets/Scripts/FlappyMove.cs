using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyMove : MonoBehaviour{ 
    public float runSpeed = 2;   
    public float jumpSpeed = 3; 
    public Image Heart;
    public int quantityOfHearts;
    public RectTransform posFirt;
    public Canvas MyCanvas;
    public int OffSet;
    public AudioSource flapSource;

    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animation;
    Vector3 snapPosition;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();  
        animation = GetComponent<Animator>();
        snapPosition = this.transform.position;

        Transform posHeart = posFirt;

        flapSource = GetComponent<AudioSource>();

        for (int i = 0; i < quantityOfHearts; i++){
            Image NewHeart = Instantiate(Heart, posHeart.position, Quaternion.identity);
            NewHeart.transform.parent = MyCanvas.transform;
            posHeart.position = new Vector2(posHeart.position.x + OffSet, posHeart.position.y);
        }


    }

    void Update(){
        Vector2 pos = transform.position;
        if(Input.GetKey("d")  || Input.GetKey("right")){
            pos.x += runSpeed * Time.deltaTime;
            spriteRenderer.flipX = false;
            animation.SetBool("Fly", true);

        }else if(Input.GetKey("a") || Input.GetKey("left")){
            pos.x -= runSpeed * Time.deltaTime;
            spriteRenderer.flipX = true;
            animation.SetBool("Fly", true);
        }

         if((Input.GetKey("w") || Input.GetKey("space")) && !CheckGround.isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animation.SetBool("Fly", true);
            flapSource.Play();
        }else{
            animation.SetBool("Fly", false);
        }
        transform.position = pos; 

    }

    IEnumerator waiter(){
        yield return new WaitForSeconds(4);
    }  

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Die")){
            StartCoroutine(waiter());
            this.transform.position = snapPosition;
        }
    }
}
