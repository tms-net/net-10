namespace Homework_7
{
	/// <summary>
	/// States of canon
	/// </summary>
	public enum CanonState
	{
		Awaiting,
		Aim,
		Atack
	}

	/// <summary>
	/// States of plane
	/// </summary>
	public enum PlaneState
	{
		TakeOff,
		Atack,
		Land
	}

	/// <summary>
	/// States of fighter
	/// </summary>
	public enum FighterState
	{
		Awaiting,
		Moving,
		Atack,
		Protect
	}
}

