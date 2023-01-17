using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using Cinemachine;
using KartGame.Timeline;
using KartGame.Track;

public class InitializeKartPosition : MonoBehaviour
{
    [Tooltip("Decimal representing percent chance of fog"), Range(0.00f, 1.00f)]
    public float fogChance = 0f;

    public Color fogColor;
    public float fogDensity = 0.1f;

    public Transform kartStartPosition;

    public GameObject p1kart;
    public GameObject p2kart;

    public Camera p1Cam;
    public Camera p2Cam;

    public bool isBattle = false;

 //   public Camera player1Camera;
   // public Canvas p1ItemCanvas;

    public bool simulateStart = false;//for testing only. Delete after done.

    private void Awake()
    {
    }
    void Start()
    {
        simulateStart = false;
        determineFog();

        InitializePlayers();
        InitializeCameras();
     

        if (isBattle)
        {
            p1kart.GetComponent<KartMovement>().EnableControl();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (simulateStart)
        {
            determineFog();
            simulateStart = false;
        }
            
    }
    private void determineFog()
    {
        // enable fog and set color and density. make sure fog is enabled on post-process layer on camera
        if (fogChance == 0f)
        {
            RenderSettings.fog = false;
            return;
        }
            
        if (Random.value <= fogChance)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = fogDensity;//default 0.1f 
        } else
        {
            RenderSettings.fog = false;
        }
    }

    private void InitializeCameras()
    {
        if (GameControl.control.numPlayers == 1) p1Cam.rect = new Rect(0, 0, 1, 1);
        else
        {
        p1Cam.rect = new Rect(0, 0.5f, 1, 1);
        p2Cam.rect = new Rect(0, -0.5f, 1, 1);
        }
    }
    private void InitializePlayers()
    {
        p1kart.transform.rotation = kartStartPosition.rotation;   
        
        if (GameControl.control.numPlayers == 2)
        {
            p2kart.SetActive(true);
            p2Cam.gameObject.SetActive(true);
            p1kart.transform.position = new Vector3(kartStartPosition.position.x + 2, kartStartPosition.position.y, kartStartPosition.position.z);
            p2kart.transform.position = new Vector3(kartStartPosition.position.x - 2, kartStartPosition.position.y, kartStartPosition.position.z);
            p2kart.transform.rotation = kartStartPosition.rotation;
        }
        else
        {
            p1kart.transform.position = kartStartPosition.position;
            p2kart.SetActive(false);
            p2Cam.gameObject.SetActive(false);
        }
    }
}
