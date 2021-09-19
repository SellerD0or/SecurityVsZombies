using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeOfWeapon
{
   Pistol =0,
   Flamethrower =1,
   Shotgun = 2,
   Sword =3
}
public class Player : MonoBehaviour
{
   private NextScene _nextScene;
   private bool _canFire;
   [SerializeField] private GameObject _fire;
   [SerializeField] private TypeOfWeapon _typeOfWeapon;
   [SerializeField] private GameObject[] _weapons;
   
   private int _maxHealth;
   [SerializeField] private int _health = 10;
   [SerializeField] private Rigidbody2D _rigidbody2d;
      [SerializeField] private Joystick _AttackJoystick;
       [SerializeField] private Joystick _MovingJoystick;
       [SerializeField] private Flamethrower _flamethrower;

    [SerializeField] private GameObject _handle;
    [SerializeField] private float _speed = 15f;
    private Vector3 _direction;
    private bool _isAttack = true;
    private float angle;
    [SerializeField] private Weapon _currentweapon;
    [SerializeField] private Gun _gun;
    [SerializeField] private Gun _shotGun;
   
    [SerializeField] private Transform _centreOfJoystick;

    public bool IsAttack { get => _isAttack; set => _isAttack = value; }
    public bool CanFire { get => _canFire; set => _canFire = value; }
    public int Health { get => _health; set => _health = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    private Health _heart;

    private void Start() {
       _nextScene = FindObjectOfType<NextScene>();
        _heart = FindObjectOfType<Health>();
      MaxHealth = Health;
    }

    private void Update() {
     
       Vector2 movement = new Vector2(_MovingJoystick.Horizontal, _MovingJoystick.Vertical);
       _rigidbody2d.velocity = movement * _speed ;
      if(IsAttack)
      {
        _direction = _handle.transform.position - _AttackJoystick.transform.position;
      
       angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
       Rotate();
       if (CheckDistance())
       {
              switch (_typeOfWeapon)
              {
                 case TypeOfWeapon.Shotgun:
                 _shotGun.Shoot(this);
                 break;
                  case TypeOfWeapon.Pistol:
                   _gun. Shoot(this);
                  break;
                  case TypeOfWeapon.Flamethrower:
                  if (!_canFire)
                  {
                      _fire.SetActive(true);
                      _canFire = true;
                  }
                  break;
                  
              }
                
             
         
       }
      }
   }
   public bool CheckDistance()
   {
      return  (Vector2.Distance(_centreOfJoystick.transform.position, _handle.transform.position) >= 100);
      
      
   }
   public void Changeweapon(int _weapon)
   {
      
       _typeOfWeapon =(TypeOfWeapon) _weapon;
      foreach (var item in _weapons)
      {
          item.gameObject.SetActive(false);
      }
      _weapons[_weapon].gameObject.SetActive(true);
        switch (_typeOfWeapon)
              {

                  case TypeOfWeapon.Pistol:
                   _gun. ChangeText();
                   _currentweapon = _gun;
                  break;
                   case TypeOfWeapon.Shotgun:
                   _shotGun. ChangeText();
                   _currentweapon = _shotGun;
                  break;
                  case TypeOfWeapon.Flamethrower:
                  _flamethrower.  ChangeText();
                  _currentweapon = _flamethrower;
                  break;
                  
              }
     
     
   }
   public  void Rotate()
   {
      transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
   }
   public void StopToFire()
   {
       _fire.SetActive(false);
   }
   public void Fire()
   {
     _canFire = false;
   }
   public void TakeDamage(int _damage)
   {
       _heart.ChangeHealth();
      Health -= _damage;
      if (Health <= 0)
      {
       
          _heart.ChangeHealth();
            _nextScene.EndGame();
          Destroy(gameObject);
      }
   }
   public void IncreaseAmountOfBullet(int _amount)
   {
        _currentweapon.IncreaseAmountOfBullet(_amount);
          _currentweapon.ChangeText();
   }
   private void OnTriggerEnter2D(Collider2D other) {
      if (other.TryGetComponent<BulletAmount>(out BulletAmount _bulletAmount))
      {
     
       IncreaseAmountOfBullet(_bulletAmount.ExtraBulletAmount);
        

          _bulletAmount.Play();
      }
      if (other.GetComponent<FirstAndKit>())
      {
      
          Health+= 2;
           _heart.ChangeHealth();
          Destroy(other.gameObject);
         
      }
   }

}
