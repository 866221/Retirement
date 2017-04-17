using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrevTransScript : MonoBehaviour, IGvrGazeResponder {

	bool isActive;
	float activeTime;
	UIController controller;
	Image selectionProgress;
	public float selectionTime = 2;

	// Use this for initialization
	void Start () {
		isActive = false;
		controller = new UIController ();

		foreach (Image image in gameObject.GetComponentsInChildren<Image>()) {
			selectionProgress = image;
		}
		selectionProgress.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			activeTime += Time.deltaTime;

			selectionProgress.fillAmount = (activeTime / selectionTime);
		}

		if (activeTime >= selectionTime) {
			previous ();
		}

		if (!isActive) {
			activeTime = 0;
			selectionProgress.fillAmount = 0;
		}
	}

	public void OnGazeEnter() {
		isActive = true;
	}

	public void OnGazeExit() {
		isActive = false;
	}

	public void OnGazeTrigger() {
		previous ();
	}

	public void previous() {
		controller.PreviousClicked ();
	}
}
