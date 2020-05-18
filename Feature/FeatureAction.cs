using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeatureAction : MonoBehaviour
{
    IEnumerator coroutine = null;
    public Image image;
    public GameObject presentation;

    public void ColorPointerEnter()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = WaitForOption();
        StartCoroutine(coroutine);
    }

    public void ColorPointerExit()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    public void Activate()
    {
        presentation.SetActive(!presentation.activeSelf);
        
    }

    private IEnumerator WaitForOption()
    {
        yield return new WaitForSecondsRealtime(2);
        Activate();
    }
}
