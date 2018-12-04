using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathParticlesPrefab;

    public void Kill()
    {
        SpawnDeathParticles();
        Destroy(gameObject);
        GameManager.I.RestartLevel();
    }

    private void SpawnDeathParticles()
    {
        ParticleSystem particles = Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
        particles.Play();
    }
}
