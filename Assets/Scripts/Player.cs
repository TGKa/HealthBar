using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string TrigerHit = "Hit";
    private const string BoolIsLive = "IsLive";

    [SerializeField] private int _maxHealth;

    private int _health = 5;
    private bool _isLive = true;
    private Animator _animator;

    public event UnityAction<int, int> ChangedHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        ChangedHealth?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _animator.SetTrigger(TrigerHit);

        if (_health <= 0)
        {
            _isLive = false;
            _animator.SetBool(BoolIsLive, false);
        }

        ChangedHealth?.Invoke(_health, _maxHealth);
    }

    public void HealHealth(int healing)
    {
        if (_isLive)
        {
            _health += healing;

            if (_health > _maxHealth)
                _health = _maxHealth;
        }

        ChangedHealth?.Invoke(_health, _maxHealth);
    }
}
