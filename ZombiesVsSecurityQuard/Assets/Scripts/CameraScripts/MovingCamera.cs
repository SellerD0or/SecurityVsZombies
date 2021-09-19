using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
     public float _smoothTime;
    private Vector2 _velocity;
    [SerializeField] private Player _player;
      [SerializeField] private float _leftLimit;
    [SerializeField] private float _rightLimit;
     [SerializeField] private float _bottomLimit;
     [SerializeField] private float _topLimit;
    private void Update() {
        transform.position = new Vector3
       (
        Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit), 
            Mathf.Clamp(transform.position.y, _bottomLimit, _topLimit), 
            transform.position.z
      );
    }
    private void FixedUpdate() {
      Vector3 _direction  = new Vector3(Move(transform.position.x,_player.transform.position.x, _smoothTime), Move(transform.position.y,  _player.transform.position.y, _smoothTime), transform.position.z);
       transform.position = _direction;
    }
    private float Move(float _playerPosition, float _position, float smoothTime)
    {
       return  Mathf.SmoothDamp( _position, _playerPosition, ref _velocity.x, smoothTime);
    }
}
