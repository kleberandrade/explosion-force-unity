using UnityEngine;

public class ButtonDetonator : Detonator
{
    public string m_ButtonName = "Jump";

    private void Update()
    {
        if (Input.GetButtonDown(m_ButtonName))
            Detonate();
    }
}