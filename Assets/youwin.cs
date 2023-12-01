using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class youwin : MonoBehaviour
{
    public GameObject youwinbackground;
    public Text youwintext;
    public AudioSource youwinaudio;
    public AudioClip success;

    void OnTriggerEnter2D()
    {
        youwinaudio.PlayOneShot(success);
        youwinbackground.SetActive(true);
        youwintext.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }
}
