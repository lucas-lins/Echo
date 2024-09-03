using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
 public string nextScene; // Nome da próxima cena a ser carregada
    public Animator doorAnimator; // Referência ao Animator da porta
    public float animationDuration = 2.0f; // Duração da animação
    private bool isTransitioning = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            StartCoroutine(OpenDoorAndTransition());
        }
    }

    private IEnumerator OpenDoorAndTransition()
    {
        isTransitioning = true;
        doorAnimator.SetTrigger("Open"); // Aciona a animação de abertura
        yield return new WaitForSeconds(animationDuration); // Espera a animação terminar
        SceneManager.LoadScene(nextScene); // Carrega a próxima cena
    }
}
