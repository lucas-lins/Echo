using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private GameObject _currentInteractable; // Para armazenar o objeto que pode ser interagido

    // Update is called once per frame
    void Update()
    {
        IsInteracting();
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
        if (other.CompareTag("Player"))
        {
            _currentInteractable = other.gameObject;
            Debug.Log("Pode interagir com: " + other.name);
        }
    }

    // Detecta quando o jogador sai da área do objeto
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_currentInteractable == other.gameObject)
            {
                _currentInteractable = null;
                Debug.Log("Saiu da área de interação com: " + other.name);
            }
        }
    }
}
