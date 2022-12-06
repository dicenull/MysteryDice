using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using Unity.XR.PXR;
using UnityEngine;
using System.Linq;

public class HeadRayController : MonoBehaviour
{
    const int thredhold = 3;
    float countTime = 0;

    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activeMaterial;

    GameManager manager;

    private void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        var resolved = manager.mysteryOneResolved.Value;

        this.UpdateAsObservable().Where(_ => !resolved).Subscribe(_ =>
        {
            feedBack();
            checkRayTrack();
        });

        manager.mysteryOneResolved.Subscribe(resolved =>
        {
            GetComponent<Renderer>().material = resolved ? activeMaterial : inactiveMaterial;
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
            Debug.Log($"Count {countTime}");
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
            manager.mysteryOneResolved.Value = true;
        }
    }
}
