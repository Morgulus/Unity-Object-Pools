using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject {

    public Rigidbody Body { get; private set; }
    MeshRenderer[] meshRenderers;

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kill Zone")
            ReturnToPool();
    }
    public void SetMaterial(Material m)
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = m;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        ReturnToPool();
    }
}
