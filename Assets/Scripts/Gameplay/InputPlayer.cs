using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private CatcherManager _catcher;
    private Camera _camera;
    private RaycastHit _hit;


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        CheckClickByFish();
    }

    private void CheckClickByFish()
    {
        if (((Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit) && EventSystem.current.IsPointerOverGameObject() == false)
            {
                Fish fish = _hit.transform.gameObject?.GetComponent<Fish>();
                if (fish == null) return;

                _catcher.Catch(fish);
            }
        }
    }

}
