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

    private GameObject _currentInteractable; // Para armazenar o objeto que pode ser interagido

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
        IsMoving();       
        IsRunning();       
        IsInteracting();
    }

    void FixedUpdate()
    {
        _rbCesar.MovePosition(_rbCesar.position + _directionCesar * _spdCesar * Time.fixedDeltaTime);

    }

    void IsMoving()
    {
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

    void IsRunning()
    {
        //Mecanica de corrida
        if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.K)) 
        {
            _spdCesar = 7;
        }

        else
        {
            _spdCesar = 3;
        }
    }

    void IsInteracting()
    {
        // Verifica se a tecla espaço foi pressionada e há um objeto próximo para interagir
        if (Input.GetKeyDown(KeyCode.Space) && _currentInteractable != null)
        {
            // Aqui você pode chamar uma função de interação do objeto
            Debug.Log("Interagindo com: " + _currentInteractable.name);
            // Exemplo de interação: 
            // _currentInteractable.GetComponent<Interactable>().Interact();
        }
    }

    // Detecta quando o jogador entra na área de um objeto interagível
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            _currentInteractable = other.gameObject;
            Debug.Log("Pode interagir com: " + other.name);
        }
    }

    // Detecta quando o jogador sai da área do objeto
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (_currentInteractable == other.gameObject)
            {
                _currentInteractable = null;
                Debug.Log("Saiu da área de interação com: " + other.name);
            }
        }
    }

}
