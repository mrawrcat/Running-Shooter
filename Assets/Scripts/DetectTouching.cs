    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTouching : MonoBehaviour
{

    public Vector2 booga;
    public LayerMask layer;
    public float tilemap_length;
    [SerializeField]
    private bool detectingTilemap;
    [SerializeField]
    private string tilename;
    private TilemapPool tilemapPool;
    private Rigidbody2D rb2d;
    

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tilemapPool = FindObjectOfType<TilemapPool>();
        
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + booga.x,transform.position.y + booga.y), Vector2.left, Mathf.Infinity, layer);
        detectingTilemap = hit;
        if(hit.collider != null)
        {
            tilename = hit.collider.name;
            if(hit.collider.tag == "Tilemap")
            {
                transform.position = new Vector2(hit.collider.transform.position.x + tilemap_length, transform.position.y);
            }
            else if(hit.collider.tag != "Tilemap")
            {
                Debug.Log("hitting object not tilemap");
                //transform.position = transform.position;
                
            }
        }
        else
        {
            rb2d.velocity = Vector2.left * GameManager.manager.tileSpeed;
        }

        if (transform.position.x <= -23)
        {
            tilemapPool.SpawnTilemap(tilemapPool.gameObject.transform);
            gameObject.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(new Vector2(transform.position.x + booga.x, transform.position.y + booga.y), Vector2.left);
        
    }
}
