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
    
    void Awake(){
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
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
            path = p;
            currentWayPoint = 0;
        }
    }

    void Update(){
        if (path == null) return;
        
        if(currentWayPoint >= path.vectorPath.Count){
            Tutorial.TutorialComplete = reachedEndOfPoint = true;
            Destroy(rb.gameObject);
            return;
        }
        
        reachedEndOfPoint = false;
        rb.AddForce(GetForce());
        
        float distance = GetDistance();
        if (distance < nextWayPointDistance){
            currentWayPoint++;
        }
    }
    Vector2 GetDiffVector() => ((Vector2) path.vectorPath[currentWayPoint] - rb.position);
    Vector2 GetDirection() => GetDiffVector().normalized;
    float GetDistance() => GetDiffVector().sqrMagnitude;
    Vector2 GetForce() => GetDirection() * speed * Time.deltaTime;
}
