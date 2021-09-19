using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeOfBullet
{
    Gun,
    Shotgun
}
public class Bullet : MonoBehaviour
{
    [SerializeField] private TypeOfBullet _typeOfButton;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _destroyTime = 3;
    [SerializeField] private float _speed = 15f;
    private void Start() {
        Destroy(gameObject,_destroyTime);
         if(_typeOfButton == TypeOfBullet.Shotgun)
        transform.rotation = Quaternion.AngleAxis(Random.Range(-30, 30), Vector3.forward);
    }
  
   private void Update() {
      
           transform.Translate(Vector2.right  * Time.deltaTime * _speed);
   }
   private void OnTriggerEnter2D(Collider2D other) {
       if (other.TryGetComponent<Enemy>(out Enemy _enemy))
       {
           _enemy.TakeDamage(_damage);
       }
   }
}
