using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public float minRotX = 0f;
    public float maxRotX = 2f;
    public float minRotY = 1f;
    public float maxRotY = 3f;
    public float minRotZ = 0f;
    public float maxRotZ = 0f;

    public ParticleSystem collectionEffect;

    private float rotX;
    private float rotY;
    private float rotZ;

    private bool disabled = false;
    private float timer;

    private MeshRenderer mesh;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * The rotation of the cube for each axis is a random
         * value between the minimum and maximimum numbers set
         */
        rotX = Random.Range(minRotX, maxRotX);
        rotY = Random.Range(minRotY, maxRotY);
        rotZ = Random.Range(minRotZ, maxRotZ);
        if (disabled == false)
        {
        RotateItemBox();
        }

        if (disabled)
        {
            timer += Time.deltaTime;
        }
        if (timer > 10f && disabled)
        {
            mesh.enabled = true;
            text.SetActive(true);
            disabled = false;
            timer = 0f;
        }
    }
    private void RotateItemBox()
    {
        gameObject.transform.Rotate(new Vector3(rotX, rotY, rotZ));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && disabled == false)
        {
         //   Object.Destroy(gameObject);
         if (GameControl.control.player1Item == GameControl.Items.NONE)
            {
                GameControl.control.player1Item =GenerateRandomItem();
                print(GameControl.control.player1Item.ToString());
            }
            
            collectionEffect.Play();
            mesh.enabled = false;
            text.SetActive(false);
            disabled = true;
        }
    }
    private GameControl.Items GenerateRandomItem()
    {
        int itemNumber = (int)Mathf.Round(Random.Range(0.5f, 3.5f));
        if (itemNumber == 1) {
            return GameControl.Items.ROCK;
        } else if (itemNumber == 2)
        {
            return GameControl.Items.CONE;
        } else if (itemNumber == 3)
        {
            return GameControl.Items.BOOST;
        } else
        {
            Debug.LogError("Item number does correspond to an item");
            return GameControl.Items.NONE;
        }
    }
}
