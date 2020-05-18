using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguratorImageChanger : MonoBehaviour
{
    public Sprite image;
    public Image topImage;

    public void ChangeImage()
    {
        topImage.sprite = image;
    }

}
