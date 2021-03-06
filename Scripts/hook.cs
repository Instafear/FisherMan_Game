using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.IO;
using System;
using UnityEngine.UI;
public class hook : MonoBehaviour
{
    public hook h;
    public GameObject collect;
    public GameObject panel;
    public GameObject colpanel;
    public int valuestrength=80;
    public int valuelength = 80;
    public int offprice=80;
    public float valueoff = 0.1f;
    public int num;
    public int totalpaise=0;
    public Transform hookedtr;
    public Camera mainCamera;
    public int lenght;
    public int strength=3;
    private int fishcount;
    public bool canMove;
    public Tweener cameraTween;
    public Collider2D coll;
    private List<fish_mover> hookedFishes;
    public Button playbutton;
    public Text money;
    public Text colmoney;
    public AudioSource fishcollect;
    public string last_login;
    //bgcolor
    private float lerp = 0f;
    [SerializeField]
    public Color c1;
    public Color c2;

    public void exit()
    {
        Application.Quit();
        print("quiting");
    }
    private void Awake()
    {
        totalpaise = 0;
        valueoff = 0.05f;
        valuestrength = 80;
        valuelength = 80;
        strength = 3;
        lenght = -50;
        offprice = 80;
        last_login = "";
        mainCamera = Camera.main;
        canMove = true;
        hookedFishes = new List<fish_mover>();

        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            PlayerData data = Savegame.lg();
            totalpaise = data.paise;
            lenght = data.length;
            strength = data.strength;
            valuestrength = data.valuestrength;
            valuelength = data.valuelength;
            offprice = data.offprice;
            valueoff = data.valueoff;
            last_login = data.lastlogin;
        }
        
        collect.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
        colpanel.gameObject.SetActive(false);
        //   if(PlayerPrefs.HasKey("Last_login"))
        //    {

        if (last_login != "")
        {
            collect.gameObject.SetActive(true);
            panel.gameObject.SetActive(false);
            DateTime lastlogin = DateTime.Parse(last_login);

            TimeSpan ts = DateTime.Now - lastlogin;
            totalpaise += (int)((ts.Days * 86400 + ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds) * valueoff);
            Savegame.sg(h);
            money.text = "Money generated by offline earnings\n" + ((int)((ts.Days * 86400 + ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds) * valueoff)).ToString() + "$";

        }

        print(DateTime.Now);

        //  }

    }
  
    public void collectmoney()
    {

        collect.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
        colpanel.gameObject.SetActive(false);
    }
    public void load()
    {
        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            PlayerData data = Savegame.lg();
            totalpaise = data.paise;
            lenght = data.length;
            strength = data.strength;
            valuestrength = data.valuestrength;
            valuelength = data.valuelength;
            valueoff = data.valueoff;
            offprice = data.offprice;
        }
    }

    void Update()
    {

        if (canMove && Input.GetMouseButton(0))
        {
            Vector3 vector = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position.x = vector.x;
            transform.position = position;
        }

        mainCamera.backgroundColor = Color.Lerp(c1, c2,(mainCamera.transform.position.y)/-480);
        

    }
    public void startfishing()
    {
     
        fishcount = 0;
        float time = (-lenght) * 0.1f;

        cameraTween = mainCamera.transform.DOMoveY(lenght,time*0.08f, false).OnUpdate(delegate
                {
                    if (mainCamera.transform.position.y <= -11)
                        transform.SetParent(mainCamera.transform);
                    
                }
        ).OnComplete(delegate
        {
            coll.enabled = true;
            cameraTween = mainCamera.transform.DOMoveY(0,time*3f, false).OnUpdate(delegate
            {

          
                if (mainCamera.transform.position.y >= -25f)
                    stopfishing();
            });
        }
        );

        canMove = true;
        coll.enabled = false;
        hookedFishes.Clear();
        PlayerData data = Savegame.lg();
        print("game saved");
        print(data.paise);
        print(data.length);
        print(data.strength);
        
    }
 
    void stopfishing()
    {
        print("fishing stopped");
        canMove = false;
        cameraTween.Kill(false);
        cameraTween = mainCamera.transform.DOMoveY(0,1.5f, false).OnUpdate(delegate
        {
            if (mainCamera.transform.position.y > -11)
                transform.SetParent(null);
        }).OnComplete(delegate
        {
            transform.position = Vector2.down * 7.6f;
            coll.enabled = true;
            num = 0;
            for(int i=0;i<hookedFishes.Count;i++)
            {
                hookedFishes[i].transform.SetParent(null);
          
                hookedFishes[i].resetFish();
    
                num += hookedFishes[i].Type.price;
            }
            print(num);
            totalpaise=totalpaise+num;
            Savegame.sg(h);
            colpanel.gameObject.SetActive(true);
            colmoney.text = num.ToString() + "$";
        });

        
    }
    public void OnTriggerEnter2D(Collider2D target)
    {
        
        if(target.tag=="Fish" && fishcount!=strength)
        {
            fishcollect.Play();
            print("Collided");
            fishcount++;
            fish_mover component = target.GetComponent<fish_mover>();
            component.hooked();
            target.transform.rotation = Quaternion.Euler(0, 0, 85);
            hookedFishes.Add(component);
            target.transform.SetParent(transform);

            target.transform.DOShakeRotation(7, Vector3.forward * 45, 15, 45, false).SetLoops(1, LoopType.Yoyo).OnComplete(delegate
            {
                target.transform.rotation = Quaternion.identity;
            });
        }
        if (fishcount == strength)
            stopfishing();
    }
    private void OnApplicationQuit()
    {
        // PlayerPrefs.SetString("Last_login", DateTime.Now.ToString());

        last_login = DateTime.Now.ToString();
        Savegame.sg(h);

    }
}
