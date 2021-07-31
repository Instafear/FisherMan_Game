using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class texteditor : MonoBehaviour
{
    public Text textstrength;
    public Text textlength;
    public Text textoff;
    public Text strength;
    public Text length;
    public Text earn;
    public hook h;
    public Text paise;
    private void Awake()
    {
     
        h.strength = 3;
        h.lenght = -50;
        h.valueoff = 0.1f;
        h.totalpaise = 0;
        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            PlayerData data = Savegame.lg();
            //strength
            h.valuestrength = data.valuestrength;
            h.strength = data.strength;
            //length
            h.lenght = data.length;
            h.valuelength = data.valuelength;
            h.valueoff = data.valueoff;
            h.totalpaise = data.paise;
        }
        textstrength.text = h.valuestrength.ToString() + "$";
        textlength.text = h.valuelength.ToString()+"$";
        strength.text = h.strength.ToString();
        length.text = (-1*h.lenght).ToString() + "m";
        textoff.text = (h.offprice).ToString() + "$";
        earn.text = ((int)(h.valueoff * 3600)).ToString() + "/h";
        paise.text = h.totalpaise.ToString() + "$";
        Savegame.sg(h);
    }
    private void Update()
    {
        h.strength = 3;
        h.lenght = -50;
        h.valueoff = 0.1f;
        h.totalpaise = 0;
        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            PlayerData data = Savegame.lg();
            //strength
            h.valuestrength = data.valuestrength;
            h.strength = data.strength;
            //length
            h.lenght = data.length;
            h.valuelength = data.valuelength;
            h.valueoff = data.valueoff;
            h.totalpaise = data.paise;
        }
        textstrength.text = h.valuestrength.ToString() + "$";
        textlength.text = h.valuelength.ToString() + "$";
        strength.text = h.strength.ToString();
        length.text = (-1 * h.lenght).ToString() + "m";
        textoff.text = (h.offprice).ToString() + "$";
        earn.text = ((int)(h.valueoff * 3600)).ToString() + "/h";
        paise.text = h.totalpaise.ToString() + "$";
        Savegame.sg(h);

     
    }
    public void str()
    {
        
        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            PlayerData data = Savegame.lg();
            textstrength.text = ((int)(data.valuestrength*1.6)).ToString() + "$";
            h.totalpaise -= h.valuestrength;
            paise.text = h.totalpaise.ToString() + "$";
            print(h.totalpaise);
            h.valuestrength= (int)(h.valuestrength*1.6f);
            h.strength++;
            strength.text = h.strength.ToString();
        }
        Savegame.sg(h);
        print(h.strength);
    }


    public void len()
    {

        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            PlayerData data = Savegame.lg();
            textlength.text = ((int)(data.valuelength * 1.6)).ToString() + "$";
            h.totalpaise -= h.valuelength;
            paise.text = h.totalpaise.ToString() + "$";
            print(h.totalpaise);
            h.valuelength = (int)(h.valuelength*1.6);
            h.lenght -= 30;
            length.text = (-1*h.lenght).ToString() + "m";
        }
        Savegame.sg(h);
        print(h.lenght);
    }
    public void offearn()
    {
        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            PlayerData data = Savegame.lg();
            textoff.text = ((int)(data.offprice*1.6)).ToString()+"$";
            h.totalpaise -= h.offprice;
            paise.text = h.totalpaise.ToString() + "$";
            print(h.totalpaise);
            h.offprice =(int)(h.offprice*1.6);
            h.valueoff += 0.01f;
            earn.text = ((int)(h.valueoff * 3600)).ToString() + "/h";
        }
        Savegame.sg(h);
    }
}

