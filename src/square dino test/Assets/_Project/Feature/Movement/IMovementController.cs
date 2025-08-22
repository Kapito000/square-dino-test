using System;
using UnityEngine;

namespace Feature.Movement
{
	public interface IMovementController
	{
		IObservable<Vector2> MovementDir { get; }
	}
}