using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Player
{
	public sealed class PlayerAnimator : MonoBehaviour
	{
		static readonly int _run = Animator.StringToHash("run");

		[SerializeField] Animator _animator;

		void Awake()
		{
			Assert.IsNotNull(_animator);
		}

		public void Run(bool enable)
		{
			_animator.SetBool(_run, enable);
		}
	}
}