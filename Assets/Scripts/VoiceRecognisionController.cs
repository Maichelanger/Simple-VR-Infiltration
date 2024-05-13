using UnityEngine;
using Oculus.Voice;
using System.Collections.Generic;

public class VoiceRecognisionController : MonoBehaviour
{
    [SerializeField] private GameObject[] shapes;

    private AppVoiceExperience appVoiceExperience;
    private Dictionary<string, Color> colorDictionary;

    private void Awake()
    {
        appVoiceExperience = GetComponent<AppVoiceExperience>();
        InitializeColorDictionary();
    }

    private void InitializeColorDictionary()
    {
        colorDictionary = new Dictionary<string, Color>
        {
            { "rojo", Color.red },
            { "azul", Color.blue },
            { "verde", Color.green },
            { "amarillo", Color.yellow },
            { "blanco", Color.white },
            { "negro", Color.black }
        };
    }

    public void GetShapeChange(string[] values)
    {
        string shape = values[1];
        shape = shape.ToLower();
        string color = values[0];
        color = color.ToLower();

        Debug.Log(shape + " " +  color);

        foreach (GameObject shapeObject in shapes)
        {
            if (shapeObject.tag == shape)
            {
                if (colorDictionary.ContainsKey(color))
                {
                    shapeObject.GetComponent<MeshRenderer>().material.color = colorDictionary[color];
                }
                else
                {
                    Debug.LogWarning("Color not found in dictionary: " + color);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            appVoiceExperience.Activate();
        }
    }
}
