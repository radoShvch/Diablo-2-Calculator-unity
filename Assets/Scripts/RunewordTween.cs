using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunewordTween : MonoBehaviour
{


    public void RwTweener()
    {
        
        LeanTween.moveLocalX(gameObject, 0f, 0.1f);
    }
    public void RwDeTweener()
    {
        LeanTween.moveLocalX(gameObject, 262.9f, 0.1f);
    }
}
