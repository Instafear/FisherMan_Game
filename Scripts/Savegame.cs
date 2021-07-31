using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class Savegame
{
    
  public static void sg(hook h)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.txt";
        PlayerData data = new PlayerData(h);
        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData lg()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.txt";
           
       FileStream stream = new FileStream(path, FileMode.Open);
      
        PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
    }
}
