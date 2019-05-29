using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public float onsec;
    public float Switch;
    public Text Punch;
    IEnumerator Start()
    {
        while (true)
        {
            FadeIn();
            yield return new WaitForSeconds(onsec);
            FadeOut();
            yield return new WaitForSeconds(onsec);
        }
    }
    void FadeIn()
    {
        Punch.CrossFadeAlpha(0.2f, Switch, false);
    }
    void FadeOut()
    {
        Punch.CrossFadeAlpha(1.0f, Switch, false);
    }
}
