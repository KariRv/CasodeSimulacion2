using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Character3DController : MonoBehaviour
{
    [SerializeField]
    float attackRate;

    [SerializeField]
    float attackRange;


    StarterAssetsInputs _input;
    Animator _animator;

    int _swordSlashHash;

    bool _swordSlashState;

    float _attackTime;

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();

        _swordSlashHash = Animator.StringToHash("SwordSlash");
    }

    private void Update()
    {
        if (_swordSlashState != _input.swordSlash)
        {
            _swordSlashState = _input.swordSlash;

            if(_attackTime > 0)
            {
                _attackTime -= Time.deltaTime;
                _attackTime = Mathf.Clamp(_attackTime, 0.0F, attackRange);
            }
            if (_swordSlashState &&  _attackTime == 0)
            {
                _animator.SetTrigger(_swordSlashHash);
                _attackTime = ( attackRange / attackRate);
            }
        }
    }

}
