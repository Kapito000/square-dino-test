using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.Movement
{
	public sealed class Movement : MonoBehaviour
	{
		[SerializeField] float _speed = 1.0f;
		[SerializeField] Rigidbody _rigidbody;

		[Inject]
		void Construct(IInputController inputController)
		{
			inputController
				.MovementDir
				.Subscribe(Move)
				.AddTo(this);
		}

		void Awake()
		{
			Assert.IsNotNull(_rigidbody);
		}

		void Move(Vector2 value)
		{
			var velocity = new Vector3(value.x, 0, value.y) * _speed;
			_rigidbody.velocity = velocity;
		}
	}
}