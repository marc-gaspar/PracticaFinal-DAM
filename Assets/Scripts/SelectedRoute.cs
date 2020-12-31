﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class SelectedRoute : MonoBehaviour
{
    public InputField fileNameInput;
    public Text errorNameText;
    public Text totalDistanceText;
    public Text positiveElevationText;
    public Text negativeElevationText;
    public InputField descriptionInput;

    static public Ruta ruta;
    static public string originalPath;

    private GameObject graph_windowObj;
    private Window_Graph graph_window;

    private string oldName;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Window_Graph"))
        {
            graph_windowObj = GameObject.Find("Window_Graph");
            graph_window = (Window_Graph)graph_windowObj.GetComponent(typeof(Window_Graph));

            graph_window.ShowGraph(ruta.trackPoints, ruta.pendentPunts, ruta.totalDistance);
        }

        fileNameInput.characterLimit = 100;
        descriptionInput.characterLimit = 2000;
        errorNameText.text = "";

        oldName = GetNameFromPath();
    }

    private string GetNameFromPath()
    {
        //Separem al ruta sencera
        string[] pathParts = originalPath.Split('\\');
        //Separem el nom de la extensió .gpx
        string[] nameParts = pathParts[pathParts.Length - 1].Split('.');
        //Sabem que el nom és la primera part ja que la segona es la extensio
        string fileName = nameParts[0];

        fileNameInput.text = fileName;
        
        //Debug.Log(fileName);

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConfirmRoute()
    {
        string validName = "";
        //Agafar Nom
        string newName = fileNameInput.text;
        //Comprovar si el nou nom es el mateix que l'antic ja que aixi no hem de comprovar res 
        if (oldName == newName)
        {
            validName = newName;
        }
        else {
            // Comprovar si el nou nom es valid
            validName = UseRegex(newName);
            fileNameInput.text = validName;
        }
        
        //Creem nova ruta
        string newPath = Path.Combine(Application.dataPath , "GPX", validName + ".gpx");

        Debug.Log(newPath);

        File.Copy(originalPath, newPath);
        Debug.Log("Fitxer copiat");

        //Copiar fitxer amb nou nom a la carpeta gpx

    }

    public string UseRegex(string strIn)
    {
        // Replace invalid characters with empty strings.
        return Regex.Replace(strIn, @"[^\w-_ñÑ]", "");
    }
}
