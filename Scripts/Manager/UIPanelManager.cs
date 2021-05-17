using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject defaultPanel;

    // 初始化变量
    private bool isPause;

    // 初始化
    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
        //defaultPanel.SetActive(true);
        //Pause();

    }

    // 切换界面
    public void switchPanel(GameObject panel1, GameObject panel2)
    {
        OpenPanel(panel1);
        OffPanel(panel2);
    }

    // 打开面板
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Pause();
    }

    // 关闭面板
    public void OffPanel(GameObject panel)
    {
        panel.SetActive(false);
        Resume();
    }

    // 打开关闭界面
    public void SwitchlPanelOnOrOff(GameObject panel)
    {
        if (panel.activeSelf)
        {
            OpenPanel(panel);
        }
        else if (!panel.activeSelf)
        {
            OffPanel(panel);
        }
    }

    // 隐藏所有页面
    public void EscapePanel(GameObject canvas)
    {
        foreach(Transform child in canvas.transform)
        {
            OffPanel(child.gameObject);
        }
    }


    //界面暂停控制
    public bool IsPause()
    {
        return isPause;
    }
    // 继续游戏
    public void Resume()
    {
        //inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//real time is 1.0f
        isPause = false;
    }
    // 暂停游戏
    public void Pause()
    {
        //inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;//Stop the time
        isPause = true;
    }

    // UI启动、结束相关方法
    public void StartUIPanel(GameObject obj)
    {
        Debug.Log("UIPanel" + obj.name + "成功加载");
    }

    public void EndUIPanel(GameObject obj)
    {
        Debug.Log("UIPanel" + obj.name + "成功删除");
    }

    public void RuntimeAction(GameObject obj)
    {
        // 运行时的处理
    }


}
