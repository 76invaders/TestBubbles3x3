using UnityEngine;

public class BubblesParticles : MonoBehaviour
{
    [SerializeField] GameObject _bubbleParticle;
    ParticleSystem.MainModule _mainParticle;

    public void CreateParticle(Color color,Transform transform)
    {
        _mainParticle = _bubbleParticle.GetComponent<ParticleSystem>().main;
        _mainParticle.startColor = color;
        GameObject Explode = Instantiate(_bubbleParticle,transform.position, transform.rotation);
    }
}
