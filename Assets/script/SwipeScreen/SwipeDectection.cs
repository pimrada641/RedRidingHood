using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDectection : MonoBehaviour
{
    private float minDistance = .2f;
    private float maxTime = 1f;

    InputManager inputManager;
    Vector2 startPosition;
    float startTime;
    Vector2 endPosition;
    float endTime;

    float directionThreshold = .9f;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    void SwipeStart(Vector2 postion, float time)
    {
        startPosition = postion; startTime = time;
    }

    void SwipeEnd(Vector2 postion, float time)
    {
        endPosition = postion; endTime = time;
        DetectSwipe();
    }

    void DetectSwipe()
    {
        Debug.Log("Start pos = " + startPosition); Debug.Log("End pos = " + endPosition);
        if (Vector3.Distance(startPosition,endPosition) >= minDistance && (endTime - startTime) <= maxTime)
        {
            Debug.Log("Swipe detected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            
            Vector3 direction = endPosition - startPosition; //Detect Direction
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            swipeDectection(direction2D);
        }
    }

    void swipeDectection(Vector2 direction){

        if(Vector2.Dot(Vector2.up,direction) > directionThreshold){
            Debug.Log("Swipe Up");
        }
        else if(Vector2.Dot(Vector2.down,direction) > directionThreshold){
            Debug.Log("Swipe down");
        }
        else if(Vector2.Dot(Vector2.left,direction) > directionThreshold){
            Debug.Log("Swipe left");
        }
        else if(Vector2.Dot(Vector2.right,direction) > directionThreshold){
            Debug.Log("Swipe right");
        }
    }
}
