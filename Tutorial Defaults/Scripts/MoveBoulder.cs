using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoulder : MonoBehaviour
{
    public Rigidbody boulder;
    public Vector3 movementDirection;
    public ForceMode forceMode;
    public bool upsideDown = false;
    //public ParticleSystem destructionEffect;
  //  public KartMovement kart;

    float timer = 0f;
    void Start()
    {
          // boulder.AddForce(boulder.transform.localPosition, forceMode);   
          if (GameControl.control.p1ShootRockForward)
        {
            movementDirection.z *= -1;
        }
            boulder.AddRelativeForce(movementDirection, ForceMode.VelocityChange);

        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (upsideDown == true)
        {
            Vector3 newGravity = new Vector3(0, (-Physics.gravity.y), 0);
            boulder.useGravity = false;
            boulder.AddForce(newGravity, ForceMode.Force);
        }

        timer += Time.deltaTime;
        if (timer > 7)
        {
            Object.Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("collided");
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            collision.gameObject.GetComponent<KartMovement>().StartCoroutine(DisableControls(2, collision.gameObject.GetComponent<KartMovement>()));
            Object.Destroy(gameObject);
        }

    }
    IEnumerator DisableControls(float time, KartMovement kart)
    {
        kart.GetComponent<KartMovement>().DisableControl();     
        yield return new WaitForSeconds(time);
        kart.GetComponent<KartMovement>().EnableControl();
    }
}
