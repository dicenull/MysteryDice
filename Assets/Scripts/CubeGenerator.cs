using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;

    [SerializeField] Transform controller;

    public void OnGenerate(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        var localPos = controller.localPosition;
        var rot = controller.rotation;
        var pos = controller.position;

        // さいころの中でしか発射できない
        var maxDistance = new List<float> { Math.Abs(localPos.x), Math.Abs(localPos.y), Math.Abs(localPos.z) }.Max();
        Debug.Log(maxDistance);
        if (maxDistance > 2) return;

        var bulletObj = Instantiate(bullet, pos, rot);
        bulletObj.GetComponent<Rigidbody>().AddForce((controller.forward) * speed, ForceMode.VelocityChange);

        Destroy(bulletObj, 5f);
    }

}
