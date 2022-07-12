using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScense : MonoBehaviour
 {
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("ChangeScense");
    }
    public void StartButton()
    {
        SceneManager.LoadScene("StartScense");
        Debug.Log("ChangeScense");
    }
    public void RuleButton()
    {
        SceneManager.LoadScene("Rule");
        Debug.Log("ChangeScense");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
