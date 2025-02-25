﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour
{

    private SpriteRenderer sprtRenderer;
    private CircleCollider2D circCollider;
    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sprtRenderer = GetComponent<SpriteRenderer>();
        circCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sprtRenderer.enabled = false; //tira o abacaxi
            circCollider.enabled = false; //desativa o colisor do abacaxi
            collected.SetActive(true); //ativa a animação de coleta

            Points.instance.totalScore += Score;
            Points.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f); //delay sumiço     
        }
    }
}