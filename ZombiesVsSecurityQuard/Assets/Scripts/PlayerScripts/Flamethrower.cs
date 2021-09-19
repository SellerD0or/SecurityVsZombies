using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    private bool _isCooldown;
    private Player _player;
    
    [SerializeField] private float _damage = 1f;
    private void OnEnable() {
        ChangeText();
    }
    private void Start() {
        _player = FindObjectOfType<Player>();
    }
   private void OnTriggerStay2D(Collider2D other) {
    if (other.TryGetComponent<Enemy>(out Enemy _enemy))
    {
        if(!_isCooldown && AmountOfBullets > 0)
        {
            AmountOfBullets --;
        _enemy.TakeDamage(_damage);
         ChangeText();
        StartCoroutine(Cooldown());
        }
    }
      
  }
  
  public void ReturnAnimation()
  {
      _player.CanFire = false;
  }
  private IEnumerator Cooldown()
  {
      _isCooldown = true;
      yield return new WaitForSeconds(WaitTime);
      _isCooldown = false;
  }
}
