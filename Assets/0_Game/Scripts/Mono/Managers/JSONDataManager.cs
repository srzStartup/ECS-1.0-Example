using System.Collections;
using System.Collections.Generic;

using System.IO;

using UnityEngine;

[DefaultExecutionOrder(-9)]
public class JSONDataManager : Singleton<JSONDataManager>
{
    public string dataFilePath;
    public bool refresh = false;
    private string _path;
    private DataModel _data;

    public DataModel data => _data;

    protected override void Awake()
    {
        base.Awake();

        PlayerPrefs.SetInt("EntryAnimDontPlay", 0);

        _path = Path.Combine(Application.persistentDataPath, dataFilePath + ".json");
        _data = new DataModel();

        if (refresh)
        {
            DeleteFile();
        }

        if (GetData() == null)
        {
            _data.realLevel = 1;
            _data.inGameLevel = 1;
            _data.totalMoney = 0;
            _data.totalGem = 0;
            _data.onboardingDone = false;

            //_data.incrementalDatas = new List<IncrementalData>()
            //{
            //    new IncrementalData(IncrementalType.HoleCount, 1),
            //    new IncrementalData(IncrementalType.HoleSize, 1),
            //    new IncrementalData(IncrementalType.StickLength, 1)
            //};
        }

        SaveData();
    }

    public DataModel GetData()
    {
        if (!File.Exists(_path))
            return null;

        string json = File.ReadAllText(_path);
        _data = JsonUtility.FromJson<DataModel>(json);

        return _data;
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_data, true);
        File.WriteAllText(_path, json);
    }

    public void DeleteFile()
    {
        if (File.Exists(_path))
        {
            File.Delete(_path);
        }
    }
}

[System.Serializable]
public class DataModel
{
    public int realLevel;
    public int inGameLevel;
    public int totalMoney;
    public int totalGem;
    public bool onboardingDone;
    //public List<IncrementalData> incrementalDatas;
}

//[System.Serializable]
//public class IncrementalData
//{
//    public IncrementalType type;
//    public int level;

//    public IncrementalData(IncrementalType type, int level)
//    {
//        this.type = type;
//        this.level = level;
//    }
//}
