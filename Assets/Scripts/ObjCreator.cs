using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCreator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject coins;
    [SerializeField] private GameObject spike;
                     public int coinsCount;
    [SerializeField] private int spikesCount;
    [SerializeField] private Transform coinsParent;
    [SerializeField] private Transform spikeParent;

    [Header("Camera settings")]
    private float minX, maxX;
    private float minY, maxY;

    [SerializeField] private float offsetCreating = 0.3f;
    [SerializeField] private float sphereRadiusDetection;
    private void Start()
    {
        Camera cam = Camera.main;

        maxY = (cam.transform.position.y + cam.orthographicSize) - offsetCreating;
        minY = (cam.transform.position.y - cam.orthographicSize) + offsetCreating;

        maxX = cam.transform.position.x + cam.orthographicSize * cam.aspect - offsetCreating;
        minX = cam.transform.position.x - cam.orthographicSize * cam.aspect + offsetCreating;

        CreateGameObject(coins, coinsCount, coinsParent);
        CreateGameObject(spike, spikesCount, spikeParent);
    }
    public void CreateGameObject(GameObject GO, int counter, Transform parent)
    {
       for (int i = 0; i < counter; i++)
       {
           GameObject spikeGO;
           var x = Random.Range(minX, maxX);
           var y = Random.Range(minY, maxY);
           Vector3 _offset = new Vector3(x, y, 0);
           if (Physics2D.OverlapCircle(_offset, sphereRadiusDetection))
           {
                i--;
           }
           else
           {
                spikeGO = Instantiate(GO, new Vector3(x, y, 0), transform.rotation);
                spikeGO.transform.SetParent(parent);
           }
       }
    }
    public void Update()
    {

    }
}
