using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeItem : MonoBehaviour
{
    public MultiplicativeKartModifier kartEffects;
    public Rigidbody cone;
    public Vector3 coneForce;

    public bool coneDisabled = false;
   // public KartMovement kart;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && coneDisabled == false)
        {
            print("cone hit!");
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            cone.AddForce(coneForce, ForceMode.VelocityChange);
            KartMovement kart = collision.gameObject.GetComponent<KartMovement>();
            kart.StartCoroutine(KartEffecter(kart, 1f));
            coneDisabled = true;
        } else if (collision.gameObject.tag == "Rock" && coneDisabled == false)
        {
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            Object.Destroy(collision.gameObject);
            cone.AddForce(coneForce, ForceMode.VelocityChange);
            coneDisabled = true;
            StartCoroutine(DestroyCone(1f));            
        }

    }

    IEnumerator KartEffecter(KartMovement kart, float lifetime)
    {
        kart.AddKartModifier(kartEffects);
        kart.Velocity.Set(kart.Velocity.x / 2, kart.Velocity.y / 2, kart.Velocity.z / 2);
        kart.DisableControl();
        yield return new WaitForSeconds(lifetime);
        kart.EnableControl();
        kart.RemoveKartModifier(kartEffects);
        Object.Destroy(gameObject);
    }
    IEnumerator DestroyCone(float time)
    {
        yield return new WaitForSeconds(time);
        Object.Destroy(gameObject);
    }
}
