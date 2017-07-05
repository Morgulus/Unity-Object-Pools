using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    [System.Serializable]
    public struct FloatRange
    {
        public float min, max;
        public float RandoomInRange
        {
            get
            {
                return Random.Range(min, max);
            }
        }
    }

    public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
    public Stuff[] stuffPrefabs;
    public float velocity;
    public Material stuffMaterial;
    float timeSinceLastSpawns,
          currentSpawnDelay;

    private void FixedUpdate()
    {
        timeSinceLastSpawns += Time.deltaTime;
        if (timeSinceLastSpawns >= currentSpawnDelay)
        {
            timeSinceLastSpawns -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandoomInRange;
            SpawnStuff();
        }
    }

    void SpawnStuff()
    {
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
        Stuff spawn = prefab.GetPooledInstance<Stuff>();
        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = scale.RandoomInRange * Vector3.one;
        spawn.transform.localRotation = Random.rotation;
        spawn.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandoomInRange;
        spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandoomInRange;
        spawn.SetMaterial(stuffMaterial);
    }
}
