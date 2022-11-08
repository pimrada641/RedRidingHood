using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Item <T> {
    public string Name = "Item"; 
    [Range(0,1)]
    public float Chance = 1f;
    public T Prefab;
}