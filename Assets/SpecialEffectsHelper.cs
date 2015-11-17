using UnityEngine;

/// <summary>
/// Effets de particules sans efforts
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static SpecialEffectsHelper Instance;

    public ParticleSystem FireShoot;

    void Awake()
    {
        // On garde une référence du singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    /// <summary>
    /// Création d'une explosion à l'endroit indiqué
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position)
    {
        // Smoke From the canon
        instantiate(FireShoot);
    }

    /// <summary>
    /// Création d'un effet de particule depuis un prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private ParticleSystem instantiate(ParticleSystem prefab)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab) as ParticleSystem;

        // Destruction programmée
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}
