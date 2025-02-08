using UnityEngine;

//武器配置基类
[CreateAssetMenu(fileName = "NewWeaponConfig",menuName = "Weapons/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    public float damage;//武器伤害
    public float shoot_frequncy;//武器射击间隔

    public float dominant_range;//武器优势射程

    public float precision;//武器弹道最大偏移角度

    public float weith;//武器重量

    public int Volume;//武器弹容

    public float reload_time;//装弹时间

    public int weapon_type;//武器类型

}

//保险装置的列举
public enum Safty
{
    SAFE,//保险关
    SEMI,//半自动
    AUTO,//全自动
}

