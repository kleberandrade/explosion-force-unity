using UnityEngine;

public class ContactDetonator : Detonator
{
    public LayerMask m_Layer;
    public float m_Radius;

    private void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, m_Radius, m_Layer))
            Detonate();
    }
}