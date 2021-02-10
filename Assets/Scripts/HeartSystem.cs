using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] Lives;
    public int life;
    private bool dead;
    public static int level;
    // Start is called before the first frame update
    void Start()
    {
        life = Lives.Length;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
        {
            level = 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 2"))
        {
            level = 2;
        }

    }

    // Update is called once per frame
    public void Update()
    {
        if (dead == true)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

   

    public void TakeDamage(int d)
    {
        life -= d;
        Destroy(Lives[life].gameObject);
        if(life < 1)
        {
            dead = true;
        }
    }
}
