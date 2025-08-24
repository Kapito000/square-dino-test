using Mirror;
using TMPro;
using UnityEngine;

namespace Feature.Player.Nickname
{
	public class NickName : NetworkBehaviour
	{
		[SyncVar(hook = nameof(OnNicknameChanged))]
		[SerializeField] string _playerName;
		[SerializeField] TMP_Text _nicknameView;

		void OnNicknameChanged(string oldValue, string newValue)
		{
			_nicknameView.text = _playerName;
		}

		public override void OnStartLocalPlayer()
		{
			CmdSetPlayerNickname(FindObjectOfType<NicknameProvider>().Nickname);
		}

		[Command]
		void CmdSetPlayerNickname(string newNickname)
		{
			_playerName = newNickname;
		}
	}
}