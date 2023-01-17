using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class KartBoost : MonoBehaviour
{
    public MultiplicativeKartModifier boostStats;

    public GameObject rock;

    public GameObject cone;

    public GameObject leftBoostTrail;
    public GameObject rightBoostTrail;

    public Transform rearLaunch;
    public Transform forwardLaunch;

    public KartMovement kart;
    [Range(0, 5)]
    public float duration = 1f;

    private int playerNum;
    private void Start()
    {
        //game always stutters the first time a prefab is instantiated.
        //To prevent this from happening mid-race, instantiate and destroy a copy of each item.
        GameObject newRock = Instantiate(rock, new Vector3(0, -100), new Quaternion(0, 0, 0, 0));
        GameObject newCone = Instantiate(cone, new Vector3(0, -100), new Quaternion(0, 0, 0, 0));

        playerNum = gameObject.GetComponent<GamepadInput>().player;

        Destroy(newRock);
        Destroy(newCone);
    }

    void Update()
    {

        if (Input.GetButtonDown("P" + gameObject.GetComponent<GamepadInput>().player + "Fire"))
        {
            print("Fire!");
            if (GameControl.control.player1Item == GameControl.Items.BOOST)
            {
                BoostKart();
            } else if (GameControl.control.player1Item == GameControl.Items.ROCK)
            {
                launchRock();
            } else if (GameControl.control.player1Item == GameControl.Items.CONE)
            {
                deployCone();
            }
        }
    }
    public void BoostKart()
    {
        kart.StartCoroutine(KartBooster(kart, duration));
        print("boosting");
        GameControl.control.player1Item = GameControl.Items.NONE;
    }
    IEnumerator KartBooster(KartGame.KartSystems.KartMovement kart, float lifetime)
    {
        kart.AddKartModifier(boostStats);
        leftBoostTrail.SetActive(true);
        rightBoostTrail.SetActive(true);
        yield return new WaitForSeconds(lifetime);
        kart.RemoveKartModifier(boostStats);
        yield return new WaitForSeconds(lifetime);
        leftBoostTrail.SetActive(false);
        rightBoostTrail.SetActive(false);
    }
    public void launchRock()
    {
        Transform instantiatePos;
        if (playerNum == 1)
        {
            if (GameControl.control.p1ShootRockForward)
            {
                instantiatePos = forwardLaunch;
            }
            else
            {
                instantiatePos = rearLaunch;
            }
        }
        else
        {
            if (GameControl.control.p2ShootRockForward)
            {
                instantiatePos = forwardLaunch;
            }
            else
            {
                instantiatePos = rearLaunch;
            }
        }
        GameObject launchedRock = Instantiate<GameObject>(rock, instantiatePos);
        launchedRock.transform.rotation = rearLaunch.rotation;
        launchedRock.transform.SetParent(null);
        launchedRock.SetActive(true);
        if (gameObject.GetComponent<ReverseGravity>() != null && gameObject.GetComponent<ReverseGravity>().upsideDown == true)
        {
            launchedRock.GetComponent<MoveBoulder>().upsideDown = true;
        }
        GameControl.control.player1Item = GameControl.Items.NONE;

     //   launchedRock.transform.position = rearLaunch.position;     
    }
    public void deployCone()
    {
        GameObject deployedCone = Instantiate<GameObject>(cone, rearLaunch);
        deployedCone.SetActive(true);
        GameControl.control.player1Item = GameControl.Items.NONE;
        StartCoroutine(DropCone(deployedCone));  
    }
    
    IEnumerator DropCone(GameObject cone)
    {
        while (Input.GetButtonUp("Fire") == false)
        {
            print("B is held");
            cone.transform.position = new Vector3(rearLaunch.position.x, rearLaunch.position.y + 0.01f, rearLaunch.position.z/* - 0.727f*/);
            yield return null;
        }
        print("B released");
        cone.GetComponent<ConeItem>().coneDisabled = false;
        cone.GetComponent<Rigidbody>().freezeRotation = false;
        cone.transform.SetParent(null);
    }
}
