using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    // Start is called before the first frame update

    public Scrollbar scrollbar;
    public RectTransform viewport;
    public Button[] buttons;
    public int numButtonsOnScreen;

    private GameObject currentSelection;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        currentSelection = EventSystem.current.currentSelectedGameObject.gameObject;

        /*    if (buttons[0] == currentSelection) print("button 1 is selected");
            if (buttons[1] == currentSelection) print("button 2 is selected");
            if (buttons[2] == currentSelection) print("button 3 is selected");
            if (buttons[3] == currentSelection) print("button 4 is selected");
            if (buttons[4] == currentSelection) print("button 5 is selected");
            if (buttons[5] == currentSelection) print("button 6 is selected");
            if (buttons[6] == currentSelection) print("button 7 is selected");
            if (buttons[7] == currentSelection) print("button 8 is selected");

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] == currentSelection)
                {
                    print(currentSelection.ToString());
                    if (i >= numButtonsOnScreen) print(buttons[i].ToString() + " is out of view");
                }
            }*/
        //   if (currentSelection = buttons[i])
        // if(currentSelection != null) print(currentSelection.GetComponent<RectTransform>());
        print(currentSelection.GetComponentInChildren<RectTransform>().rect.yMin);
        if (currentSelection.GetComponentInChildren<RectTransform>().rect.yMin >= viewport.rect.yMax) print(currentSelection.ToString() + "is in sight");

    }
}
