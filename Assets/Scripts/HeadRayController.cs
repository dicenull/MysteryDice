using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using Unity.XR.PXR;
using UnityEngine;

public class HeadRayController : MonoBehaviour
{
    const int thredhold = 3;
    float countTime = 0;

    BoolReactiveProperty flag = new BoolReactiveProperty();

    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activeMaterial;

    private void Start()
    {
        this.UpdateAsObservable().Where(_ => !flag.Value).Subscribe(_ =>
        {
            feedBack();
            checkRayTrack();
        });

        flag.ObserveEveryValueChanged(x => x)
            .Subscribe(_ =>
        {
            GetComponent<Renderer>().material = flag.Value ? activeMaterial : inactiveMaterial;
        });
    }

    void feedBack()
    {
        var prev = countTime % 1;
        var now = (countTime + Time.deltaTime) % 1;
        if (prev > now)
        {
            PXR_Input.SetControllerVibrationEvent(0, 500, 1f, 3);
            PXR_Input.SetControllerVibrationEvent(1, 500, 1f, 3);
        }
    }

    void checkRayTrack()
    {
        var camera = Camera.main;
        RaycastHit hitInfo;
        var ray = new Ray(camera.transform.position, camera.transform.forward);
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
        }
        else
        {
            countTime = 0;
        }

        if (countTime > thredhold)
        {
            flag.Value = true;
        }
    }
}
