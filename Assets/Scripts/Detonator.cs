using UnityEngine;

public class Detonator : MonoBehaviour
{
    private Explosion m_Explosion;

    private void Awake()
    {
        m_Explosion = GetComponent<Explosion>();
    }

    public void Detonate(float duration = 4.0f, float magnitude = 30.0f)
    {
        m_Explosion.Detonate();
        CameraShake.Instance.ShakeOnce(duration, magnitude);
        Destroy(gameObject, 0.3f);
    }
}