using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : Weapon
{
    [SerializeField] private int _lostAmount;
    [SerializeField] private ParticleSystem _particle;
   
   
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private GameObject _bullet;
    
    private void Start() {
        _particle.Stop();
       ChangeText();
    }
    
    
    public  void Shoot(Player _player) {
         _shotPosition.transform.rotation = _player.transform.rotation;
        if(!IsCooldown && AmountOfBullets > 0)
        {
            _particle.Play();
            AmountOfBullets -= _lostAmount;
          GameObject go = Instantiate(_bullet, _shotPosition.position, _shotPosition.rotation); 
          go.transform.rotation = _shotPosition.rotation;
           ChangeText();
         StartCoroutine(CoolDown());

        }
    }
   
    
}
