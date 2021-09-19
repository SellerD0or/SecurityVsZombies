using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract  class  Weapon : MonoBehaviour
{
     [SerializeField] private float waitTime = 3;
    private bool isCooldown;
   [SerializeField] private int _amountOfBullets = 100;
     [SerializeField] private Text _amountOfBulletsText;

    public Text AmountOfBulletsText { get => _amountOfBulletsText; set => _amountOfBulletsText = value; }
    public int AmountOfBullets { get => _amountOfBullets; set => _amountOfBullets = value; }
    public bool IsCooldown { get => isCooldown; set => isCooldown = value; }
    public float WaitTime { get => waitTime; set => waitTime = value; }

    public virtual void IncreaseAmountOfBullet(int _extraAmount)
    {
       
        AmountOfBullets += _extraAmount;
    }
    public virtual void ChangeText()
    {
        Debug.Log("COOOOOOOOOOOOOOOOOOL");
         AmountOfBulletsText.text = "Количество пуль: " + AmountOfBullets.ToString();
    }
    public virtual IEnumerator CoolDown()
    {
        IsCooldown = true;
        yield return new WaitForSeconds(WaitTime);
        IsCooldown = false;
    }
}
