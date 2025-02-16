using System.Collections;
using UnityEditor.ShortcutManagement;
using UnityEngine;

abstract public class Gun : MonoBehaviour , IWeapon
{
    
    //保险装置的列举
    public enum Safty
    {
        SAFE,//保险关
        SEMI,//半自动
        AUTO,//全自动
    }

    [Header("Gun Info")]
    protected WeaponConfig weaponConfig;//枪械配置
    protected GameObject prefab;//枪械预制体

    protected int current_ammo;//当前弹药

    protected bool isReloading;//换弹状态

    protected bool isShooting;//正在开火

    protected bool isTriggerDown;

    protected Safty semi_mode;//单发/连发射击模式

    public void Initialize(WeaponConfig weaponConfig)
    {
        this.weaponConfig = weaponConfig;//加载枪械配置
        current_ammo = weaponConfig.Volume;//填弹
        isReloading = false;
        semi_mode = Safty.SAFE;//设置保险为关
        isTriggerDown = true;
        isShooting = false;
    }
    public virtual void Shoot()
    {
        //todo:在继承脚本中覆写开火方式
        Debug.Log("Shoot!");
    }

    public void Reload()
    {
        current_ammo = 0;
        StartCoroutine(TimerOfReload());
        current_ammo = weaponConfig.Volume;
    }

    public void ChangeSafty()
    {
        if(semi_mode == Safty.SAFE || semi_mode == Safty.SEMI)  semi_mode++;
        else semi_mode = Safty.SAFE;
        Debug.Log(semi_mode);
    }


    protected IEnumerator TimerOfReload()
    {
        isReloading = true;
        yield return new WaitForSeconds(weaponConfig.reload_time);
        isReloading = false;
    }
    
    protected IEnumerator TimerOfShootFre()
    {
        isShooting = true;
        yield return new WaitForSeconds(weaponConfig.shoot_frequncy);
        isShooting = false;
    }

    
}
