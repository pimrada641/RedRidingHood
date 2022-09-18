using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClosetInputDetection : MonoBehaviour
{
    private List<GameObject> SkinList = new List<GameObject>();

    private float minDistance = .2f;
    private float maxTime = 1f;

    //public TextMeshProUGUI name, description;
    public GameObject closetfuncobject;

    AudioSource AudioChangeSound;

    ClosetFunction closetfunc;
    InputManager inputManager;
    Vector2 startPosition;
    float startTime;
    Vector2 endPosition;
    float endTime;

    float directionThreshold = .9f;
    void Update(){
        closetfunc = closetfuncobject.GetComponent<ClosetFunction>();
    }
    private void Awake()
    {
        inputManager = InputManager.Instance;
        AudioChangeSound = GetComponent<AudioSource>();
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

    void SwipeStart(Vector2 position, float time)
    {
        startPosition = position; startTime = time;
    }

    void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position; endTime = time;
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

        if(Vector2.Dot(Vector2.left,direction) > directionThreshold){
            Debug.Log("Swipe left");
            AudioChangeSound.Play();
            closetfunc.NextOption();
        }
        else if(Vector2.Dot(Vector2.right,direction) > directionThreshold){
            Debug.Log("Swipe right");
            AudioChangeSound.Play();
            closetfunc.BackOption();

        }
    }
}
