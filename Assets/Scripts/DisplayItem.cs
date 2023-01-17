using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItem : MonoBehaviour
{
    public GameObject cone;
    public GameObject rock;
    public GameObject boost;
    public GameObject background;
    void Start()
    {
        cone.SetActive(false);
        rock.SetActive(false);
        boost.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.control.player1Item == GameControl.Items.CONE) cone.SetActive(true);
        else cone.SetActive(false);
        if (GameControl.control.player1Item == GameControl.Items.ROCK) rock.SetActive(true);
        else rock.SetActive(false);
        if (GameControl.control.player1Item == GameControl.Items.BOOST) boost.SetActive(true);
        else boost.SetActive(false);
        if (GameControl.control.player1Item == GameControl.Items.NONE) background.SetActive(false);
        else background.SetActive(true);
    }
}
