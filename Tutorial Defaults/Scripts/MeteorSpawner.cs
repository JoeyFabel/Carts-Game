using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    [Tooltip("How often a meteor is spawned, in seconds")]
    public float frequency = 10f;
    [Tooltip("The variation in the scale of the object, in multiples, with 1 being default")]
    public float sizeVariation = 1f;
    private float defaultScale = 100f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frequency)
        {
            spawnMeteor();
            timer = 0f;
        }

    }

    private void spawnMeteor()
    {
        //determine scale of meteor
        float scale = defaultScale * Random.Range(1 / sizeVariation, sizeVariation); //The default scale is multiplied by a random number between 1/size variation and size varition.
        //If set to 1, the scale will always equal 1. If set to 2, it will be anwhere betweem 1/2 to 2 times the original scale, etc.

        //determine position of meteor
        float minXPos = gameObject.transform.position.x - (gameObject.transform.localScale.x / 2); //determine the minimum and maximum
        float maxXPos = gameObject.transform.position.x + (gameObject.transform.localScale.x / 2); //values for the range for both the
        float minZPos = gameObject.transform.position.z - (gameObject.transform.localScale.z / 2); //x and z coordinates
        float maxZPos = gameObject.transform.position.z + (gameObject.transform.localScale.z / 2);

        //starting position is at game object height, anywhere in the area o
        Vector3 randomPos = Random.insideUnitSphere * gameObject.transform.localScale.x / 2;
        randomPos.x -= gameObject.transform.position.x; //subtract offset
        randomPos.y = gameObject.transform.position.y;
        randomPos.z -= gameObject.transform.position.z; //subtract offset

        GameObject newMeteor = Instantiate<GameObject>(meteor, null);
        newMeteor.transform.SetPositionAndRotation(randomPos, Random.rotation);
        newMeteor.transform.localScale = new Vector3(scale, scale, scale);
    }
}
