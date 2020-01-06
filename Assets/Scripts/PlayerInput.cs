using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private SwordOfChaosSkill _swordOfChaosSkill;
    private DashSkill _dashSkill;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _swordOfChaosSkill = GetComponent<SwordOfChaosSkill>();
        _dashSkill = GetComponent<DashSkill>();
    }

    private void Update()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _playerMovement.SetDirection(movementDirection);
        if (Input.GetAxisRaw("Fire2") == 1)
            _dashSkill.Dash(movementDirection);
        if (Input.GetAxisRaw("Fire1") == 1)
            _swordOfChaosSkill.StartSwinging();
    }
}
