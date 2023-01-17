using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class DriftBoost : MonoBehaviour
{

    public AddativeKartModifier littleDriftBoost;
    public AddativeKartModifier bigDriftBoost;
    public KartMovement kart;
    public GameObject leftBoostTrail;
    public GameObject rightBoostTrail;

    public GameObject leftLittleBoostSparks;
    public GameObject rightLittleBoostSparks;
    public GameObject leftBigBoostSparks;
    public GameObject rightBigBoostSparks;

    // Start is called before the first frame update
    void Start()
    {
        leftBoostTrail.SetActive(false);
        rightBoostTrail.SetActive(false);
        leftLittleBoostSparks.SetActive(false);
        rightLittleBoostSparks.SetActive(false);
        leftBigBoostSparks.SetActive(false);
        rightBigBoostSparks.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ApplyDriftBoost(AddativeKartModifier driftBoost, float time)
    {
        leftLittleBoostSparks.SetActive(false);
        rightLittleBoostSparks.SetActive(false);
        leftBigBoostSparks.SetActive(false);
        rightBigBoostSparks.SetActive(false);
        kart.AddKartModifier(driftBoost);
        leftBoostTrail.SetActive(true);
        rightBoostTrail.SetActive(true);
        yield return new WaitForSeconds(time);
        kart.RemoveKartModifier(driftBoost);
        leftBoostTrail.SetActive(false);
        rightBoostTrail.SetActive(false);
    }
    public void DriftOver(float driftLength)
    {
        if (driftLength >= GameControl.control.minimumDriftTime && driftLength < GameControl.control.bigDriftTime)
        {
            kart.StartCoroutine(ApplyDriftBoost(littleDriftBoost, 0.5f));
        } else if (driftLength >= GameControl.control.bigDriftTime)
        {
            kart.StartCoroutine(ApplyDriftBoost(bigDriftBoost,  1f));
        }
    }

    public void littleBoostSparks()
    {
        leftLittleBoostSparks.SetActive(true);
        rightLittleBoostSparks.SetActive(true);
    }
    public void bigBoostSparks()
    {
        leftLittleBoostSparks.SetActive(false);
        rightLittleBoostSparks.SetActive(false);
        leftBigBoostSparks.SetActive(true);
        rightBigBoostSparks.SetActive(true);
    }

}
