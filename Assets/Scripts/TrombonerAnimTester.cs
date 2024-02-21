using UnityEngine;

public class TrombonerAnimTester : MonoBehaviour
{
#if UNITY_EDITOR
	private const float DefaultTempo = 120.0f;

	public bool IsEnabled = true;
	public bool IsOutOfBreath = false;
	public float SongTempo = DefaultTempo;
	public Animator TrombonerAnimator;

	private bool _prevIsMousePressed = false;
	private bool _prevIsOutOfBreath = false;

    void Start()
    {
        if (TrombonerAnimator == null)
		{
			Debug.LogWarning("[TrombonerAnimTester] Assigned Animator is null, tester will do nothing.");
		}
    }

    void Update()
    {
		if (TrombonerAnimator == null || !IsEnabled)
		{
			return;
		}

		bool isMousePressed = Input.GetMouseButton(0);

		if (_prevIsMousePressed != isMousePressed)
		{
			_prevIsMousePressed = isMousePressed;
			TrombonerAnimator.SetBool("Tooting", isMousePressed);
		}

		if (_prevIsOutOfBreath != IsOutOfBreath)
		{
			_prevIsOutOfBreath = IsOutOfBreath;
			TrombonerAnimator.SetBool("OutOfBreath", IsOutOfBreath);
		}

		TrombonerAnimator.SetFloat("PointerY", Input.mousePosition.y / Screen.height);
		TrombonerAnimator.SetFloat("AnimationSpeed", SongTempo / DefaultTempo);
	}
#endif
}
