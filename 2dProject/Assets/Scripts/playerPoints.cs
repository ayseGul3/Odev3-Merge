using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;    //TextMeshProUGUI fonsksiyonu ile karakterin üzerinde tut çek yapýlabilir
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        _text.text= score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Elmas"))
        {
            audio.Play();
            Destroy(collision.gameObject);
            score.totalScore++;
            _text.text = score.totalScore.ToString();
        }
    }

}
