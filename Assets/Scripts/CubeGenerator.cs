using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public void OnGenerate(InputAction.CallbackContext context)
    {
        var bulletObj = Instantiate(bullet, transform.position, transform.rotation);
        bulletObj.GetComponent<Rigidbody>().AddForce((transform.forward + transform.right) * 0.1f, ForceMode.VelocityChange);

        Destroy(bulletObj, 5f);
    }

}
