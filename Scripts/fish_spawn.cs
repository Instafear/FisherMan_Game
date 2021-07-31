using UnityEngine;
using System;
public class fish_spawn : MonoBehaviour
{
    private void Awake()
    {
      for(int i=0;i<type.Length;i++)
        {
            int num = 0;
            while(num<30)
            {
                fish_mover fish = UnityEngine.Object.Instantiate<fish_mover>(fm);
                fish.Type = type[i];
                fish.resetFish();
                fish.transform.localRotation = Quaternion.identity;
                num++;
            }
        }
    }
    [SerializeField]
    private fish_mover fm;

    [SerializeField]
    private fish_mover.Fish[] type;
}
