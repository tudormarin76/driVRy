using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Color", menuName = "Configurator/Color")]
public class ConfigColor : ScriptableObject
{
    public Color color;
    public Sprite backgroundImage;
    public int price;
}
