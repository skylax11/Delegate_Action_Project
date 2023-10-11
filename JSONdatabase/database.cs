using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class database : MonoBehaviour
{
    private bool _isSaved;
    public List<PlayerDatas> PlayerDataList;

    public static database instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }
    private void Start()
    {
        Load();
        MenuManager.instance.DisplayLeaderboard();
    }
    public void Save(PlayerDatas data)
    {
        for (int i = 0; i < 5; i++)
        {
            if (!File.Exists(Application.dataPath + "/databaseJSONfile" + i + ".json"))
            {
                _isSaved = true;
                data.id = i;
                string jsonWrite = JsonUtility.ToJson(data);
                File.WriteAllText(Application.dataPath + "/databaseJSONfile" + i + ".json", jsonWrite);
                PlayerDataList.Add(data);
                break;
            }
        }
        if (!_isSaved)
        {
            PlayerDataList = PlayerDataList.OrderBy(x => x.id).ToList();

            for (int i = 0; i < 5; i++)
            {
                string jsonRead = File.ReadAllText(Application.dataPath + "/databaseJSONfile" + PlayerDataList[i].id + ".json");
                PlayerDatas _data = JsonUtility.FromJson<PlayerDatas>(jsonRead);
                if (data.score > _data.score)
                {
                    string jsonWrite = JsonUtility.ToJson(data);
                    File.WriteAllText(Application.dataPath + "/databaseJSONfile" + PlayerDataList[i].id + ".json", jsonWrite);
                }
            }
        }
    }
    public void Load()
    {
        PlayerDataList = new List<PlayerDatas>();

        for (int i = 0; i < 5; i++)
        {
            if (!File.Exists(Application.dataPath + "/databaseJSONfile" + i + ".json"))
            {
                return;
            }
            else
            {
                string jsonRead = File.ReadAllText(Application.dataPath + "/databaseJSONfile" + i + ".json");
                PlayerDatas data = JsonUtility.FromJson<PlayerDatas>(jsonRead);
                PlayerDataList.Add(data);
            }
        }
        PlayerDataList = PlayerDataList.OrderBy(x=>x.score).ToList();
    }
}
