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


        var pos = controller.position;
        var rot = controller.rotation;

        // さいころの中でしか発射できない
        var maxDistance = new List<float> { Math.Abs(pos.x), Math.Abs(pos.y), Math.Abs(pos.z) }.Max();
        if (maxDistance > 2) return;

        var bulletObj = Instantiate(bullet, pos, rot);
        bulletObj.GetComponent<Rigidbody>().AddForce((controller.forward) * speed, ForceMode.VelocityChange);

        Destroy(bulletObj, 5f);
    }

}
