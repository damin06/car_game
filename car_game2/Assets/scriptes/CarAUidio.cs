using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    public AudioSource Engine;
    public Car_Controller car_controller;

    public AudioSource GearChangeSound;


    public float PitchOffSet1;
    public float PitchOffSet2;
    public float PitchOffSet3;
    public float PitchOffSet4;
    public float PitchOffSet5;
    public float PitchOffSet6;

    void Start()
    {
        car_controller = GetComponent<Car_Controller>();
    }

    void Update()
    {
        PitchControl();
        GearChange();
        EngineVolume();
    }


    public void EngineVolume()
    {

            if (Input.GetAxis("Vertical") == 1)
            {
                Engine.volume += Time.deltaTime;
            }
            else
            {
                if (Engine.volume > 0.1f)
                {
                    Engine.volume -= Time.deltaTime;
                }
            }      

    }

    public void GearChangeSounds()
    {
        if(GearChangeSound.isPlaying == false)
            {
                GearChangeSound.Play();
            }
    }
    public void GearChange()
    {
        if (car_controller.gear==1)
        {
            if(GearChangeSound.isPlaying == false)
            {
                GearChangeSound.Play();
            }
        }

        if (car_controller.gear==2)
        {
            if (GearChangeSound.isPlaying == false)
            {
                GearChangeSound.Play();
            }
        }

        if (car_controller.gear==3)
        {
            if (GearChangeSound.isPlaying == false)
            {
                GearChangeSound.Play();
            }
        }

        if (car_controller.gear==4)
        {
            if (GearChangeSound.isPlaying == false)
            {
                GearChangeSound.Play();
            }
        }

        if (car_controller.gear==5)
        {
            if (GearChangeSound.isPlaying == false)
            {
                GearChangeSound.Play();
            }
        }

        if (car_controller.gear==6)
        {
            if (GearChangeSound.isPlaying == false)
            {
                GearChangeSound.Play();
            }
        }
    }

    public void PitchControl()
    {
        if (car_controller.currentSpeed > 0 & car_controller.currentSpeed < 30)
        {
            Engine.pitch =car_controller.currentSpeed * PitchOffSet1;
        }

        if (car_controller.currentSpeed > 30 & car_controller.currentSpeed < 60)
        {
            Engine.pitch = car_controller.currentSpeed * PitchOffSet2;
        }

        if (car_controller.currentSpeed > 60 &car_controller.currentSpeed < 90)
        {
            Engine.pitch = car_controller.currentSpeed * PitchOffSet3;
        }

        if (car_controller.currentSpeed > 90 & car_controller.currentSpeed < 120)
        {
            Engine.pitch = car_controller.currentSpeed * PitchOffSet4;
        }

        if (car_controller.currentSpeed > 120 & car_controller.currentSpeed< 150)
        {
            Engine.pitch = car_controller.currentSpeed * PitchOffSet5;
        }

        if (car_controller.currentSpeed > 150)
        {
            Engine.pitch = car_controller.currentSpeed* PitchOffSet6;
        }
    }


}