using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouteCreating : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 currentMousePos;

    private Queue<Vector2> points = new Queue<Vector2>();

    [Header("LineRender")]
    [SerializeField] private LineRenderer lineRender;
    [SerializeField] private List<Vector3> lineList = new List<Vector3>();
    [SerializeField] private int lineRendercounter;

    private void Start()
    {
        lineRender.startWidth = 0.05f;
        lineRender.endWidth = 0.05f;
        lineRender.positionCount = 1;
        lineRendercounter = 0;
        lineList.Add(transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RouteCreation();
        }
        RouteChecking();

    }

    private void RouteCreation()
    {
        currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Enqueue(currentMousePos);
        lineRender.positionCount++;
        lineRendercounter++;
        lineRender.SetPosition(lineRender.positionCount - 1, currentMousePos);
        lineList.Add(lineRender.GetPosition(lineRendercounter));
    }
    private void RouteChecking()
    {
        if (points.Count != 0)
        {
            Vector3 _movePoint = points.Peek();
            transform.position = Vector2.MoveTowards(transform.position, _movePoint, speed * Time.deltaTime);

            if (transform.position == _movePoint)
            {
                lineList.RemoveAt(0);
                lineRender.positionCount--;
                lineRendercounter--;
                for (int i = 0; i < lineRender.positionCount; i++)
                {
                    lineRender.SetPosition(i, lineList[i]);
                }
                points.Dequeue();
            }
        }
    }
    private void ButtonRestart()
    {
        SceneManager.LoadScene("Main Scene");
    }
}