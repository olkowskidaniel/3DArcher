using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    bool hasWeapon;
    public GameObject bowPrefab;
    public Transform bowPlaceHolder;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.childCount > 0)
        {
            hasWeapon = true;
        } else
        {
            hasWeapon = false;
        }
    }

    public bool GetHasWeapon()
    {
        return hasWeapon;
    }

    public void AddBow()
    {
        if(transform.childCount == 0)
            Instantiate(bowPrefab, bowPlaceHolder);
    }

    public void RemoveBow()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
