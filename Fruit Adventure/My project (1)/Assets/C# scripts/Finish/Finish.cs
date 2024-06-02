using System.Collections;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Animator _animator;
    private CharacterMoving _characterMoving;
    private float delayBeforeNextLevel = 2f; 

    private bool soundPlayed = false;
    public GameObject _LevelMenu; 
    public bool finish { private get; set; }

    private CharacterInfo _characterInfo;
    [SerializeField] private TextMeshProUGUI _scoreLevel;

    public int MaxScore;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;



    void Start()
    {
        _characterInfo = FindObjectOfType<CharacterInfo>();
        _animator = GetComponent<Animator>();
        _characterMoving = GetComponent<CharacterMoving>(); 
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        CharacterMoving characterMovingComponent = otherCollider.GetComponent<CharacterMoving>();
        if (characterMovingComponent != null)
        {
            finish = true;
            _characterMoving = characterMovingComponent;
            StartCoroutine(LoadNextLevelWithDelay());
        }
    }
    private IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeNextLevel);

        DisplayScore();
        _LevelMenu.SetActive(true);
        Time.timeScale = 0f;
    }




    public void DisplayScore()
    {
        int _scoreint = _characterInfo.GetScore();
        _scoreLevel.text = _scoreint.ToString();
        if (_scoreint * 0.33f <= MaxScore) 
        {
            star1.SetActive(false);
        }
        if (_scoreint * 0.66f <= MaxScore)
        {
            star1.SetActive(false);
            star3.SetActive(false);
        }
        if (_scoreint == MaxScore)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        CharacterMoving characterMovingComponent = otherCollider.GetComponent<CharacterMoving>();
        if (characterMovingComponent != null)
        {
            finish = false;
            _characterMoving = null; 
        }
    }

    

    private void Update()
    {
        _animator.SetBool("finish", finish);

        if (finish && _characterMoving != null && !soundPlayed)
        {
            _characterMoving.SoundFinish(0.5f);
            soundPlayed = true;
        }
    }

}
