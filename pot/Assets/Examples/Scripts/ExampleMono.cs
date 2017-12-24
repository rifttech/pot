using Pot;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Examples {
    public class ExampleMono : MonoBehaviour {

        [Bind]
        private Rigidbody2D _rigidbody;

        [Bind(failover: true, resolver: "InitRigidBodyDefault")]
        private BoxCollider2D _collider;

        private void Awake() {
            P.Bind(this);
        }
      
        private void Start () {
            PrintThis(_rigidbody, typeof(Rigidbody2D).Name);
            PrintThis(_collider, typeof(Collider2D).Name);
        }

        private void PrintThis(object o, string type) {
            Debug.Log(o != null
                ? "\"" + type + "\" initialized"
                : "\"" + type + "\" didn't initialized");
        }

        private void InitBoxCollider2DDefault(BoxCollider2D box) {
            Debug.Log("Setting Default BoxCollider2D");
        }
    }
}
