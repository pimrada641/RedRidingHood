using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PetAI : MonoBehaviour
{
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    public Transform target;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPoint = false;
    Seeker seeker;
    Rigidbody2D rb;
    //Collider2D colliderenemy;
    
    // Start is called before the first frame update
    void Start()
    {
        //colliderenemy = GetComponent<Collider2D>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath",0f,0.5f);
        seeker.StartPath(rb.position,target.position,OnPathComplete);
    }
    void UpdatePath(){ //สั่งให้มันเดินตาม
        if(seeker.IsDone()){
            seeker.StartPath(rb.position,target.position,OnPathComplete);
        }
    }

    void OnPathComplete(Path p){
        if (!p.error){
            path = p; currentWayPoint = 0;
        }
    }

    void Update(){
        //rb.MovePosition(this.transform.position);
        //Debug.Log(rb.position.x);
        //rb.position=colliderenemy.position;
        if (path == null) return;
        if(currentWayPoint >= path.vectorPath.Count){
            Tutorial.TutorialComplete = true;
            Destroy(rb.gameObject);
            reachedEndOfPoint = true; return;
        }else {
            reachedEndOfPoint = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position,path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance){
            currentWayPoint++;
        }

        //if(force.x >= 0.01f){
          //  transform.localScale = new Vector3(-1,1,1);
        //}
        //else if (force.x <= -0.01f){
          //  transform.localScale = new Vector3(1,1,1);
        //}
    }
}
