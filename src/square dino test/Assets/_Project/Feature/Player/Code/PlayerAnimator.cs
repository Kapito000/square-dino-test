using Mirror;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Player
{
	public sealed class PlayerAnimator : NetworkBehaviour
	{
		static readonly int _run = Animator.StringToHash("run");

		[SerializeField] Animator _animator;

		void Awake()
		{
			Assert.IsNotNull(_animator);
		}

		[Command]
		public void CmdRun(bool enable)
		{
			_animator.SetBool(_run, enable);
		}
	}
}