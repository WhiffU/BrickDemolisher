using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BallLauncher : MonoBehaviour
{

    public Rigidbody2D _ballPrefab;
    public GetDown getDown;

    private Vector2 _startPosition;
    private Vector3 _endPosition;
    private RowSpawner _blockSpawner;
    [SerializeField] public Slider slider;
    public GameObject Reset;
    private bool stop;

    public List<Rigidbody2D> _ballsList = new List<Rigidbody2D>();


    public bool _canMove;
    public bool _canDrag;

    private RaycastHit2D ray;
    public Rigidbody2D BallSprite;
    public Rigidbody2D ExplosiveBulletSprite;
    public Rigidbody2D LaserBallPrefab;
    public GameObject bottomWall;
    public float angleMin = 15f;
    public float angleMax = 165f;

    LayerMask layerWall;
 
    public TMP_Text ballCountText;
    public GameObject ballCountBox;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] public float Distance = 10f;
    public float angle = 0;


    [SerializeField] bool useRay;
    [SerializeField] bool useLines;
    [SerializeField] bool useDots;
    [SerializeField] LineRenderer lineRenderer;
    public int BallCount;
    public int BallCountDefault;
    private bool PointerDown;
    public bool isDoubleUsed = false;
    public bool isExplosiveUsed = false;
    public bool isFreezingUsed = false;

    [SerializeField] private bool shootable;

 
    private void Awake()
    {
        _blockSpawner = FindObjectOfType<RowSpawner>();
        _canMove = true;
        _canDrag = false;
    }

    private void Start()
    {
        ballCountText.text = BallCount + " xBalls";
        layerWall = LayerMask.GetMask("Wall");
        BallCount = BallCountDefault;
 
    }
    public void EndDrag()
    {

        if (angle >= angleMin && angle <= angleMax)
        {
            StartCoroutine(LaunchBalls());

        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
    public void ReturnBall()
    {
        GetDown.Move = true;
        _canMove = true;
        _canDrag = true;
        _ballsList.Clear();
        ballCountText.text = BallCount + " xBalls";
        ballCountBox.SetActive(true);
        if (isDoubleUsed == true)
        {
            BallCount = BallCount / 2;
            ballCountText.text = BallCount.ToString() + "x";
            isDoubleUsed = false;
        }
        if (isExplosiveUsed == true)
        {
            isExplosiveUsed = false;
        }
        if (isFreezingUsed==true)
        {
            isFreezingUsed = false;
        }
        Reset.SetActive(false);
        itemSlot.SetActive(true);

    }
    [SerializeField] private GameObject itemSlot;
    public IEnumerator LaunchBalls()
    {
        FindObjectOfType<AudioManager>().Play("Launch");
        slider.value = 90;
        slider.transform.gameObject.SetActive(false);
        itemSlot.SetActive(false);
        _canMove = false;
        ballCountText.text = "";
        ballCountBox.SetActive(false);

        Vector2 direction = ray.point - _startPosition;
        _ballsList.Clear();
        getDown.newPos = new Vector2(getDown.transform.position.x, getDown.transform.position.y - 1f);
        direction.Normalize();
        stop = false;
        for (int i = 0; i < BallCount; i++)
        {
            yield return new WaitForSeconds(0.08f);
            if (stop == true)
            {
                break;
            }
            Rigidbody2D myinst = Instantiate(_ballPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            _ballsList.Add(myinst);
            myinst.AddForce(transform.right * 5f);
        }
        Reset.SetActive(true);
    }
   

    public void StartDrag()
    {
        _canDrag = false;
        _startPosition = this.transform.position;

    }
    public void PointerD()
    {
        PointerDown = true;
     }
    public void PointerUp()
    {
        PointerDown = false;
    }
    public void ContinueDrag(Vector3 worldPosition2)
    {
        _endPosition = worldPosition2;
    }
    public void ContinueDragSlider(Vector3 worldPosition1)
    {

        ray = Physics2D.Raycast(transform.position, transform.right, 15f, layerWall);
        ray.point = worldPosition1;
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void Update()
    {
        //Avoid UI CLICK 
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    return;
        //}
        if (!_canMove) return;

        if (PointerDown == true)
        {

            ray = Physics2D.Raycast(transform.position, transform.right, 15f, layerWall);
            Vector2 reflectPos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            Dots.instance.DrawDottedLine(transform.position, ray.point);
            Dots.instance.DrawDottedLine(ray.point, ray.point + reflectPos.normalized * 2f);
            angle = 180f - slider.value;
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
            Vector3 worldPosition1 = ray.point;
            if (PointerDown == false)
            {
                ContinueDragSlider(worldPosition1);
                EndDrag();
            }
            //Debug.DrawRay(transform.position, worldPosition1, Color.red);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                if (IsPointerOverUIObject())
                {
                    angle = 180f;
                    return;
                }
                ray = Physics2D.Raycast(transform.position, transform.right, 15f, layerWall);
                Vector2 reflectPos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                if (angle >= 15 && angle <= 165)
                {

                    if (useRay)
                    {
                        Debug.DrawRay(transform.position, transform.right * ray.distance, Color.red);
                        Debug.DrawRay(ray.point, reflectPos.normalized * 2f, Color.green);
                    }
                    if (useLines)
                    {
                        lineRenderer.SetPosition(0, transform.position);
                        lineRenderer.SetPosition(1, ray.point);
                        lineRenderer.SetPosition(2, ray.point + reflectPos.normalized * 2f);
                    }
                    if (useDots)
                    {
                        Dots.instance.DrawDottedLine(transform.position, ray.point);
                        Dots.instance.DrawDottedLine(ray.point, ray.point + reflectPos.normalized * 2f);
                    }
                }
                transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
                Vector3 worldPosition2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ContinueDrag(worldPosition2);
                //Debug.DrawRay(transform.position, worldPosition2, Color.green);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                EndDrag();
            }
        }
    }
    public void ResetBall()
    {
        stop = true;

        foreach (var go in _ballsList)
        {
            if (go != null)
            {
                Debug.Log("Reset ball!");
                go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                go.transform.position = Vector2.MoveTowards(transform.position, bottomWall.transform.position, 5f);
            }
        }
    }

}
