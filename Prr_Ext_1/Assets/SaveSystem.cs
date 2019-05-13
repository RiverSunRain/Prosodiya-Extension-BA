using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem {

    public static void SavePlayer(CharacterCreator characterCreator) {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.bd";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(characterCreator);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer() {

        string path = Application.persistentDataPath + "/player.bd";
        if (File.Exists(path))
        {
            BinaryFormatter formattter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formattter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        }
        else {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}
