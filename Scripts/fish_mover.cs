using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class fish_mover : MonoBehaviour
{
    private fish_mover.Fish type;
    private CircleCollider2D coll;
    private float leftscreen;
    private SpriteRenderer rend;
    public Tweener tweener;
   

    public fish_mover.Fish Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
            coll.radius = type.collider_radius;
            rend.sprite = type.sprite;
            transform.localScale = new Vector3(UnityEngine.Random.Range(0.16f,0.2f), UnityEngine.Random.Range(0.14f, 0.17f), 1);
        }
    }


    void Awake()
    {
        coll = GetComponent<CircleCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        leftscreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

   public void resetFish()
    {
        if (tweener != null)
            tweener.Kill(false);

        float num = UnityEngine.Random.Range(type.minlength, type.maxlength);
        coll.enabled = true;
        Vector3 position = transform.position;
        position.x = leftscreen;
        position.y = num;
        transform.position = position;
        transform.rotation = Quaternion.identity;
        transform.localRotation = Quaternion.identity;
        if(transform.localScale.x<0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -transform.localScale.x;
            transform.localScale=scale;
        }
        float y = UnityEngine.Random.Range(num - 1f, num + 1f);
        Vector2 v = new Vector2(-position.x, y);
        float delay = UnityEngine.Random.Range(0f, 6f);
      
        tweener = transform.DOMove(v, 3, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(delay).OnStepComplete(delegate
        {
            
            Vector3 localscale = transform.localScale;
                 localscale.x = -transform.localScale.x;
                 transform.localScale = localscale;
                 
             });
        
    }

     public void hooked()
    {
        coll.enabled = true;
        tweener.Kill(false);
    }


    [Serializable]
    public class Fish
    {
        public int price;
        public float collider_radius;
        public int count;
        public float minlength;
        public float maxlength;
        public Sprite sprite;
    }
}
