using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Design_pattern_test : MonoBehaviour
{
    public Facade facade;

    // Canvas
    public GameObject canvas;

    // GameObject
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public AudioClip ac1;

    //面板
    public GameObject defaultPanel;
    public GameObject startUIPanel;
    public GameObject inventoryPanel;

    // float 
    float go2_a = -375f;
    float go2_b = 275f;

    float go3_a = 380f;
    float go3_b = 275f;

    // GameObject
    public GameObject go_test_01;

    // 初始化
    private void Start()
    {
        //canvas = GameObject.FindGameObjectWithTag("Canvas");

        // 游戏开始时，创建开始面板
        GameStart();

    }

    // 更新
    private void Update()
    {
        // 打开、关闭背包
        if (Input.GetKeyDown(KeyCode.Z))
        {
            facade.SwitchlPanelOnOrOff(inventoryPanel, canvas);
        }

        // 打开、关闭属性面板
        if (Input.GetKeyDown(KeyCode.X))
        {
            facade.SwitchlPanelOnOrOff(defaultPanel, canvas);
        }

        // 退出所有面板
        if (Input.GetKeyDown(KeyCode.C))
        {
            facade.EscapePanel(canvas);
        }

        // 展示玩家信息
        if (Input.GetKeyDown(KeyCode.V))
        {
            facade.GetPlayerInfo(StringManager.PlayerCoins);
            facade.GetPlayerInfo(StringManager.PlayerLevel);
        }
        // 增加物品
        if (Input.GetKeyDown(KeyCode.M))
        {
            facade.AddItem();
        }
        // 删除物品
        if (Input.GetKeyDown(KeyCode.N))
        {
            facade.RemoveItem();
        }
        #region 
        // 开始
        // 创建UIPanel、UI、加载音乐，动画
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    // 加载UI面板
        //    go1 = facade.GetGameObjectResource(FactoryType.UIPanelFactory, 
        //                                       StringManager.DefaultPanel);
        //    FixPosition(go1, canvas, 0, 0, 0);
        //    // 运行
        //    facade.StartUIPanel(go1);

        //    // 加载UI组件
        //    go_test_01 = GameObject.Find("DefaultPanel(Clone)");
        //    go2 = facade.GetGameObjectResource(FactoryType.UIFactory, "go2");
        //    FixPosition(go2, go_test_01, go2_a, go2_b, 0);
        //    go3 = facade.GetGameObjectResource(FactoryType.UIFactory, "go3");
        //    FixPosition(go3, go_test_01, go3_a, go3_b, 0);

        //    //加载资源
        //    ac1 = facade.GetAudioSource(StringManager.MainButton);

        //    //运行
        //    facade.StartAudioSource(ac1);
        //}


        //// 获取玩家信息
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    facade.GetPlayerInfo(StringManager.PlayerCoins);
        //    facade.GetPlayerInfo(StringManager.PlayerLevel);
        //}

        //// 结束显示
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    // 结束相关处理
        //    facade.EndAudioSource(ac1);
        //    facade.EndUIPanel(go1);

        //    // 回收物体
        //    facade.PushGameObjectToFactory(FactoryType.UIPanelFactory, 
        //                                   StringManager.GameLoadPanel, go1);
        //    facade.PushGameObjectToFactory(FactoryType.UIFactory, "go2", go2);
        //    facade.PushGameObjectToFactory(FactoryType.UIFactory, "go3", go3);


        //    // 释放资源
        //    facade.PushAudioSource(StringManager.MainButton, ac1);

        //}
        #endregion

    }

    // 设置父物体和相对位置
    private void FixPosition(GameObject obj, GameObject parent, float a, float b, float c)
    {
        obj.transform.SetParent(parent.transform);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.transform.localPosition = new Vector3(a, b, c);
    }

    // 开始游戏
    private void GameStart()
    {
        // 暂停游戏
        facade.Pause();

        // 初始化所有面板
        defaultPanel = facade.GetGameObjectResource(FactoryType.UIPanelFactory, StringManager.DefaultPanel);
        startUIPanel = facade.GetGameObjectResource(FactoryType.UIPanelFactory, StringManager.StartUIPanel);
        FixPosition(startUIPanel, canvas, 0, 0, 0);
        FixPosition(defaultPanel, canvas, 0, 0, 0);

        // 加载UI组件
        go_test_01 = GameObject.Find(StringManager.DefaultPanel_Clone);
        go2 = facade.GetGameObjectResource(FactoryType.UIFactory, "go2");
        FixPosition(go2, go_test_01, go2_a, go2_b, 0);
        go3 = facade.GetGameObjectResource(FactoryType.UIFactory, "go3");
        FixPosition(go3, go_test_01, go3_a, go3_b, 0);

        // 隐藏面板
        defaultPanel.SetActive(false);

    }


    

}
