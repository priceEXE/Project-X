using UnityEngine;
using System.Collections;
using YooAsset;

public class WeaponManager : MonoBehaviour
{
    //单例实例
    private static WeaponManager _instance;

    //武器实例缓存
    [SerializeField]
    private Gun gun;

    public static WeaponManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("WeaponManager instance not found! Please ensure one exists in the scene.");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        // 单例模式初始化
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        Initialize();

        
    }

    //暂时保留初始化函数，根据后续初始化属性决定添加项
    private void Initialize()
    {
        gun = null;
        if(gun == null) Debug.Log("Weapon null!");
    }

    //射击函数
    public void Shoot()
    {
        gun.Shoot();
    }

    public void Reload()
    {
        gun.Reload();
    }

    public void ChangeSafty()
    {
        gun.ChangeSafty();
    }


}

