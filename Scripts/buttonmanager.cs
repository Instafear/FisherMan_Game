using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonmanager : MonoBehaviour
{
    public hook h;
    public Button length;
    public Button strength;
    public Button offline;
    public void Awake()
    {
        h.load();
    }

    // Update is called once per frame
    void Update()
    {
        h.load();

        if (h.totalpaise<h.valuelength || h.lenght<-480)
        {
            length.interactable = false;
        }
        else if(h.lenght<-480)
        {
            length.interactable = false;
        }
        else if(h.lenght>-480 && h.totalpaise>h.valuelength)
            length.interactable = true;

        if (h.totalpaise < h.valuestrength)
        {
            strength.interactable = false;
        }
        else
            strength.interactable = true;

        if (h.totalpaise < h.offprice)
        {
            offline.interactable = false;
        }
        else
            offline.interactable = true;
    }
}
