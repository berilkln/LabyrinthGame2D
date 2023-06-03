using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float counter;
    private Slider time;
    private Text timeInfo;
    int can;
    public GameObject Playerr;
    [SerializeField] GameObject restartPanel, gameoverPanel;

    private void Awake()
    {
        timeInfo = GameObject.FindWithTag("TimeInfo").GetComponent<Text>();
        time = GameObject.Find("Timer").GetComponent<Slider>();
         
    }
    // Start is called before the first frame update
    void Start()
    {
        time.maxValue = 30f;
        time.minValue = 0f;
        time.wholeNumbers = false;
        time.value = time.maxValue;
        counter = time.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(time.value > time.minValue ){
            counter -= Time.deltaTime;
            time.value = counter;
            timeInfo.text = ((int)time.value).ToString();
        }
        else
        {
            timeInfo.text = "Time is Up!!";
            Player.isDead = true;
            Destroy(this.gameObject);
            restartPanel.SetActive(true);
            can = Playerr.GetComponent<Player>().playerLife--;
            //playerLife--;

            PlayerPrefs.SetInt("PlayerLife", can = Playerr.GetComponent<Player>().playerLife);


            Debug.Log("can" + Playerr.GetComponent<Player>().playerLife);
            if (Playerr.GetComponent<Player>().playerLife == -1)
            {
                Debug.Log("Calısti");
                gameoverPanel.SetActive(true);
                //SceneManager.LoadScene("SampleScene");

            }
        }
    }
}
