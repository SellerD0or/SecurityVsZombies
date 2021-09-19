using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    private Timer _timer;
    private bool IsCooldown;
    
    [SerializeField]  private int _damage;
    [SerializeField] private float _health;
    private bool _isMove;
    private Player _player;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject[] _prefab;
  
    private void Start() {
       _timer = FindObjectOfType<Timer>();
        _player = FindObjectOfType<Player>();
        StartCoroutine(Move());
        _health = _health  + _timer.Extra;
        _damage = (int)((int)_damage + _timer.Extra);
       
    }
    private void Update() {
         
 Vector3 vectorToTarget = _player.transform. position - transform.position;
 float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
 Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
 transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 10);
 transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed  * Time.deltaTime);


    }
    public void TakeDamage(float _damage)
    {
      //  _particle.Play();
        _health -= _damage;
        
        if (_health <= 0)
        {
            if (IsSpawn(10))
            {
                int r = Random.Range(0, _prefab.Length);
                Instantiate(_prefab[r], transform.position, Quaternion.identity);
            }
           // Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
    private bool IsSpawn(int _max)
    {
        int r = Random.Range(0, 100);
        if (r < _max)
        {
            return true;
        }
        return false;
    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(1);
        _isMove =! _isMove;
         if (_isMove)
         {
             transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, 1);
         }  
         else
         {
              transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
         }
         StartCoroutine(Move());
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.TryGetComponent<Player>(out Player _character))
        {
           if(!IsCooldown)
           {
            _character.TakeDamage(_damage);
            StartCoroutine(CoolDown());
           }
        }
    }
     public  IEnumerator CoolDown()
    {
        IsCooldown = true;
        yield return new WaitForSeconds(1);
        IsCooldown = false;
    }
    
}
