using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : Gun
{
    public override void Shoot()
    {
        Debug.Log("开火！");
        switch (semi_mode)
        {   
            case Safty.SAFE:
                break;
            case Safty.SEMI:
                if(isTriggerDown)
                {
                    isTriggerDown = false;
                    Debug.Log("半自动射击");
                }
                break;
            case Safty.AUTO:
                if(!isShooting)
                {
                    Debug.Log("全自动射击");
                    StartCoroutine(TimerOfShootFre());
                }
                break;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0) && !isTriggerDown)
        {
            isTriggerDown = true;
        }
    }
}
