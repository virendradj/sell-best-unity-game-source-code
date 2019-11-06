using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * IMPORTANT. This is example code and therefore subject to changes without prior notice. 
 * You can use this class as a starting point to integrate session M service into your application.
 * 
 * Session M manager. Starts session M service, registers and listens to service callbacks to display UI activies and perform other functions. 
 */
public class SessionMManager : MonoBehaviour, ISessionMCallback
{
	void OnEnable()
	{
		DontDestroyOnLoad(this);
#if UNITY_IPHONE && !UNITY_EDITOR
		SessionM.GetInstance().SetCallback(this);
#endif
	}
	
	void OnDisable() 
	{
#if UNITY_IPHONE && !UNITY_EDITOR
		SessionM.GetInstance().SetCallback(null);
#endif
	}
	
	// Notifies that session state has changed.  
	public void NotifySessionStateChanged(ISessionM sessionM, SessionState state) 
	{
		// Insert your code here
		//if(state == SessionState.StartedOnline || state == SessionState.StartedOffline) {
		//	UtilScript.Log("SessionM started successfully!");
		//}
	}
	
	public void NotifySessionError(ISessionM sessionM, int code, string description) 
	{
		// Insert your code here
		// UtilScript.Log("SessionM failed with error: " + description);
	}

	public void NotifyActivityPresented(ISessionM sessionM, ActivityType type)
	{
		// Insert your code here
		// e.g. suspend your game
		// Time.timeScale = 0.0f;
	}
	
	public void NotifyActivityDismissed(ISessionM sessionM, ActivityType type)
	{
		// Insert your code here
		// e.g. resume your game
		// Time.timeScale = 1.0f;
	}

	public void NotifyActivityUnavailable(ISessionM sessionM, ActivityType type)
	{
		// Insert your code here
	}
	
	public void NotifyActivityAvailable(ISessionM sessionM, ActivityType type)
	{
		// Insert your code here
		// e.g. present activity immediatelly
		// sessionM.PresentActivity(type);
	}

	public void NotifyUserInfoChanged(ISessionM sessionM, IDictionary<string, object> info)
	{
		// Insert your code here
	}
}

