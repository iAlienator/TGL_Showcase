using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	void Start () { }

    public void SwitchScene()
    {
        SceneManager.LoadScene("Main");
    }
}
