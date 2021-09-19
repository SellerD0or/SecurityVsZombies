using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticForAttack : MonoBehaviour
{
  public Joystick AttaclJoystick;
 public bool _isAttack;
 private void Awake() {
      AttaclJoystick.IsAttackJoystick = _isAttack;
 }
}
