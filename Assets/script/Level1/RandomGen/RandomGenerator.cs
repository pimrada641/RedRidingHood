using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomGenerator : MonoBehaviour  {
    public List<Item<GameObject>> Items;
    
    public void SortPossibility() {
        Items.Sort((item1, item2) => (int)(100 * (item1.Chance - item2.Chance)));
    }

    public Item<GameObject> Execute() {
        var chance = Random.Range(0, 100);
        var gotcha = Items.Find(item => (item.Chance * 100) > chance);
        return gotcha;
    }
}
