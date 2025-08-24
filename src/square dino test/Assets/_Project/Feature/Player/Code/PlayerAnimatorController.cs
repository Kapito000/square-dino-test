using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Player
{
	public sealed class PlayerAnimatorController : MonoBehaviour
	{
		[SerializeField] Rigidbody _rigidbody;
		[SerializeField] PlayerAnimator _playerAnimator;

		void Awake()
		{
			Assert.IsNotNull(_rigidbody);
			Assert.IsNotNull(_playerAnimator);
		}

		void Update()
		{
			if (_rigidbody.velocity.sqrMagnitude > .01)
				_playerAnimator.Run(true);
			else
				_playerAnimator.Run(false);
		}
	}
}