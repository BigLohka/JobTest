using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPart : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float deathTimer;
    private Vector3 startScale;
    private Vector3 deathScale = new Vector3(0.5f,0.5f,0.5f);

    private void Start()
    {
        deathTimer = 5;
        startScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }
    private void Update()
    {

            transform.localScale = Vector3.Lerp(startScale, deathScale, Time.deltaTime * 50);

    }


}
