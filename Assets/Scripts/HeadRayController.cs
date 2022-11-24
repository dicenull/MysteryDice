using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

public class HeadRayController : MonoBehaviour
{
    const int thredhold = 3;
    float countTime = 0;

    bool flag = false;

    void Update()　
    {
        if (flag) return;

        RaycastHit hitInfo;
        var ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("MysteryOne"))
            {
                
                countTime += Time.deltaTime;
            }
            else
            {
                countTime = 0;
            }
        } else
        {
            countTime = 0;
        }

        // 一秒ごとにフィードバックする
        var prev = (countTime - Time.deltaTime) * 1000 % 1000;
        var now = countTime * 1000 % 1000;
		if (prev > now)
        {
			PXR_Input.SetControllerVibrationEvent(0, 500, 1f, 3);
			PXR_Input.SetControllerVibrationEvent(1, 500, 1f, 3);
		}

        if(countTime > thredhold)
        {
            flag = true;
        }
    }
}
