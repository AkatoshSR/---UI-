using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 策略，观察者，装饰者，三个工厂模式，多线程单件模式，命令模式，适配器，迭代器
public class Facade : MonoBehaviour
{
    // 玩家数据
    private PlayerInfo playerInfo;
    [SerializeField] private GameObject canv;

    // 管理者

    [SerializeField] private UIPanelManager uiPanelManager;
    [SerializeField] private InventoryManager inventoryManager;
    private GameManager mGameManager;
    private AudioSourceManager audioSourceManager;
    private PlayerManager playerManger;
    private AnimationManager animationManager;
    
    // 显示背包物品
    [SerializeField] private Item temp_addItem;
    [SerializeField] private Item temp_removeItem;

    // 获取管理者
    public void Start()
    {
        mGameManager = GameManager.Instance;
        audioSourceManager = GameManager.Instance.audioSourceManager;
        playerManger = GameManager.Instance.playerManager;
        animationManager = GameManager.Instance.animationManager;
    }

    // 暂停游戏判断
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiPanelManager.IsPause())
            {
                uiPanelManager.Resume();//如果游戏暂停，则继续游戏
                uiPanelManager.EscapePanel(canv);
            }
            else
            {
                uiPanelManager.Pause();//如果游戏进行中，则暂停游戏
            }
        }
        
    }

    // 暂停游戏
    public void Pause()
    {
        uiPanelManager.Pause();
    }

    // 继续游戏
    public void Resume()
    {
        uiPanelManager.Resume();
    }

    // UI面板管理者相关方法

    // 打开、切换面板
    public void SwitchlPanelOnOrOff(GameObject panel, GameObject canvas)
    {
        if (panel.activeSelf)
        {
            uiPanelManager.OffPanel(panel);
        }
        else if (!panel.activeSelf)
        {
            uiPanelManager.EscapePanel(canvas);
            uiPanelManager.OpenPanel(panel);
        }
    }

    // 关闭某个面板
    public void OffPanel(GameObject panel)
    {
        uiPanelManager.OffPanel(panel);
    }

    // 退出所有面板
    public void EscapePanel(GameObject canvas)
    {
        uiPanelManager.EscapePanel(canvas);
    }

    // 增加物品
    public void AddItem()
    {
        inventoryManager.AddItem();

    }

    // 删除物品
    public void RemoveItem()
    {
        inventoryManager.RemoveItem();
    }

    // 开始面板
    public void StartUIPanel(GameObject obj)
    {
        uiPanelManager.StartUIPanel(obj);
        uiPanelManager.RuntimeAction(obj);
    }

    //结束面板
    public void EndUIPanel(GameObject obj)
    {
        uiPanelManager.EndUIPanel(obj);
    }

    // 动画管理者相关方法
    public void StartAnimation(RuntimeAnimatorController rac)
    {
        animationManager.StartAnimation(rac);
        animationManager.RuntimeAction(rac);
        GetSprite("EXP_PLAYER");
    }

    public void EndAnimation(RuntimeAnimatorController rac)
    {
        animationManager.EndAniamtion(rac);
    }

    // 音频管理者相关方法
    public void StartAudioSource(AudioClip ac)
    {
        audioSourceManager.StartAudioSource(ac);
        audioSourceManager.RuntimeAction(ac);
    }

    public void EndAudioSource(AudioClip ac)
    {
        audioSourceManager.EndAudioSource(ac);
    }

    // 获取玩家信息
    public int GetPlayerInfo(string flag)
    {
        this.playerInfo = mGameManager.GetPlayerInfo();
        
        
        

        if (StringManager.PlayerLevel.Equals(flag))
        {
            Debug.Log("玩家等级：" + this.playerInfo.GetLevel());
            return this.playerInfo.GetLevel();
            
        }
        if (StringManager.PlayerCoins.Equals(flag))
        {
            Debug.Log("玩家金币：" + this.playerInfo.GetCoins());
            return this.playerInfo.GetCoins();

        }
        return 0;
        
    }

    // 修改玩家信息
    public void SetPlayerInfo(string playerInfoType, int info)
    {
        mGameManager.SetPlayerInfo(playerInfoType, info);
    }

    //获取资源
    public Sprite GetSprite(string resourcePath)
    {
        return mGameManager.GetSprite(resourcePath);
    }

    public AudioClip GetAudioSource(string resourcePath)
    {
        return mGameManager.GetAudioClip(resourcePath);
    }

    public RuntimeAnimatorController GetRuntimeAnimatorController(string resourcePath)
    {
        return mGameManager.GetRunTimeAnimatorController(resourcePath);
    }

    //获取游戏物体
    public GameObject GetGameObjectResource(FactoryType factoryType, string resourcePath)
    {
        return mGameManager.GetGameObjectResource(factoryType, resourcePath);
    }
    //将游戏物体放回对象池
    public void PushGameObjectToFactory(FactoryType factoryType, string resourcePath, GameObject itemGo)
    {
        mGameManager.PushGameObjectToFactory(factoryType, resourcePath, itemGo);
    }

    // 移除音频资源
    public void PushAudioSource(string name, AudioClip ac)
    {
        mGameManager.PushAudioSource(name, ac);
    }

    // 移除动画资源
    public void PushRuntimeAnimatorController(string name, RuntimeAnimatorController rac)
    {
        mGameManager.PushRuntimeAnimatorController(name, rac);
    }

}
