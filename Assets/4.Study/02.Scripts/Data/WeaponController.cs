using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weaponObjs;
    public WeaponData[] weaponDatas;
    public WeaponDataGroup wDataGroup;

    public string currentweaponName;
    public int currentWeaponDmg;
    public int currentWeaponRange;

    private void Start()
    {
        //foreach (var data in weaponDatas)
        //{
        //    Debug.Log($"{data.weaponName} / {data.attackDamage} / {data.attackRange}");
        //}
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapWeapon(2);
        }

    }
    void SwapWeapon(int index)
    {
        foreach(var weapon in weaponObjs)
            weapon.SetActive(false);

        weaponObjs[index].SetActive(true);

        currentweaponName = weaponDatas[index].weaponName;
        currentWeaponDmg = weaponDatas[index].attackDamage;
        currentWeaponRange = weaponDatas[index].attackRange;

        currentWeaponDmg = wDataGroup.wData[0].damageSystem.maxDamage;
    }
}
