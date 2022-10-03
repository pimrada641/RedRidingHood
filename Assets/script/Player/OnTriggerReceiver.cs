using System;
using UnityEngine;

public class OnTriggerReceiver : MonoBehaviour{
    public Action onTriggerEnter;

    public void NotifyOnTriggerEnter(){
        onTriggerEnter?.Invoke();
    }
}