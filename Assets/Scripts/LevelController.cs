using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    Monster[] _monsters;
    [SerializeField] string _nextLevelName;

    // Update is called once per frame
    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
        
    }

    void Update()
    {
        if (MonstersAreAllDead())
        {
            GoToNextLevel();
        }
  
        
    }

     bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
            {
                return false;
            }

            
        }
        return true;
    }

    void GoToNextLevel()
    {
        Debug.Log("Going to next level");
        SceneManager.LoadScene(_nextLevelName);
    }
}
