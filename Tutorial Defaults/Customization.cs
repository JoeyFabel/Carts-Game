using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchP1HatByNumber(int hat)
    {
        if (hat == 0) GameControl.control.P1NoHatActive = true;
        else GameControl.control.P1NoHatActive = false;
        if (hat == 1) GameControl.control.P1PartyHatActive = true;
        else GameControl.control.P1PartyHatActive = false;
        if (hat == 2) GameControl.control.P1WizardHatActive = true;
        else GameControl.control.P1WizardHatActive = false;
        if (hat == 3) GameControl.control.P1CowboyHatActive = true;
        else GameControl.control.P1CowboyHatActive = false;
        if (hat == 4) GameControl.control.P1MushroomHatActive = true;
        else GameControl.control.P1MushroomHatActive = false;
        if (hat == 5) GameControl.control.P1TopHatActive = true;
        else GameControl.control.P1TopHatActive = false;
        GameControl.control.p1HatChanged = true;
    }

    public void SwitchP2HatByNumber(int hat)
    {
        if (hat == 0) GameControl.control.P2NoHatActive = true;
        else GameControl.control.P2NoHatActive = false;
        if (hat == 1) GameControl.control.P2PartyHatActive = true;
        else GameControl.control.P2PartyHatActive = false;
        if (hat == 2) GameControl.control.P2WizardHatActive = true;
        else GameControl.control.P2WizardHatActive = false;
        if (hat == 3) GameControl.control.P2CowboyHatActive = true;
        else GameControl.control.P2CowboyHatActive = false;
        if (hat == 4) GameControl.control.P2MushroomHatActive = true;
        else GameControl.control.P2MushroomHatActive = false;
        if (hat == 5) GameControl.control.P2TopHatActive = true;
        else GameControl.control.P2TopHatActive = false;
        GameControl.control.p2HatChanged = true;
    }

    public void SwitchPlayer1Color(string color)
    {
        GameControl.control.currentP1Color = color;
        GameControl.control.p1ColorChanged = true;
        //if (color == "Green") GameControl.control.currentP1Color = "Green";// = GameControl.control.Green;//.CopyPropertiesFromMaterial(GameControl.control.Green);
        // if (color == "Red") GameControl.control.currentP1Color = "Red"; =// GameControl.control.Red;//.CopyPropertiesFromMaterial(GameControl.control.Red);
        // if (color == "Yellow") GameControl.control. = //GameControl.control.Yellow;//.CopyPropertiesFromMaterial(GameControl.control.Yellow);
        // if (color == "Blue") GameControl.control.P1KartMaterial = //GameControl.control.Blue;//.CopyPropertiesFromMaterial(GameControl.control.Blue);
        // if (color == "Orange") GameControl.control.P1KartMaterial = //GameControl.control.Orange;//.CopyPropertiesFromMaterial(GameControl.control.Orange);
        // if (color == "Ghost") GameControl.control.P1KartMaterial = //GameControl.control.Ghost;//.CopyPropertiesFromMaterial(GameControl.control.Ghost);
    }

    public void SwitchPlayer2Color(string color)
    {
        GameControl.control.currentP2Color = color;
        GameControl.control.p2ColorChanged = true;
    }
}
