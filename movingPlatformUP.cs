using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformUP : MonoBehaviour
{
    public float speed;         //sets speed of the platform
    public int startingPoint;   //sets the starting point of the platform
    public Transform[] points;   //sets a list of the point

    private int i;  //index of the array

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;    // setting the position of the platform to the position of one of the points using index "startingPoint"
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)    //checking the distance of the platform and the object
        {
            i++;            //increase index
            if (i == points.Length)     //check if the position was on the last point after the index increase
            {
                i = 0;      //reset index
            }
        }
        
        //here the platform will be moved towards the point position with the index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}


//button = inverted gun, collider on impact