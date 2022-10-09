using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 currentMousePos;

    private Queue<Vector2> points = new Queue<Vector2>();

    [Header("LineRender")]
    [SerializeField] private LineRenderer LR;
    [SerializeField] private List<Vector3> lineList = new List<Vector3>();
    [SerializeField] private int LRcounter;

    private void Start()
    {
        LR.startWidth = 0.05f;
        LR.endWidth = 0.05f;
        LR.positionCount = 1;
        LRcounter = 0;
        lineList.Add(transform.position);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RouteCreation();
        }
        RouteChecking();

    }

    public void RouteCreation()
    {
        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Enqueue(currentMousePos);
        LR.positionCount++;
        LRcounter++;
        LR.SetPosition(LR.positionCount - 1, currentMousePos);
        lineList.Add(LR.GetPosition(LRcounter));
    }
    public void RouteChecking()
    {
        if (points.Count != 0)
        {
            Vector3 _movePoint = points.Peek();
            transform.position = Vector2.MoveTowards(transform.position, _movePoint, speed * Time.deltaTime);

            if (transform.position == _movePoint)
            {
                lineList.RemoveAt(0);
                LR.positionCount--;
                LRcounter--;
                for (int i = 0; i < LR.positionCount; i++)
                {
                    LR.SetPosition(i, lineList[i]);
                }
                points.Dequeue();
            }
        }
    }
    public void ButtonRestart()
    {
        SceneManager.LoadScene(0);
    }
}