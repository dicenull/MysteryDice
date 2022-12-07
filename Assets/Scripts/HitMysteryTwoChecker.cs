using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class HitMysteryTwoChecker : MonoBehaviour
{
    [SerializeField] Material activeMaterial;

    GameManager manager;

    private void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<Renderer>().material = activeMaterial;
            manager.mysteryTwoResolved.Value = true;
        }
    }

}
