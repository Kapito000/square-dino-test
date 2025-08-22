using Feature.Movement;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Player
{
	public sealed class PlayerResolver : MonoBehaviour
	{
		[SerializeField] Movement.Movement movement;
		[SerializeField] MovementInputListener movementInputListener;

		void Awake()
		{
			Assert.IsNotNull(movement);
			Assert.IsNotNull(movementInputListener);
		}

		void Start()
		{
			movement
				.Construct(movementInputListener)
				.Init();
		}
	}
}