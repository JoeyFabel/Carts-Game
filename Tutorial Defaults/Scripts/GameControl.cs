using KartGame.Timeline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using KartGame.Track;
public class GameControl : MonoBehaviour
{

    public static GameControl control;
    public class RacingCup
    { //scenes load by scene name. These variables will contain 4 string names, one for each race, along with a variable telling what the current race is.
        public string firstRace;
        public string secondRace;
        public string thirdRace;
        public string fourthRace;
        public string cupName;
        public string trackPrefix;
    }

    public Material Green;
    public Material Blue;
    public Material Orange;
    public Material Red;
    public Material Yellow;
    public Material Ghost;

    public int numPlayers;

    public bool SceneLoaded;

    public bool P1PartyHatActive;
    public bool P1TopHatActive;
    public bool P1WizardHatActive;
    public bool P1CowboyHatActive;
    public bool P1MushroomHatActive;
    public bool P1NoHatActive;

    public string currentP1Color;
    public string currentP2Color;

    public bool p1HatChanged;
    public bool p1ColorChanged;
    public bool p2HatChanged;
    public bool p2ColorChanged;

    public bool P2PartyHatActive;
    public bool P2TopHatActive;
    public bool P2WizardHatActive;
    public bool P2CowboyHatActive;
    public bool P2MushroomHatActive;
    public bool P2NoHatActive;

    public bool p1ShootRockForward = true;
    public bool p2ShootRockForward = true;

    public int currentRaceNumber;

    [Tooltip("The minimum required time to get a drift boost")]
    public float minimumDriftTime = 1.5f;
    [Tooltip("The time required to go from a little to a big drift boost")]
    public float bigDriftTime = 2.75f;

    /*  private static Material playerGreen;
      private static Material playerBlue;
      private static Material playerOrange;
      private static Material playerRed;
      private static Material playerYellow;
      private static Material playerGhost;*/

    public RacingCup[] cups = new RacingCup[4]; //array which holds all cups. Cup number/order is important for loading cups.

    public static RacingCup outdoorCup; //cups are static in order to prevent the individual cup from accidentaly being accessed or changed.
    public static RacingCup snowCup;
    public static  RacingCup desertCup;
    public static RacingCup spaceCup;

    TrackRecord outdoortrack1BestLap;

    [RequireInterface(typeof(IRacer))]
    public UnityEngine.Object racer;
    public enum Items
    {
        NONE = 0,
        BOOST = 1,
        CONE = 2,
        ROCK = 3
    }

