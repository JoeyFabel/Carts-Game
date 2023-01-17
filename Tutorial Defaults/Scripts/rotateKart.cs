using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateKart : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
  }

    // Update is called once per frame
    void Update()
    {
        //Rotates the kart along the right stick x axis
        gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("P1RightStickX"), 0));
    }
}
