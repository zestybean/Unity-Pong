using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;
   private void Start() {
       GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
   }

   float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight){
       /*
       ||1  <- top
       ||0  <- mid
       ||-1 <- bottom
       */

       return (ballPos.y - racketPos.y) / racketHeight;
   }

    private void OnCollisionEnter2D(Collision2D col) {
       //Left racket hit
       if(col.gameObject.name == "LeftRacket"){
           speed += 1;

           //Calc hit factor
           float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

           //Calc the dir make length=1 via .normalized
           Vector2 dir = new Vector2(1, y).normalized;

           //Set Vel with new dir * speed
           GetComponent<Rigidbody2D>().velocity = dir * speed;
           
       }

       //Right racket hit
       if(col.gameObject.name == "RightRacket"){
           speed += 1;

           //Calc hit factor
           float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

           //Calc the dir make length=1 via .normalized
           Vector2 dir = new Vector2(-1, y).normalized;

           //Set Vel with new dir * speed
           GetComponent<Rigidbody2D>().velocity= dir * speed;
       }
   }


}
