using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.EventSystems;

public class BallLauncher : MonoBehaviour
{

    [SerializeField] public GameObject _ballPrefab;
    public GameObject TargetParent;
    private Vector2 _startPosition;
    private Vector3 _endPosition;
    private RowSpawner _blockSpawner;
    [SerializeField] public Slider slider;
    public GameObject Reset;
    private bool stop;

    public List<GameObject> _ballsList = new List<GameObject>();


    public bool _canMove;
    public bool _canDrag;

    private RaycastHit2D ray;
    public GameObject BallSprite;
    public GameObject ExplosiveBulletSprite;

    public float angleMin = 20f;
    public float angleMax = 160f;

    LayerMask layerWall;
    LayerMask visualBallLayer;

    public TMP_Text ballCountText;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] public float Distance = 10f;
    [SerializeField] Vector2 minMaxAngle;
    public float angle = 0;


    [SerializeField] bool useRay;
    [SerializeField] bool useLines;
    [SerializeField] bool useDots;
    [SerializeField] LineRenderer lineRenderer;
    public int BallCount;
    public int BallCountDefault;
    private bool PointerDown;
    private bool isDoubleUsed = false;
    private bool isExplosiveUsed = false;
    [SerializeField] private bool shootable;

    private void Awake()
    {
        _blockSpawner = FindObjectOfType<RowSpawner>();
        _canMove = true;
        _canDrag = false;
    }

    private void Start()
    {
        ballCountText.text = BallCount + "x";
        layerWall = LayerMask.GetMask("Wall");
        this.spriteRenderer = GetComponent<SpriteRenderer>();
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

        _canMove = true;
        _canDrag = true;
        GetDown.Move = true;
        slider.transform.gameObject.SetActive(true);
        _ballsList.Clear();
        ballCountText.text = BallCount + "x";
        //BallCount = 10;
        DoubleBall.gameObject.SetActive(true);
        ExplosiveBall.gameObject.SetActive(true);
        if (isDoubleUsed == true)
        {
            DoubleBall.gameObject.SetActive(false);
            BallCount = BallCount / 2;
            ballCountText.text = BallCount.ToString() + "x";
            isDoubleUsed = false;
        }
        if (isExplosiveUsed == true)
        {
            ExplosiveBall.gameObject.SetActive(false);
        }
        Reset.SetActive(false);


    }
    public IEnumerator LaunchBalls()
    {

        slider.value = 90;
        slider.transform.gameObject.SetActive(false);
        DoubleBall.gameObject.SetActive(false);
        ExplosiveBall.gameObject.SetActive(false);
        _canMove = false;
        ballCountText.text = "";
        Vector2 direction = ray.point - _startPosition;
        _ballsList.Clear();
        TargetParent.GetComponent<GetDown>().newPos = new Vector2(TargetParent.transform.position.x, TargetParent.transform.position.y - 1f);
        direction.Normalize();
        stop = false;
        for (int i = 0; i < BallCount; i++)
        {
            yield return new WaitForSeconds(0.08f);
            if (stop == true)
            {
                break;
            }
            GameObject myinst = Instantiate(_ballPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            _ballsList.Add(myinst);
            myinst.GetComponent<Rigidbody2D>().AddForce(transform.right * 5f);
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
                if (angle >= 20 && angle <= 160)
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

    [SerializeField] public GameObject DoubleBall;


    public void DoubleBallPowerUp()
    {
        if (isDoubleUsed == false)
        {
            BallCount = BallCount * 2;
            ballCountText.text = BallCount + "x";
            DoubleBall.gameObject.SetActive(false);
            ExplosiveBall.gameObject.SetActive(false);
            isDoubleUsed = true;
        }

    }

    [SerializeField] GameObject ExplosiveBall;
    public SpriteRenderer spriteRenderer;


    public void ExplosivePowerUp()
    {
        if (isExplosiveUsed == false)
        {
            spriteRenderer.color = Color.red;
            _ballPrefab = ExplosiveBulletSprite;
            BallCount = 1;
            ballCountText.text = BallCount + "x";
            ExplosiveBall.gameObject.SetActive(false);
            DoubleBall.gameObject.SetActive(false);
            isExplosiveUsed = true;
        }
    }

    public GameObject bottomWall;



    public void ResetBall()
    {
        stop = true;

        foreach (GameObject go in _ballsList)
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
