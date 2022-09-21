using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class car_light : MonoBehaviour
{
public enum Side
    {
        Front,
        Back
    }

    [System.Serializable]
    public struct Light
    {
        public GameObject lightObj;
        public Material lightMat;
        public Side side;
    }

   // public Toggle lightToggle;

    public bool isFrontLightOn;


    public Color frontLightOnColor;
    public Color frontLightOffColor;
    public Color backLightOnColor;
    public Color backLightOffColor;

    public List<Light> lights;





    [Header("blanck")]
    [SerializeField]private GameObject blanckobj_R;
    [SerializeField]private Material blanck_idle_R;
    [SerializeField]private Material blanck_light_R;
    [SerializeField]private GameObject blanckobj_L;
    [SerializeField]private Material blanck_idle_L;
    [SerializeField]private Material blanck_light_L;



    [Header("breake")]
    [SerializeField]private GameObject breakOBJ;
    [SerializeField]private Material breakMATbright;
    [SerializeField]private Material breakMATidle;


    private bool blankR=false;
    private bool blankL=false;
    private bool isBackLightOn =false;
    private bool waringblank=false;
    
    private Material material;
    private Car_Controller car_Controller;

    void Awake()
    {
        
        //breaklight.DisableKeyword("_EMISSION");
        //backlightMat.DisableKeyword("_EMISSION");
        //backlightMat.SetColor("_EmissionColor",new Vector4(191,191,191,0));
        //breaklight.SetColor("_EmissionColor",new Vector4(191,191,191,0));
        
        //backlightMat.SetColor("_EmissionColor",new Vector4(191,191,191,0));
    }
    void Start()
    {
        car_Controller = GetComponent<Car_Controller>();
        //testCol = (Color)backlightMat.GetVector("activeColor");
        material = GetComponent<Material>();

        //isFrontLightOn = lightToggle.isOn;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            OperateFrontLights();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!blankR)
            {
                blankR=true;
            }
            else
            {
                blanckobj_L.GetComponent<Renderer>().material =blanck_idle_L;
                blankR=false;
            }

            blankL=false;
            waringblank=false;
            StartCoroutine(blank_R());
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(!blankL)
            {
                blankL=true;
            }
            else
            {
                blankL=false;
            }

            blankR=false;
            waringblank=false;
            StartCoroutine(blank_L());
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            blankL=false;
            blankR=false;
            if(!waringblank)
            {
                waringblank=true;
            }
            else
            {
                waringblank=false;
            }
            StartCoroutine(waringblankCO());
        }


        if(Input.GetKey(KeyCode.Space) || car_Controller.gear==-1)
        {
            //breaklight.SetVector("_EmissionColor",new Vector4(191,191,191,4));
            breakOBJ.GetComponent<Renderer>().material =breakMATbright;
            //breaklight.EnableKeyword("_EMISSION");
        }
        else
        {
            breakOBJ.GetComponent<Renderer>().material =breakMATidle;
            //breaklight.DisableKeyword("_EMISSION");
            //breaklight.SetColor("_EmissionColor",new Vector4(191,191,191,0)* 0);
        }

        // if(Input.GetKeyDown(KeyCode.S) || isback)
        // {   
        //     isback=true;
        //     breaklight.SetVector("_EmissionColor",new Vector4(191,191,191,4));
        // }
        // else 
        // {
        //     isback=false;
        //     breaklight.SetColor("_EmissionColor",new Vector4(191,191,191,0)* 0);
        // }

        // if(Input.GetKeyDown(KeyCode.Space) || isback)
        // {
        //     isback=true;
        //     breaklight.SetVector("_EmissionColor",new Vector4(191,191,191,4));
        // }
        // else
        // {
        //     isback=false;
        //     breaklight.SetColor("_EmissionColor",new Vector4(191,191,191,0)* 0);
        // }
        
        // if(Input.GetKeyDown(KeyCode.DownArrow) || isback)
        // {
        //     isback=true;
        //     breaklight.SetVector("_EmissionColor",new Vector4(191,191,191,4));
        // }
        // else
        // {
        //     isback=false;
        //     breaklight.SetColor("_EmissionColor",new Vector4(191,191,191,0)* 0);
        // }
    }


    public void OperateFrontLights()
    {
        isFrontLightOn = !isFrontLightOn;

        if (isFrontLightOn)
        {
            //Turn On Lights
            // foreach(var light in lights)
            // {
            //     if(light.side == Side.Front && light.lightObj.activeInHierarchy == false)
            //     {
            //         light.lightObj.SetActive(true);
            //         light.lightMat.color = frontLightOnColor;
            //     }
            // }

            //lightToggle.gameObject.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            //Turn Off Lights
            foreach (var light in lights)
            {
                if (light.side == Side.Front && light.lightObj.activeInHierarchy == true)
                {
                    light.lightObj.SetActive(false);
                    light.lightMat.color = frontLightOffColor;
                }
            }

            //lightToggle.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public void OperateBackLights()
    {
        if (isBackLightOn)
        {
            //Turn On Lights
            foreach (var light in lights)
            {
                if (light.side == Side.Back && light.lightObj.activeInHierarchy == false)
                {
                    light.lightObj.SetActive(true);
                    light.lightMat.color = backLightOnColor;
                }
            }
        }
        else
        {
            //Turn Off Lights
            foreach (var light in lights)
            {
                if (light.side == Side.Back && light.lightObj.activeInHierarchy == true)
                {
                    light.lightObj.SetActive(false);
                    light.lightMat.color = backLightOffColor;
                }
            }
        }
    }
    IEnumerator blank_R()
    {
        if(blankR)
        {
        blanckobj_R.GetComponent<Renderer>().material =blanck_light_R;
        yield return new WaitForSeconds(0.5f);
        blanckobj_R.GetComponent<Renderer>().material =blanck_idle_R;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(blank_R());
        }
    }

    IEnumerator blank_L()
    {
        if(blankL)
        {
        blanckobj_L.GetComponent<Renderer>().material =blanck_light_L;
        yield return new WaitForSeconds(0.5f);
        blanckobj_L.GetComponent<Renderer>().material =blanck_idle_L;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(blank_L());
        }
    }

    IEnumerator waringblankCO()
    {
        if(waringblank)
        {
        blanckobj_L.GetComponent<Renderer>().material =blanck_light_L;
        blanckobj_R.GetComponent<Renderer>().material =blanck_light_R;
        yield return new WaitForSeconds(0.5f);
        blanckobj_R.GetComponent<Renderer>().material =blanck_idle_R;
        blanckobj_L.GetComponent<Renderer>().material =blanck_idle_L;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(waringblankCO());
        }
    }
}
