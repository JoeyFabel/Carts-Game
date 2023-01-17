using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class GamepadMenuController : MonoBehaviour
{
    public GameObject kart;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        


       if (kart.GetComponent<GamepadInput>().enabled == true)
        {
           
        }
    }
}
