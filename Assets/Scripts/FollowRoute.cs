﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowRoute : MonoBehaviour
{

    private GameObject graph_windowObj;
    private Window_Graph graph_window;

    static public Ruta ruta;
    static public Workout workout;


    private CadenceDisplay cadence;
    private SpeedCadenceDisplay speedCadence;
    private PowerMeterDisplay power;
    private FitnessEquipmentDisplay rodillo;
    private HeartRateDisplay heartRate;
    private SpeedDisplay speed;

    public Text elapsedTime;
    public Text hr;
    public Text spd;
    public Text pow;
    public Text cad;
    public Text dist;

    private float x100completed;
    private float graphWidth;
    private float graphHeight;

    private RectTransform graphContainer;

    private bool workoutSet;
    // Start is called before the first frame update
    void Start()
    {
        graphContainer = GameObject.Find("graphContainer").GetComponent<RectTransform>();

        if (workout != null)
        {
            workoutSet = true;
        }
        else {
            workoutSet = false;
        }

        if (GameObject.Find("Window_Graph"))
        {
            graph_windowObj = GameObject.Find("Window_Graph");
            graph_window = (Window_Graph)graph_windowObj.GetComponent(typeof(Window_Graph));
            graphWidth = graph_windowObj.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x;
            graphHeight = graph_windowObj.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.y;
           
            if (ruta != null)
            {
                graph_window.ShowGraph(ruta.trackPoints, ruta.pendentPunts, ruta.totalDistance, 160);
            }
            else {
                Debug.LogWarning("ruta == null (FollowRoute)");
            }
        }

        ConnectarSensors();

        cad.text = "--";
        spd.text = "--";
        pow.text = "--";
        elapsedTime.text = "--";
        hr.text = "--";
        dist.text = "--";
    }

    // Update is called once per frame
    void Update()
    {

        if (cadence != null)
        {
            if (cadence.connected)
            {
                cad.text = cadence.cadence.ToString();
            }
        }

        if (speedCadence != null) {
            if (speedCadence.connected)
            {
                cad.text = speedCadence.cadence.ToString();
                spd.text = speedCadence.speed.ToString();
            }
        }

        if (heartRate != null) {
            if (heartRate.connected)
            {
                hr.text = heartRate.heartRate.ToString();
            }
        }

        if (speed != null) {
            if (speed.connected)
            {
                spd.text = speed.speed.ToString();
                //uiText.text += "distance = " + GameObject.Find("SpeedDisplay").GetComponent<SpeedDisplay>().distance + "\n";
            }
        }

        if (power != null)
        {
            if (power.connected)
            {
                pow.text = power.instantaneousPower.ToString();
                //uiText.text += "cadence = " + GameObject.Find("PowerMeterDisplay").GetComponent<PowerMeterDisplay>().instantaneousCadence + "\n";    
            }
        }
        
        if (rodillo.connected)
        {
            if (!power.connected)
            {
                pow.text = rodillo.instantaneousPower.ToString();
            }

            if (!speed.connected && !speedCadence.connected)
            {
                spd.text = rodillo.speed.ToString();
            }

            if (!heartRate.connected)
            {
                hr.text = rodillo.heartRate.ToString();
            }

            if (!cadence.connected && !speedCadence.connected)
            {
                cad.text = rodillo.cadence.ToString();
            }

            elapsedTime.text = rodillo.elapsedTime.ToString();

            dist.text = rodillo.distanceTraveled.ToString();

            //ruta.totalDistance * 1000 ja que totalDistance està en Km
            x100completed = rodillo.distanceTraveled / (ruta.totalDistance * 1000);
            Debug.Log("DistanecTravel:"+ rodillo.distanceTraveled + "TotalDist(m):"+ ruta.totalDistance * 1000 + " % "+ x100completed + "%");
            //uiText.text += "distanceTraveled= " + GameObject.Find("FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>().distanceTraveled + "\n";

        }
        else {
            //Si no està connectat pausem o algo
            Debug.LogWarning("Rodillo no connectat");
        }

        //Anem movent la barra segons l'usuari va avançant en la ruta
        Vector2 puntA = new Vector2(graphWidth * x100completed, 0);
        Vector2 puntB = new Vector2(graphWidth * x100completed, graphHeight);

        DrawVerticalLine(puntA, puntB);
    }

    //Funció que serveix per buscar els diferents objectes en Unity i guardarlos en una variable
    private void ConnectarSensors()
    {
        if (GameObject.Find("CadenceDisplay"))
        {
            cadence = GameObject.Find("CadenceDisplay").GetComponent<CadenceDisplay>();
        }
        if (GameObject.Find("SpeedCadenceDisplay"))
        {
            speedCadence = GameObject.Find("SpeedCadenceDisplay").GetComponent<SpeedCadenceDisplay>();
        }
        if (GameObject.Find("HeartRateDisplay"))
        {
            heartRate = GameObject.Find("HeartRateDisplay").GetComponent<HeartRateDisplay>();
        }
        if (GameObject.Find("SpeedDisplay"))
        {
            speed = GameObject.Find("SpeedDisplay").GetComponent<SpeedDisplay>();
        }
        if (GameObject.Find("PowerMeterDisplay"))
        {
            power = GameObject.Find("PowerMeterDisplay").GetComponent<PowerMeterDisplay>();

        }
        if (GameObject.Find("FitnessEquipmentDisplay"))
        {
            rodillo = GameObject.Find("FitnessEquipmentDisplay").GetComponent<FitnessEquipmentDisplay>();
        }
    }


    private void DrawVerticalLine(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        //La x dels dos punts es la mateixa
        Debug.Log("x: " + dotPositionA.x);
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);

        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 2f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;

        rectTransform.localEulerAngles = new Vector3(0, 0, 90);

    }
}
