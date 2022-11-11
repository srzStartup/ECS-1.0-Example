using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    #region Singleton
    private static EconomyManager _instance;
    public static EconomyManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {

            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            TotalMoney = 0;

        }
    }
    #endregion
    
    #region PrivateMethods
    private ref Incremental getIncremental(string incrementalName)
    {
        int i;
        for (i = 0; i < incrementals.Length; i++)
        {
            if (incrementals[i].name == incrementalName)
            {
                break;
            }
        }
        if (i == incrementals.Length)
        {
            throw new Exception("Not found '" + incrementalName + "' incremental in list incrementals. Please check that list.");
        }
        return ref incrementals[i];
    }
    #endregion

    public float TotalMoney;
    
   public void  MoneyAddAndSetText(float AddAmount, ref TextMeshProUGUI moneyText,bool dollar)
    {
        TotalMoney += AddAmount;
        moneyText.text = Money2Text(TotalMoney, dollar);
    }
    public string Money2Text(float value, bool dollar)
    {
        string text = "";
        if (value < 1000)
        {
            text = value + "";
            text = dollar ? text + "$" : text;
        }
        else if (value < 1000000)
        {
            value = value / 1000f;
            value = value * 100f;
            value = Mathf.Round(value);
            value = value / 100f;
            text = value + "k";
            text = dollar ? text + "$" : text;
        }
        else if (value < 1000000000)
        {
            value = value / 1000000f;
            value = value * 100f;
            value = Mathf.Round(value);
            value = value / 100f;
            text = value + "m";
            text = dollar ? text + "$" : text;
        }
        else
        {
            value = value / 1000000000f;
            value = value * 100f;
            value = Mathf.Round(value);
            value = value / 100f;
            text = value + "b";
            text = dollar ? text + "$" : text;
        }

        return text;
    }
    public Incremental[] incrementals;
    public void LevelIncrease(string incrementalName)
    {
        ref Incremental incremental = ref getIncremental(incrementalName);
        incremental.level++;
    }
    public float GetIncrementalPrice(string incrementalName)
    {
        Incremental incremental = getIncremental(incrementalName);
        return Mathf.Ceil(incremental.increaseGraphic.Evaluate(incremental.level));
    }
    public void SetIncrementalTexts(string incrementalName,ref TextMeshProUGUI valueText,ref TextMeshProUGUI levelText)
    {
        
        Incremental incremental = getIncremental(incrementalName);
        valueText.text = Mathf.Ceil(incremental.increaseGraphic.Evaluate(incremental.level)).ToString();
        levelText.text="LVL "+incremental.level.ToString();
    }
    
}
[Serializable]
public class Incremental
{
    public AnimationCurve increaseGraphic;
    public string name;
    public int level;
}
