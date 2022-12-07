using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MysteryTwoSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;

    private void Start()
    {
        var manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        Observable.Interval(TimeSpan.FromSeconds(3)).Subscribe(_ =>
        {
            if (manager.mysteryTwoResolved.Value) return;

            Generate();
        });
    }

    public void Generate()
    {
        var bulletObj = Instantiate(bullet, transform.position, transform.rotation);
        bulletObj.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 1) * speed, ForceMode.VelocityChange);

        Destroy(bulletObj, 6f);
    }

}
