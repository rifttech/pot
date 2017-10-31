# Pot
little library for unity3d

# How to use

```CSharp
using Pot;
using Pot.Annotations
using UnityEngine;
namespace Example {
  public class MyMonoComponent : MonoBehaviour {
    [Bind] private Rigidbody _rigidbody;
    [Bind] private MyAnotherCoolMonoComponent _component;

    private void Awake(){
      P.Bind(this);
    }

  }
}
```
