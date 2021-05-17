using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    Facade facade;         // 外观
    [SerializeField]
    public GameObject go1; // 增加等级按钮
    public GameObject go2; // 增加金币按钮
    public GameObject canvas;


    private void Start()
    {
        facade = GameObject.FindGameObjectWithTag("Facade").GetComponent<Facade>();
        canvas = GameObject.Find("Canvas");
    }

    //StartUIPanel 开始游戏面板按钮
    public void StartButton()
    {
        facade.EscapePanel(canvas);
        facade.Resume();
    }

    //CharacterPanel 人物面板按钮
    // 增加等级
    public void AddLevel()
    {
        facade.SetPlayerInfo(StringManager.PlayerLevel, facade.GetPlayerInfo(StringManager.PlayerLevel) + 1);
        LevelView();
    }
    // 展示等级
    public void LevelView()
    {
        go1.GetComponent<Text>().text = facade.GetPlayerInfo(StringManager.PlayerLevel).ToString();
    }
    // 增加金币
    public void AddCoin()
    {
        facade.SetPlayerInfo(StringManager.PlayerCoins, facade.GetPlayerInfo(StringManager.PlayerCoins) + 1);
        CoinsView();
    }
    // 展示金币
    public void CoinsView()
    {
        go2.GetComponent<Text>().text = facade.GetPlayerInfo(StringManager.PlayerCoins).ToString();
    }
}
