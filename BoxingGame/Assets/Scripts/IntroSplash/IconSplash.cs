using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class IconSplash : MonoBehaviour
{
    public Image fenrisLogo;
    public Image neonLogo;
    public string loadLevel;

    public float startIntro;
    public float fenrisT2Full;
    public float fenrisT2Null;
    public float fenrisTActive;
    public float t2none;
    public float neonT2Full;
    public float neonT2Null;
    public float neonTActive;
    public float t2ChangeScene;

    IEnumerator Start()
    {
        fenrisLogo.canvasRenderer.SetAlpha(0.0f);
        neonLogo.canvasRenderer.SetAlpha(0.0f);
        yield return new WaitForSeconds(startIntro);
        FenrisFadeIn();
        yield return new WaitForSeconds(fenrisTActive);
        FenrisFadeOut();
        yield return new WaitForSeconds(t2none);
        NeonFadeIn();
        yield return new WaitForSeconds(neonTActive);
        NeonFadeOut();
        yield return new WaitForSeconds(t2ChangeScene);
        SceneManager.LoadScene(loadLevel);
    }

    void FenrisFadeIn()
    {
        fenrisLogo.CrossFadeAlpha(1.0f, fenrisT2Full, false);
    }

    void FenrisFadeOut()
    {
        fenrisLogo.CrossFadeAlpha(0.0f, fenrisT2Null, false);
    }
    void NeonFadeIn()
    {
        neonLogo.CrossFadeAlpha(1.0f, neonT2Full, false);
    }

    void NeonFadeOut()
    {
        neonLogo.CrossFadeAlpha(0.0f, neonT2Null, false);
    }
}