    public Items player1Item;
    public Items player2Item;
    private void Awake()
    {
        SceneLoaded = false;
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            player1Item = Items.NONE;
            LoadPlayerData();
            InitializeCups();
            control = this;
        } else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        /*playerGreen = Green;
        playerBlue = Blue;
        playerOrange = Orange;
        playerRed = Red;
        playerYellow = Yellow;
        playerGhost = Ghost;*/
    }

    public float getTrackBestTime(string trackName)
    {
        TrackRecord track = TrackRecord.Load(trackName, 3);
        return track.time;
        /*
         laps = total number of laps being looked at(3 = whole race)
         name = name of player who set record(name of object)
         time = time of all laps looked at
         track name = name of track
         */
    }

    public void setPlayers(int players)
    {
        numPlayers = players;
    }

    void InitializeCups()
    {
        outdoorCup = new RacingCup();
        outdoorCup.cupName = "Outdoor Cup";
        outdoorCup.firstRace = "Outdoor Track 1";
        outdoorCup.secondRace = "Outdoor Track 2";
        outdoorCup.thirdRace = "Outdoor Track 3";
        outdoorCup.fourthRace = "Outdoor Track 4";
        outdoorCup.trackPrefix = "Outdoor Track ";

        snowCup = new RacingCup();
        snowCup.cupName = "Snow Cup";
        snowCup.firstRace = "Snow Track 1";
        snowCup.secondRace = "Snow Track 2";
        snowCup.thirdRace = "Snow Track 3";
        snowCup.fourthRace = "Snow Track 4";
        snowCup.trackPrefix = "Snow Track ";

        desertCup = new RacingCup();
        desertCup.cupName = "Desert Cup";
        desertCup.firstRace = "Desert Track 1";
        desertCup.secondRace = "Desert Track 2";
        desertCup.thirdRace = "Desert Track 3";
        desertCup.fourthRace = "Desert Track 4";
        desertCup.trackPrefix = "Desert Track ";

        spaceCup = new RacingCup();
        spaceCup.cupName = "Space Cup";
        spaceCup.firstRace = "Space Track 1";
        spaceCup.secondRace = "Space Track 2";
        spaceCup.thirdRace = "Space Track 3";
        spaceCup.fourthRace = "Space Track 4";
        spaceCup.trackPrefix = "Space Track ";

        cups[0] = outdoorCup;
        cups[1] = snowCup;
        cups[2] = desertCup;
        cups[3] = spaceCup;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGame.dat");

        PlayerData save = new PlayerData();
       // save.NoHatEnabled = GameControl.control.NoHatActive;
        save.P1PartyHatEnabled = GameControl.control.P1PartyHatActive;
        save.P1WizardHatEnabled = GameControl.control.P1WizardHatActive;
        save.P1CowboyHatEnabled = GameControl.control.P1CowboyHatActive;
        save.P1MushroomHatEnabled = GameControl.control.P1MushroomHatActive;
        save.P1TopHatEnabled = GameControl.control.P1TopHatActive;
        save.P1TopHatEnabled = GameControl.control.P1TopHatActive;

        save.P2PartyHatEnabled = GameControl.control.P2PartyHatActive;
        save.P2WizardHatEnabled = GameControl.control.P2WizardHatActive;
        save.P2CowboyHatEnabled = GameControl.control.P2CowboyHatActive;
        save.P2MushroomHatEnabled = GameControl.control.P2MushroomHatActive;
        save.P2TopHatEnabled = GameControl.control.P2TopHatActive;
        save.P2TopHatEnabled = GameControl.control.P2TopHatActive;

        if (GameControl.control.currentP1Color == "Green") save.currentPlayer1Color = "Green";
        else if (GameControl.control.currentP1Color == "Red") save.currentPlayer1Color = "Red";
        else if (GameControl.control.currentP1Color == "Blue") save.currentPlayer1Color = "Blue";        
        else if (GameControl.control.currentP1Color == "Orange") save.currentPlayer1Color = "Orange";
        else if (GameControl.control.currentP1Color == "Yellow") save.currentPlayer1Color = "Yellow";
        else if (GameControl.control.currentP1Color == "Ghost") save.currentPlayer1Color = "Ghost";

        if (GameControl.control.currentP2Color == "Green") save.currentPlayer2Color = "Green";
        else if (GameControl.control.currentP2Color == "Red") save.currentPlayer2Color = "Red";
        else if (GameControl.control.currentP2Color == "Blue") save.currentPlayer2Color = "Blue";
        else if (GameControl.control.currentP2Color == "Orange") save.currentPlayer2Color = "Orange";
        else if (GameControl.control.currentP2Color == "Yellow") save.currentPlayer2Color = "Yellow";
        else if (GameControl.control.currentP2Color == "Ghost") save.currentPlayer2Color = "Ghost";

        bf.Serialize(file, save);
        
        file.Close();
    }

    public void LoadPlayerData()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGame.dat"))
        {
            print("loading");

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGame.dat", FileMode.Open);

            PlayerData save = (PlayerData)bf.Deserialize(file);

            P1NoHatActive = save.P1NoHatEnabled;
            P1PartyHatActive = save.P1PartyHatEnabled;
            P1WizardHatActive = save.P1WizardHatEnabled;
            P1CowboyHatActive = save.P1CowboyHatEnabled;
            P1MushroomHatActive = save.P1MushroomHatEnabled;
            P1TopHatActive = save.P1TopHatEnabled;
            currentP1Color = save.currentPlayer1Color;

            P2NoHatActive = save.P2NoHatEnabled;
            P2PartyHatActive = save.P2PartyHatEnabled;
            P2WizardHatActive = save.P2WizardHatEnabled;
            P2CowboyHatActive = save.P2CowboyHatEnabled;
            P2MushroomHatActive = save.P2MushroomHatEnabled;
            P2TopHatActive = save.P2TopHatEnabled;
            currentP2Color = save.currentPlayer2Color;

            file.Close();
        } else
        {
            P1PartyHatActive = false;
            P1TopHatActive = false;
            P1WizardHatActive = false;
            P1CowboyHatActive = false;
            P1MushroomHatActive = false;
            P1NoHatActive = true;
            currentP1Color = "Green";

            P2PartyHatActive = false;
            P2TopHatActive = false;
            P2WizardHatActive = false;
            P2CowboyHatActive = false;
            P2MushroomHatActive = false;
            P2NoHatActive = true;
            currentP2Color = "Green";
            print("no save found");
        }
    }

    [Serializable]
    public class PlayerData
    {
        public bool P1PartyHatEnabled;
        public bool P1WizardHatEnabled;
        public bool P1CowboyHatEnabled;
        public bool P1MushroomHatEnabled;
        public bool P1TopHatEnabled;
        public bool P1NoHatEnabled;
        public string currentPlayer1Color;

        public bool P2PartyHatEnabled;
        public bool P2WizardHatEnabled;
        public bool P2CowboyHatEnabled;
        public bool P2MushroomHatEnabled;
        public bool P2TopHatEnabled;
        public bool P2NoHatEnabled;
        public string currentPlayer2Color;

    }


    // Update is called once per frame
    void Update()
    {
        CheckShootDirection();
    }
    void CheckShootDirection()
    {
        //whether to shoot rock forward or back
        if (Input.GetAxisRaw("P1Vertical") < -0.2)
        {
            p1ShootRockForward = false; //if the left stick is pressed backwards, but more than just slightly backwards
        } else
        {
            p1ShootRockForward = true; //if the left stick is not pressed backwards
        } //default rock launch direction is forwards
    }


    //Functions for loading scenes;
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        //  GameControl.control.BackgroundMusic.Stop();
    }
    public string nextTrackName;
    private string currentCupPrefix = "Outdoor Track ";
    public void LoadCup(int cupNumber)
    { //cups: 0 = outdoor, 1 = snow, 2 = desert, 3 = space
      //when loading, combine cup.trackPrefix with current race number to get the correct track.
        currentCupPrefix = GameControl.control.cups[cupNumber].trackPrefix;
        GameControl.control.currentRaceNumber = 1;
        LoadNextRace();
    }
    public void LoadNextRace()
    {
        nextTrackName = currentCupPrefix + GameControl.control.currentRaceNumber;//track prefix includes space between prefix and number     
        print("loading " + nextTrackName);
        SceneManager.LoadScene(nextTrackName);
    }
}
