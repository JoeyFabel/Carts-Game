using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using Cinemachine;
public class ReverseGravity : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion rotation;
    public bool upsideDown = false;
    private bool rotating = false;
    private bool flipping = false;
    [Tooltip("the higher the number, the faster the rotation")]
    public float rotationTime = 3f;

    private Vector3 flipPosition;

    public float flipHeight = 7.75f;
    [Tooltip("the higher the number, the faster the flip")]
    public float flipTime = 3f;

    private float flipError = 1f;

    private bool flipDone;
    private bool rotateDone;
    void Start()
    {
        flipError = 0.5f;
        flipping = false;
        rotating = false;
        rotation = Quaternion.Euler(0, 0, 180);
        flipPosition = new Vector3(transform.position.x, transform.position.y + flipHeight, transform.position.z);
    }

    // Update is called once per frame

    private float getNearest90Degree()
    {
        if (transform.rotation.eulerAngles.y > 0 && transform.rotation.eulerAngles.y < 30)
        {
            return 0;
        }
        else if (transform.rotation.eulerAngles.y >= 30 && transform.rotation.eulerAngles.y < 120)
        {
            return 90;
        }
        else if ((transform.rotation.eulerAngles.y >= 120 && transform.rotation.eulerAngles.y < 240))
        {
            return 180;
        }
        else if ((transform.rotation.eulerAngles.y >= 240 && transform.rotation.eulerAngles.y < 300))
        {
            return 270;
        }
        else if (transform.rotation.eulerAngles.y >= 300 && transform.rotation.eulerAngles.y  <= 360)
        {
            return 0;
        }
        else
        {
            //if angle is greater than 360 or some weird glitch happens, ...
            return 0;
        }
    }
    void Update()
    {
        if (upsideDown)
        {
            rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        } else
        {
            rotation = Quaternion.Euler(0, transform.eulerAngles.y, 180);
        }
        if (rotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationTime);
            if (transform.rotation == Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationTime + 0.2f))
            {
                rotateDone = true;
                rotating = false;
            }
        }
        if (flipping)
        {
            transform.position = Vector3.Lerp(transform.position, flipPosition, Time.deltaTime * flipTime);
            if (transform.position.y >= flipPosition.y - flipError && upsideDown == false || transform.position.y <= flipPosition.y + flipError && upsideDown == true)
            {
                flipHeight *= -1;
                flipping = false;
                flipDone = true;
            }
        }

        if (flipDone && rotateDone)
        {
            if (upsideDown == false)
                upsideDown = true;
            else
                upsideDown = false;
            gameObject.GetComponent<KartMovement>().Velocity.Set(0, 0, 0);
            flipDone = false;
            rotateDone = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Gravity Flip") return;
        if (flipping || rotating) return;
        flipPosition.x = transform.position.x;
        flipPosition.z = transform.position.z;
        flipPosition.y = transform.position.y + flipHeight;
        print("reversing gravity");
        KartMovement kart = gameObject.GetComponent<KartMovement>();
        kart.Velocity.Set(0, 0, 0);
        kart.defaultStats.gravity *= -1;
        //kart.transform.position = new Vector3(kart.transform.position.x, kart.transform.position.y + flipVerticalOffset, kart.transform.position.z);
        rotating = true;
        flipping = true;
      //  flipVerticalOffset *= -1;
      //  kart.transform.rotation = Quaternion.Slerp(kart.transform.rotation, rotation, Time.deltaTime * rotationTime); //rotate around z
                                                                                                                      //  kart.AddKartModifier(modifier);
    }
}
