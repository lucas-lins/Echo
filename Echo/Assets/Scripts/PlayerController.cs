using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rbCesar;
    private Animator _animatorCesar;
    public float _spdCesar = 3;
    private Vector2 _directionCesar;
    private Vector2 _lastDirection; // Para armazenar a última direção de movimento

    void Start()
    {
        _rbCesar = GetComponent<Rigidbody2D>();
        _animatorCesar = GetComponent<Animator>();
        _lastDirection = Vector2.down; // Direção padrão inicial
    }

    void Update()
    {
        // Capturar a direção de movimento
        _directionCesar = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Verificar se há movimento
        if (_directionCesar.sqrMagnitude > 0)
        {
            _lastDirection = _directionCesar; // Atualiza a última direção quando o jogador está se movendo
            _animatorCesar.SetInteger("IsMoving", 1);
            _animatorCesar.SetFloat("MoveX", _directionCesar.x);
            _animatorCesar.SetFloat("MoveY", _directionCesar.y);
        }
        else
        {
            _animatorCesar.SetInteger("IsMoving", 0);
            _animatorCesar.SetFloat("MoveX", _lastDirection.x);
            _animatorCesar.SetFloat("MoveY", _lastDirection.y);
        }
    }

    void FixedUpdate()
    {
        _rbCesar.MovePosition(_rbCesar.position + _directionCesar * _spdCesar * Time.fixedDeltaTime);

    }

}
