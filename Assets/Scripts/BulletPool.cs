using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public Transform Grid;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [Header("Spawner tags")]
    public string[] tags;
    private void Start()
    {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.SetParent(Grid.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);

            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnBullet(string tag, Transform pos, float speed)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with Tag " + tag + " doesnt exist");
            return null;
        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = pos.position;

        Rigidbody2D proj_rb = objToSpawn.GetComponent<Rigidbody2D>();
        proj_rb.velocity = Vector2.zero;
        //proj_rb.AddForce(new Vector2(Random.Range(direction.x ,direction.y), force), ForceMode2D.Impulse);
        objToSpawn.GetComponent<Rigidbody2D>().AddForce(pos.right * speed, ForceMode2D.Impulse);
        poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

    public void SpawnBullet(Transform pos, float speed)
    {
        SpawnBullet(tags[0], pos, speed);
    }
}
