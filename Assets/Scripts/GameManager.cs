using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Transform player;
    public float y;
    public bool dropping = false;
    public Move_maya Player;
    public Inventory Inventory;
    public List<GameObject> WeaponSkin;
    public List<SpriteRenderer> WeaponIcon;
    public bool Dropping;

    [Header("Save stuff")]
    public string savePath = "/playerInfo.dat";
    PlayerData playerData;

    // Use this for initialization
    void Awake()
    {
        y = 9.5f;
        if (gm != null && gm != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        gm = this;
        if (!Player)
            Player = GameObject.Find("Maya").GetComponent<Move_maya>();
        if (!Inventory)
            Inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + new Vector3(0, y, 10);
    }

    private void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.persistentDataPath + savePath, FileMode.OpenOrCreate);

        PlayerData playerData = new PlayerData(Player);
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
        Debug.Log("infos sauvegardées");
    }

    public bool LoadPlayerData()
    {
        bool result = false;
        if (!File.Exists(Application.persistentDataPath + savePath)) {
            Debug.Log("no file");
            return false;
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.persistentDataPath + savePath, FileMode.Open);

        playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
        if (playerData != null)  {
            Debug.Log("infos trouvées");
            Player.AGI = playerData.AGI;
            Player.STR = playerData.STR;
            Player.level = playerData.level;
            Player.CON = playerData.CON;
            Player.ARMOR = playerData.ARMOR;
            Player.xpForNext = playerData.xpForNext;
            Player.stats_point = playerData.stats_point;
            result = true;
        }
        fileStream.Close();
        return result;
    }
}

[System.Serializable]
public class PlayerData
{
    public int AGI;
    public int STR;
    public int level;
    public long Experience;
    public int CON;
    public int ARMOR;
    public long xpForNext;
    public int stats_point;

    public PlayerData(Move_maya maya)
    {
        AGI = maya.AGI;
        STR = maya.STR;
        level = maya.level;
        Experience = maya.xp;
        CON = maya.CON;
        ARMOR = maya.ARMOR;
        xpForNext = maya.xpForNext;
        stats_point = maya.stats_point;
    }
};