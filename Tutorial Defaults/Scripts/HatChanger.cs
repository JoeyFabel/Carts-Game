using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
public class HatChanger : MonoBehaviour
{

    public GameObject PartyHat;
    public GameObject TopHat;
    public GameObject WizardHat;
    public GameObject CowboyHat;
    public GameObject MushroomHat;
    public GameObject NoHat;

    public Material KartRacerMaterial;

    private int player;
    //add more hats here

    // Start is called before the first frame update   
    void Start()
    {
        player = gameObject.GetComponent<GamepadInput>().player;
        determineColor();
        determineHat();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 1 && GameControl.control.p1HatChanged) determineHat();
        if (player == 2 && GameControl.control.p2HatChanged) determineHat();
        if (player == 1 && GameControl.control.p1ColorChanged) determineColor();
        if (player == 2 && GameControl.control.p2ColorChanged) determineColor();


     /*   if(gameObject.GetComponent<GamepadInput>().player == 1)
        {
            GameControl.control.currentPlayer1Color = KartRacerMaterial.color.ToString();
            print(KartRacerMaterial.color.ToString());

            GameControl.control.P1CowboyHatActive = CowboyHat.activeInHierarchy;
            GameControl.control.P1MushroomHatActive = MushroomHat.activeInHierarchy;
            GameControl.control.P1NoHatActive = NoHat.activeInHierarchy;
            GameControl.control.P1PartyHatActive = PartyHat.activeInHierarchy;
            GameControl.control.P1TopHatActive = TopHat.activeInHierarchy;
            GameControl.control.P1WizardHatActive = WizardHat.activeInHierarchy;
        }
        else if (gameObject.GetComponent<GamepadInput>().player == 2)
        {
            GameControl.control.currentPlayer2Color = KartRacerMaterial.color.ToString();
            print(KartRacerMaterial.color.ToString());

            GameControl.control.P2CowboyHatActive = CowboyHat.activeInHierarchy;
            GameControl.control.P2MushroomHatActive = MushroomHat.activeInHierarchy;
            GameControl.control.P2NoHatActive = NoHat.activeInHierarchy;
            GameControl.control.P2PartyHatActive = PartyHat.activeInHierarchy;
            GameControl.control.P2TopHatActive = TopHat.activeInHierarchy;
            GameControl.control.P2WizardHatActive = WizardHat.activeInHierarchy;
        } */
        
    }
    void determineHat()
    {
        if (player == 1)
        {
            PartyHat.SetActive(GameControl.control.P1PartyHatActive);
            TopHat.SetActive(GameControl.control.P1TopHatActive);
            WizardHat.SetActive(GameControl.control.P1WizardHatActive);
            CowboyHat.SetActive(GameControl.control.P1CowboyHatActive);
            MushroomHat.SetActive(GameControl.control.P1MushroomHatActive);
            NoHat.SetActive(GameControl.control.P1NoHatActive);
            GameControl.control.p1HatChanged = false;
        }
        if (player == 2)
        {
            PartyHat.SetActive(GameControl.control.P2PartyHatActive);
            TopHat.SetActive(GameControl.control.P2TopHatActive);
            WizardHat.SetActive(GameControl.control.P2WizardHatActive);
            CowboyHat.SetActive(GameControl.control.P2CowboyHatActive);
            MushroomHat.SetActive(GameControl.control.P2MushroomHatActive);
            NoHat.SetActive(GameControl.control.P2NoHatActive);
            GameControl.control.p2HatChanged = false;
        }
    }
    void determineColor()
    {
        if (player == 1)
        {
            if (GameControl.control.currentP1Color == "Red") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Red);
            if (GameControl.control.currentP1Color == "Green") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Green);
            if (GameControl.control.currentP1Color == "Orange") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Orange);
            if (GameControl.control.currentP1Color == "Blue") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Blue);
            if (GameControl.control.currentP1Color == "Yellow") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Yellow);
            if (GameControl.control.currentP1Color == "Ghost") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Ghost);
            GameControl.control.p1ColorChanged = false;
        }
        else if (player == 2)
        {
                if (GameControl.control.currentP2Color == "Red") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Red);
                if (GameControl.control.currentP2Color == "Green") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Green);
                if (GameControl.control.currentP2Color == "Orange") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Orange);
                if (GameControl.control.currentP2Color == "Blue") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Blue);
                if (GameControl.control.currentP2Color == "Yellow") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Yellow);
                if (GameControl.control.currentP2Color == "Ghost") KartRacerMaterial.CopyPropertiesFromMaterial(GameControl.control.Ghost);
            GameControl.control.p2ColorChanged = false;
        }
    }
}
