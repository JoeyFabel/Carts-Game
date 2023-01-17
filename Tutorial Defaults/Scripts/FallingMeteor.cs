using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteor : MonoBehaviour
{
    // Start is called before the first frame update
    float lifetime;
    void Start()
    {
        lifetime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > 20)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
