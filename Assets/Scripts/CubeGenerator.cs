using System.Collections;
using System.Collections.Generic;
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

        var bulletObj = Instantiate(bullet, pos, rot);
        bulletObj.GetComponent<Rigidbody>().AddForce((controller.forward) * speed, ForceMode.VelocityChange);

        Destroy(bulletObj, 5f);
    }

}
