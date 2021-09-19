using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
     private float _extra ;
    [SerializeField] private Text _text;
    private int _seconds;
     private int _hours;
     private float _increase = 0.005f;

    public float Extra { get => _extra; set => _extra = value; }
    public int Hours { get => _hours; set => _hours = value; }
    public int Seconds { get => _seconds; set => _seconds = value; }

    private Player _player;

    private void Start() {
        _player = FindObjectOfType<Player>();
        _text.text = "Ты выживаешь уже: " + Hours + " : " + Seconds.ToString();
        StartCoroutine(ChangeTime());
    }
    private void Update() {
        Extra += _increase * Time.deltaTime;
//        Debug.Log(Extra);
    }
    private IEnumerator ChangeTime() {
        yield return new WaitForSeconds(1);
        Seconds++;
        _player.IncreaseAmountOfBullet(1);
        if (Seconds >= 60)
        {
            Hours++;
            Seconds=0;
        }
        _text.text = "Ты выживаешь уже: " + Hours + " : " + Seconds.ToString();
        StartCoroutine(ChangeTime());
    }
}
