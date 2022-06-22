using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip soundBackground;
    bool isSetting = false;
    bool isPowerUp = false;
    bool isX2Gold = false;
    float power;
    int _timePower = 0, _timeX2 = 0;
    // Button
    public GameObject btnPlay, btnPause;
    public GameObject btnSoundOn, btnSoundOff;
    public GameObject btnExit;
    public GameObject btnSetting;

    // value

    public int timeItem = 10; // thoi gian tac dung cua items 5s
    public int x = 1; // x nhan gia tri vat the khi x2

    // Start is called before the first frame update
    void Start()
    {
        // lay gia tri suc manh ban dau
        power = GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundBackground;
        audioSource.Play();
        audioSource.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Bomb()
    {
        // kiem tra co dang gap vat the ko
        bool isTouch = GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().isTouchObj;
        if(isTouch)
            GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().Bomb();
    }
    public void upPower()
    {
        StartCoroutine(PowerUp());
    }
    IEnumerator PowerUp()
    {
        if (!isPowerUp)
        {
            isPowerUp = true; 
            // tang suc manh cho luoi cau x3
            GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed *= 3;

            while(isPowerUp)
            {
                _timePower += 1;
                if (_timePower >= timeItem)
                {
                    _timePower = 0;
                    // khoi phuc gia tri suc manh ban dau
                    GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed = power;
                    isPowerUp = false;
                }
			yield return new WaitForSeconds (1);
	        }
        }
    }

    public void MoreTime()
    {
        // Cong them 5s
        GameObject.Find("GamePlay").GetComponent<GamePlayScript>().time += timeItem; 
    }

    public void GoldX2()
    {
        StartCoroutine(X2Gold());
    }

    IEnumerator X2Gold()
    {
        if (!isX2Gold)
        {
            isX2Gold = true;
            // X2 gia tri cua vat the
            x = 2;
            while (isX2Gold)
            {
                _timeX2 += 1;
                if (_timeX2 >= timeItem)
                {
                    _timeX2 = 0;
                    // khoi phuc gia tri ban dau cua vat the
                    x = 1;  
                    isX2Gold = false;
                }
                yield return new WaitForSeconds(1);
            }
        }
    }

    public void Setting()
    {
        if(!isSetting)
        {
            Time.timeScale = 0;
            btnPlay.SetActive(true);
            if (audioSource.volume == 1)
                btnSoundOn.SetActive(true);
            else
                btnSoundOff.SetActive(true);
            btnExit.SetActive(true);
            isSetting = true;
        }
        else
        {
            btnPlay.SetActive(false);
            btnPause.SetActive(false);
            btnSoundOff.SetActive(false);
            btnSoundOn.SetActive(false);
            btnExit.SetActive(false);
            isSetting = false;
        }
        
    }

    public void SoundOn()
    {
        audioSource.volume = 0;
        btnSoundOn.SetActive(false);
        btnSoundOff.SetActive(true);
    }

    public void SoundOff()
    {
        audioSource.volume = 1;
        btnSoundOff.SetActive(false);
        btnSoundOn.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1;
        btnPlay.SetActive(false);
        btnPause.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        btnPause.SetActive(false);
        btnPlay.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("ListLevel");
    }

}
