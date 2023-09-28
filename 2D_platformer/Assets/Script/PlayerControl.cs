using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed =300f;
   public float jumpForce=200f;
    float horizontalInput;
    public Rigidbody2D rb;
    public bool isOnGround = true;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // for translation along x axis.
        horizontalInput= Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*speed*Time.deltaTime*horizontalInput);

        // for rotating character
        if(horizontalInput<0){
            spriteRenderer.flipX=true;
        }
        if(horizontalInput>0) {spriteRenderer.flipX=false;
        }


        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
            rb.AddForce(Vector3.up*jumpForce,ForceMode2D.Impulse);
        isOnGround= false;
        }

        // else if (collision.gameObject.CompareTag("Obstacle")){
        //     Debug.Log("GameOver");
        //     isGameOver=true;
        // }
        
    }
    public void OnCollisionEnter2D ( Collision2D collision ){
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround=true;    
          
        }
        }
       

}