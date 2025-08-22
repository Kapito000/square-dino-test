using Feature.Movement;
using Mirror;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Player
{
	public sealed class PlayerResolver : NetworkBehaviour
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
			if (isLocalPlayer)
			{
				InitPlayer();
			}
			else
			{
				InitNotLocalPlayer();
			}
		}

		void InitPlayer()
		{
			movement
				.Construct(movementInputListener)
				.Init();
		}

		void InitNotLocalPlayer()
		{
			Destroy(movement);
			Destroy(movementInputListener);
			Destroy(this);
		}
	}
}