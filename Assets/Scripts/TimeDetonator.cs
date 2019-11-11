using UnityEngine;

public class TimeDetonator : MonoBehaviour
{
    public float m_Time = 5.0f;

    private void Start()
    {
        Invoke("Detonate", m_Time);
    }
}