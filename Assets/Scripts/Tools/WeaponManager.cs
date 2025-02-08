using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //单例实例
    private static WeaponManager _instance;

    //暂时用武器编号代替武器实例缓存
    private int Weapon_code;

    public GameObject weapon_for_test;//测试武器的接口

    public WeaponConfig weaponConfig;//测试武器的配置文件

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
        Weapon_code = 0;
        if(Weapon_code < 0)
        {
            Debug.Log("Weapon code illegal!Please find a legal code");
        }
        ///测试代码
        weapon_for_test.GetComponent<Gun>().Initialize(weaponConfig);

        ///测试代码
    }

    //射击函数
    public void Shoot()
    {
        Debug.Log("开火！");
        weapon_for_test.GetComponent<Gun>().Shoot();
    }

    public void Reload()
    {
        weapon_for_test.GetComponent<Gun>().Reload();
    }

    public void ChangeSafty()
    {
        weapon_for_test.GetComponent<Gun>().ChangeSafty();
    }



}
