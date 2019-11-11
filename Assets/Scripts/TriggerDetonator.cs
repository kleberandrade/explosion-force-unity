using UnityEngine;

public class TriggerDetonator : Detonator
{
    public string m_Tag = "Enemy";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(m_Tag))
            Detonate();
    }
}