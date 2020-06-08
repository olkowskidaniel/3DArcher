using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowPlaceHolder;
    public FloatingJoystick floatingJoystick;

    Animator playerAnimator;
    float shootPower;
    bool isArrowLoaded;
    
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        playerAnimator.SetBool("isLoading", floatingJoystick.GetIsClicked());
        if(floatingJoystick.GetIsClicked())
        {
            shootPower = floatingJoystick.Vertical * -1;
            playerAnimator.SetFloat("shootPower", shootPower);
        }
        if(!floatingJoystick.GetIsClicked() && arrowPlaceHolder.childCount > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
            isArrowLoaded = false;
            GameObject.FindGameObjectWithTag("StringHandle").transform.SetParent(GameObject.FindGameObjectWithTag("BowFrontBone").transform);
            GameObject.FindGameObjectWithTag("StringHandle").transform.position = GameObject.FindGameObjectWithTag("StringDefaultPosition").transform.position;
        }
    }

    public void InstantiateArrow()
    {
        Instantiate(arrowPrefab, arrowPlaceHolder);
    }

    public void FinishLoading()
    {
        isArrowLoaded = true;
        GameObject.FindGameObjectWithTag("StringHandle").transform.SetParent(arrowPlaceHolder);
        GameObject.FindGameObjectWithTag("StringHandle").transform.position = arrowPlaceHolder.transform.position;
    }
}
