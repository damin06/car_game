using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveController : MonoBehaviour
{
    [SerializeField] bool setActive;
    [SerializeField] GameObject _gameObject;
    public void SetActiveControl()
    {
        if(setActive == true)
        {
            _gameObject.SetActive(false);
            setActive = false;
        }
        else
        {
            _gameObject.SetActive(true);
            setActive = true;
        }
    }
}
