using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public GameObject[] objects;
    public Color[] color;
    IEnumerator coroutine = null;

    private void Start()
    {
        GameObject parent = GameObject.Find("SelectedOptions");

        if (parent != null)
        {
            //if (gameObject.name.Equals("Colors"))
            //{
            //    Color myColor = parent.GetComponent<PersistentConfigurator>().selectedColor.color;
            //    foreach (GameObject obj in objects)
            //    {
            //        obj.GetComponent<Renderer>().material.SetColor("_Color", myColor);
            //    }
            //}
            if (gameObject.name.Equals("Upholstery"))
            {
                Color myColor = parent.GetComponent<PersistentConfigurator>().selectedUpholstery.color;
                foreach (GameObject obj in objects)
                {
                    obj.GetComponent<Renderer>().material.SetColor("_Color", myColor);
                }
            }
            if (gameObject.name.Equals("Ornaments"))
            {
                Color myColor = parent.GetComponent<PersistentConfigurator>().selectedOrnaments.color;
                foreach (GameObject obj in objects)
                {
                    obj.GetComponent<Renderer>().material.SetColor("_Color", myColor);
                }
            }
        }
        else
        {
            Debug.Log("no preconfig");
        }
        gameObject.SetActive(false);
    }
    public void ColorPointerEnter(int index)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = WaitForOption(index);
        StartCoroutine(coroutine);
    }

    public void ColorPointerExit()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    public void ChangeTo(int index)
    {
        foreach (GameObject obj in objects)
        {
            obj.GetComponent<Renderer>().material.SetColor("_Color", color[index]);
        }

        
    }

    private IEnumerator WaitForOption(int index)
    {
        yield return new WaitForSecondsRealtime(1);
        ChangeTo(index);
    }
}
