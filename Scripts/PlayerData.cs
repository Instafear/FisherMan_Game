using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class PlayerData
{
    public int length;
    public int strength;
    public int paise;
    public int valuelength;
    public int valuestrength;
    public int offprice;
    public float valueoff;
    public string lastlogin;
   public PlayerData(hook h)
    {
        length = h.lenght;
        strength = h.strength;
        paise =h.totalpaise;
        valuestrength=h.valuestrength;
        valuelength = h.valuelength;
        valueoff = h.valueoff;
        offprice = h.offprice;
        lastlogin = h.last_login;
    }

}
