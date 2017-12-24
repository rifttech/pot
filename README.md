# Pot
little library for unity3d

# How to use

## Standart Unity3d Way
```CSharp
using UnityEngine;
namespace Example {
  public class MyMonoComponent : MonoBehaviour {
    private Rigidbody _rigidbody;
    private MyAnotherCoolMonoComponent _component;

    private void Awake(){
      _rigidbody = GetComponent<Rigidbody>();
      if(_rigidbody == null){
        // do something
      }
      _component = GetComponent<MyAnotherCoolMonoComponent>();
      if(_component == null){
        // do something
      }
      
      
    }

  }
}
```
## With Pot

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
