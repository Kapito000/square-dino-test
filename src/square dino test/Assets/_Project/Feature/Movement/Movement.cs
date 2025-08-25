using UniRx;
using UnityEngine;
using Zenject;

namespace Feature.Movement
{
	public sealed class Movement : MonoBehaviour
	{
		[SerializeField] float _speed = 1.0f;
		
		[Inject] Rigidbody _rigidbody;

		[Inject]
		void Construct(IInputController inputController)
		{
			inputController
				.MovementDir
				.Subscribe(Move)
				.AddTo(this);
		}

		void Move(Vector2 value)
		{
			var velocity = new Vector3(value.x, 0, value.y) * _speed;
			_rigidbody.velocity = velocity;
			Rotate(velocity);
		}

		void Rotate(Vector3 velocity)
		{
			if (velocity != Vector3.zero) 
				transform.rotation = Quaternion.LookRotation(velocity);
		}
	}
}