using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
public class KartBelowLand : MonoBehaviour
{
    public GameObject kart;
    [Tooltip ("The height that the kart is raised when it falls through the ground")]
    public Transform upPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BelowLand")
        {
            KartBeneathLand();
        }        
    }

    void KartBeneathLand()
    {
        print("kart below land!");
        kart.transform.position.Set(kart.transform.position.x, kart.transform.position.y + upPosition.position.y, kart.transform.position.z);
    }
    private void OnTriggerStay(Collider other) //in case the kart fell too far below land.
    {
        if (other.tag =="BelowLand")
        {
            KartBeneathLand();
        }
    }
}
