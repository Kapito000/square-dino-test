using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Movement
{
	public sealed class Movement : MonoBehaviour
	{
		[SerializeField] float _speed = 1.0f;
		[SerializeField] Rigidbody _rigidbody;
		
		IMovementController _movementController;

		void Awake()
		{
			Assert.IsNotNull(_rigidbody);
		}

		public Movement Construct(IMovementController movementController)
		{
			_movementController = movementController;
			return this;
		}

		public void Init()
		{
			_movementController
				.MovementDir
				.Subscribe(Move)
				.AddTo(this);
		}

		void Move(Vector2 value)
		{
			var velocity = new Vector3(value.x, 0, value.y) * _speed;
			_rigidbody.linearVelocity = velocity;
		}
	}
}