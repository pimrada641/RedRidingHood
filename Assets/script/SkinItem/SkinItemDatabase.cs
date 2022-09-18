using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This Function is applied from https://www.youtube.com/watch?v=2PKBChN10us
[CreateAssetMenu]
public class SkinItemDatabase : ScriptableObject
{
    public SkinItemList[] skinItem; 

    public int SkinCount{
        get{
            return skinItem.Length;
        }
    }

    public SkinItemList GetSkin(int index){
        return skinItem[index];
    }
}
/// End
