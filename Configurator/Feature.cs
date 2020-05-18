using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Feature", menuName = "Configurator/Feature")]
public class Feature : ScriptableObject
{
    public int price;
    public Toggle toggle;
    public string text;

}
