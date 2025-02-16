using System.Collections;
using UnityEngine;
using YooAsset;

public class WeaponFactory : MonoBehaviour
{

    //初始化YooAsset
    private IEnumerator Start()
    {
        var package = YooAssets.GetPackage("GunPackage-TestOnly");

        //初始化资源包为离线模式
        var initParamaters = new OfflinePlayModeParameters();
        yield return package.InitializeAsync(initParamaters);

        //设置该资源包为默认的资源包，可以使用YooAssets相关加载接口加载该资源包内容。
        YooAssets.SetDefaultPackage(package);
    }

    private IEnumerator DestroyPackage()
{
    // 先销毁资源包
    var package = YooAssets.GetPackage("DefaultPackage");
    DestroyOperation operation = package.DestroyAsync();
    yield return operation;
    
    // 然后移除资源包
    if (YooAssets.RemovePackage(package))
    {
        Debug.Log("移除成功！");
    }
}

    public void LoadWeapon()
    {
        AssetHandle handle = YooAssets.LoadAllAssetsSync<GameObject>("Weapon_")
    }

}



