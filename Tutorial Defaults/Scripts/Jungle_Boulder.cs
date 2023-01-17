using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jungle_Boulder : MonoBehaviour
{
    public Rigidbody boulder;
    public Vector3 movementDirection;
    public Transform boulderRespawn;
    float timer;
    public bool timerEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        resetBoulder();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerEnabled)
        {
            timer += Time.deltaTime;
        }
       
        if (timer < 5f)
        {
            boulder.AddForce(movementDirection, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("collided");
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            collision.gameObject.GetComponent<KartMovement>().StartCoroutine(DisableControls(2, collision.gameObject.GetComponent<KartMovement>()));
            resetBoulder();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoulderBreaker")
        {
            resetBoulder();
        }
    }
    IEnumerator DisableControls(float time, KartMovement kart)
    {
        kart.GetComponent<KartMovement>().DisableControl();
        yield return new WaitForSeconds(time);
        kart.GetComponent<KartMovement>().EnableControl();
    }
    public void startBoulder()
    {
        timerEnabled = true;
        timer = 0f;
        boulder.isKinematic = false;
        boulder.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public void resetBoulder()
    {
        boulder.transform.position = boulderRespawn.position;
        boulder.isKinematic = true;
        timerEnabled = false;
        timer = 0f;
        boulder.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
