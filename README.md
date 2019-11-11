# Explosion for Games in Unity

Simple explosion force for games

<p align="center">
  <img width="600" src="Images/explosion.gif">
</p>

## Methods

## Codes

### Explosion

Explosion code

```csharp
public class Explosion : MonoBehaviour
{
    public float m_Force = 1000.0f;
    public float m_Radius = 5.0f;
    public float m_UpForce = 600.0f;
    public LayerMask m_Layer;

    public void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius, m_Layer);
        foreach (Collider collider in colliders)
        {
            Rigidbody body = collider.GetComponent<Rigidbody>();
            if (!body) continue;
            
            body.isKinematic = false;
            body.AddExplosionForce(m_Force, transform.position, m_Radius, m_UpForce);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, m_Radius);
    }
}
```

### Detonators

Base to detonators

```csharp
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
```

#### Button Detonator

Code to detonate the bomb by a button

```csharp
public class ButtonDetonator : Detonator
{
    public string m_ButtonName = "Jump";

    private void Update()
    {
        if (Input.GetButtonDown(m_ButtonName))
            Detonate();
    }
}
```

#### Contact Detonator

Code to detonate the bomb by contact

```csharp
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
```

#### Time Detonator

Code to detonate the bomb by time

```csharp
public class TimeDetonator : MonoBehaviour
{
    public float m_Time = 5.0f;

    private void Start()
    {
        Invoke("Detonate", m_Time);
    }
}
```

#### Trigger Detonator

Code to detonate the bomb by a trigger

```csharp
public class TriggerDetonator : Detonator
{
    public string m_Tag = "Enemy";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(m_Tag))
            Detonate();
    }
}
```

## License

    Copyright 2019 Kleber de Oliveira Andrade
    
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
