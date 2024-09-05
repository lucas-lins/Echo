using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AdjustAudioByDistance2D : MonoBehaviour
{
    public Transform _player; // Referência ao jogador
    private AudioSource _audioSource;
    public float _maxDistance = 40f; // Distância máxima onde o som é audível

    void Start()
    {
        // Obtém o componente AudioSource anexado ao GameObject
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calcula a distância 2D (no plano X e Y) entre o jogador e o objeto
        float distance = Vector2.Distance(_player.position, transform.position);

        // Calcula o volume com base na distância
        // O volume será 0 quando a distância for maior que maxDistance e 1 quando estiver próximo
        float volume = Mathf.Clamp01(1 - (distance / _maxDistance));

        // Define o volume do AudioSource
        _audioSource.volume = volume;
    }
}