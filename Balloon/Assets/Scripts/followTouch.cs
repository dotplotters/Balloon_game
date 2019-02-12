using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTouch : MonoBehaviour
{
    float deltax, deltay;
    Rigidbody2D rb;

    bool moveAllowed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //touch event
        foreach (Touch touch in Input.touches)
        {
            
            //knowing the touch position
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            //touch phase

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    //if you touch the car
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        //get the offset between position you touch
                        deltax = touchPos.x - transform.position.x;
                        deltay = touchPos.y - transform.position.y;

                        //if touch began within  the car collider
                        //then it is allowed to move

                        moveAllowed = true;

                        //restriction some rigidbody properties
                        rb.freezeRotation = true;
                        rb.velocity = new Vector2(0, 0);
                        GetComponent<BoxCollider2D>().sharedMaterial = null;
                    }
                    break;

                //you move your finger
                case TouchPhase.Moved:
                    //if you touches the car and move is allowed
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                        rb.MovePosition(new Vector2(0, touchPos.y - deltay));

                    break;

                //you released your finger
                case TouchPhase.Ended:
                    //restore intial parameters
                    //when touch is ended
                    moveAllowed = false;
                    rb.freezeRotation = true;
                    rb.gravityScale = 0;
                    PhysicsMaterial2D mat = new PhysicsMaterial2D();
                    GetComponent<BoxCollider2D>().sharedMaterial = mat;
                    break;
            }
        }
    }
}
