using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataGroup", menuName = "Scriptable Objects/WeaponDataGroup")]
public class WeaponDataGroup : ScriptableObject
{
    public wData[] wData;
}
[System.Serializable]
public class wData
{
    public string name;
    public int dmg;
    public int range;
    public DetailData detailData;
    public DamageSystem damageSystem;
}
[System.Serializable]
public class DetailData
{
    public int cost;
    public int upgradeLevel;
}
[System.Serializable]
public class DamageSystem
{
    public int minDamage;
    public int maxDamage;
    public int successPercent;
    public int criticalChance;
}