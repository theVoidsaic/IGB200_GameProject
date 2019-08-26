using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public GameObject tower;

    //public bool RotateAround = false;
    //public Transform ObjTransform;

    //[Range(0.01f,1.0f)]
    //public float SmoothFactor = 0.5f;
    //public float RotationSpeed = 5.0f;

    //private Vector3 _camOffSet;

    void Start()
    {
        //_camOffSet = transform.position - ObjTransform.position;

        // 

        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;

        //


        if (tower == null)
        {
            tower = GameObject.FindGameObjectWithTag("Player");
            tower.SetActive(false);
        }
    }

    /// <summary>
    /// Legacy code section for further studies
    /// </summary>
        //void LateUpdate()
    //{
    //    if (RotateAround)
    //    {
    //        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

    //        _camOffSet = camTurnAngle * _camOffSet;
    //    }

    //    Vector3 newPos = ObjTransform.position + _camOffSet;
    //    transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

    //    if (RotateAround)
    //    {
    //        transform.LookAt(ObjTransform);
    //    }
    //}

    ////////////////

    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 10f;

    public float MouseSensitivity = 4f;
    [Range(0.01f,3.0f)]
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool CameraDisabled = false;
        
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            CameraDisabled = !CameraDisabled;

        if (!CameraDisabled)
        {
            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

                //Clamp the y Rotation to horizon and not flipping over at the top
                if (_LocalRotation.y < 0f)
                    _LocalRotation.y = 0f;
                else if (_LocalRotation.y > 90f)
                    _LocalRotation.y = 90f;
            }
            //Zooming Input from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

                ScrollAmount *= (this._CameraDistance * 0.3f);

                this._CameraDistance += ScrollAmount * -1f;

                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);
            }
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50.0f))
            {
                if (hit.transform != null)
                {
                    Debug.Log(hit.transform.gameObject.name);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            tower.SetActive(true);
        }
    }
}
