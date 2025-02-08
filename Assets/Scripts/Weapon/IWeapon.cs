using System.Numerics;

public interface IWeapon
{
    void Initialize(WeaponConfig config);
    void Shoot();
    void Reload();

    void ChangeSafty();
    
}
