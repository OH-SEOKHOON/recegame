using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaslogic : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.down * 2f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        GameManager.Instance.energy += 30;
        Destroy(this.gameObject);
    }
}
