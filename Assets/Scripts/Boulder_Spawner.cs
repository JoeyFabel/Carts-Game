using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Spawner : MonoBehaviour
{
    public Jungle_Boulder boulder;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boulder.startBoulder();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            boulder.startBoulder();
        }
    }
}
