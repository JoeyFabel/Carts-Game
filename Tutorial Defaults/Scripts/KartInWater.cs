using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
public class KartInWater : MonoBehaviour
{
    public GameObject Kart;
    public KartMovement kartMovement;
    private MultiplicativeKartModifier constantWaterEffects;
    [Tooltip ("The GameObject which is the position that you want the kart to respawn when it lands in the water1 trigger")]
    public GameObject water1;
    [Tooltip("The GameObject which is the position that you want the kart to respawn when it lands in the water2 trigger")]
    public GameObject water2;
    [Tooltip("The GameObject which is the position that you want the kart to respawn when it lands in the water3 trigger")]
    public GameObject water3;
    [Tooltip("The GameObject which is the position that you want the kart to respawn when it lands in the water4 trigger")]
    public GameObject water4;
    [Tooltip("The GameObject which is the position that you want the kart to respawn when it lands in the water5 trigger")]
    public GameObject water5;
    [Tooltip("The GameObject which is the position that you want the kart to respawn when it lands in the water6 trigger")]
    public GameObject water6;
    void Start()
    {
        constantWaterEffects = new MultiplicativeKartModifier();
        constantWaterEffects.modifiers.acceleration = 0;
        constantWaterEffects.modifiers.braking = 10;
        constantWaterEffects.modifiers.coastingDrag = 10;
        constantWaterEffects.modifiers.gravity = 1;
        constantWaterEffects.modifiers.grip = 10;
        constantWaterEffects.modifiers.hopHeight = 1;
        constantWaterEffects.modifiers.reverseAcceleration = 0;
        constantWaterEffects.modifiers.reverseSpeed = 0;
        constantWaterEffects.modifiers.topSpeed = 0.001f;
        constantWaterEffects.modifiers.turnSpeed = 1;
        constantWaterEffects.modifiers.weight = 2;   
       //TODO - Take multiplicatve kart modifier from first water course and create a constant value here.

        if (water1 == null)
        {
            water1 = new GameObject();
            water1.transform.position = new Vector3(0, 0, 0);
        }
        if (water2 == null)
        {
            water2 = new GameObject();
            water2.transform.position = new Vector3(0, 0, 0);
        }
        if (water3 == null)
        {
            water3 = new GameObject();
            water3.transform.position = new Vector3(0, 0, 0);
        }
        if (water4 == null)
        {
            water4 = new GameObject();
            water4.transform.position = new Vector3(0, 0, 0);
        }
        if (water5 == null)
        {
            water5 = new GameObject();
            water5.transform.position = new Vector3(0, 0, 0);
        }
        if (water6 == null)
        {
            water6 = new GameObject();
            water6.transform.position = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water1")
        {
            kartMovement.StartCoroutine(Respawn(water1));
        } else if(other.tag == "Water2")
        {
            kartMovement.StartCoroutine(Respawn(water2));
        } else if (other.tag == "Water3")
        {
            kartMovement.StartCoroutine(Respawn(water3));
        } else if (other.tag == "Water4")
        {
            kartMovement.StartCoroutine(Respawn(water4));
        } else if (other.tag == "Water5")
        {
            kartMovement.StartCoroutine(Respawn(water5));
        } else if (other.tag == "Water6")
        {
            kartMovement.StartCoroutine(Respawn(water6));
        }

    }

    IEnumerator Respawn(GameObject water)
    {
        kartMovement.AddKartModifier(constantWaterEffects);
        kartMovement.Velocity.Set(0, 0, 0);
        kartMovement.Movement.Set(0, 0, 0);
        kartMovement.DisableControl();
        Kart.transform.SetPositionAndRotation(water.transform.position, water.transform.rotation);
   //     Kart.transform.position = position.position;
       // Kart.transform.rotation = new Quaternion(0, -49f, 0, 0);
     //   Kart.transform.rotation.Set(0, rotation, 0, 0);
        kartMovement.Velocity.Set(0, 0, 0);
        yield return new WaitForSeconds(0.75f);
        kartMovement.RemoveKartModifier(constantWaterEffects);
        kartMovement.Movement.Set(0, 0, 0);
        kartMovement.EnableControl();
    }

}


