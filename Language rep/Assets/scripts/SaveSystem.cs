using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SaveTranslateList()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/WordTranslate.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        TranslateData data = new TranslateData();

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static TranslateData LoadWordLists()
    {
        string path = Application.persistentDataPath +"/WordTranslate.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TranslateData data = formatter.Deserialize(stream) as TranslateData;
            stream.Close();

            return data;
        }else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
    public static void SaveNominativList()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/WordNominativ.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        NominativData data = new NominativData();

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static NominativData LoadNominativLists()
    {
        string path = Application.persistentDataPath + "/WordNominativ.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            NominativData data = formatter.Deserialize(stream) as NominativData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
