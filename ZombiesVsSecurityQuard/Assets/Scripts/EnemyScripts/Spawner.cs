using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Player _Player;
    [SerializeField] private Enemy _enemy;
    private   int _randomX, _randomY;
    private Vector2 _position;
    private void Start() {
        _Player = FindObjectOfType<Player>();
        StartCoroutine(Cooldown());
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5);
       if(SetRandomNumber())
        Instantiate(_enemy, _position, Quaternion.identity);
        StartCoroutine(Cooldown());
    }
    private bool SetRandomNumber()
    {
         _randomX = Random.Range(-27, 51);
           _randomY = Random.Range(-22, 11);
           _position = new Vector2(_randomX, _randomY);
        if (Vector2.Distance(_Player.transform.position, _position) <= 10)
        {
            SetRandomNumber();
            return false;
        }
        else
        return true;
    }
}
