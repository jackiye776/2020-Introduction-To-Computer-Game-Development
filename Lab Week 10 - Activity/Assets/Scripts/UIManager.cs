using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private Image image;
    private Transform pos;
    private GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pos != null)
        { 
            // Ensures that fill amount starts at 1.0f (full health) then minus amount by distance away from centre of world
            image.fillAmount = 1.0f - (Mathf.Clamp(Mathf.Abs(pos.position.x), -5.0f, 5.0f) / 5.0f);

            if (image.fillAmount < 0.5f)
            {
                image.color = Color.red;
            }
            if(image.fillAmount > 0.5f)
            {
                image.color = Color.green;
            }

            healthBar.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
    }

    private void LateUpdate()
    {
        if(Input.GetKey(KeyCode.J))
        {
            Camera.main.transform.Rotate(Vector3.down, Space.World);
        }
        if (Input.GetKey(KeyCode.L))
        {
            Camera.main.transform.Rotate(Vector3.up, Space.World);
        }

    }


    public void LoadFirstLevel()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 0)
        {
            Button button = GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();
            button.onClick.AddListener(QuitGame);  
        }

        image = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
        pos = GameObject.FindGameObjectWithTag("Player").transform;
        healthBar = GameObject.Find("HealthBar");
    }

}
