using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text _platformSumText;
    private int _platformSum;

    [SerializeField] TMP_Text _levelText;

    [SerializeField] GameObject _BGPanel;

    private string _sceneName;
    private string _level;

    private void Start()
    {
        _platformSum = 0;

        //Предполагаются реглавментированные названия. {level}_level
        _sceneName = SceneManager.GetActiveScene().name;


        _level = _sceneName[0].ToString();
        if (_sceneName[1] != '_')
            _level += _sceneName[1];

        if (_levelText != null)
            _levelText.text = "Level " + _level;



    }

    //для тестирования
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            AddPlatformSum();
    }

    #region API
    public void AddPlatformSum()
    {
        _platformSum++;
        if (_platformSumText != null)
            _platformSumText.text = _platformSum.ToString();
    }

    public void OpenCloseWindow(GameObject window)
    {
        _BGPanel.SetActive(!_BGPanel.activeSelf);
        window.SetActive(!window.activeSelf);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadNextLevel()
    {
        int levelSum = int.Parse(_level) + 1;

        string nextScene = _sceneName.Trim(_level.ToCharArray());
        nextScene = nextScene.Insert(0, levelSum.ToString());

        SceneManager.LoadScene(nextScene);

    }

    #endregion
}
