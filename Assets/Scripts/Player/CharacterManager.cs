using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;

    public static CharacterManager Instance
    {
        get
        {
            // _instance가 null인 경우 새로운 CharacterManager 게임 오브젝트를 생성하고, CharacterManager 스크립트 컴포넌트를 추가
            if (_instance == null)
            {
                _instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return _instance;
        }
    }
    public Player _player;

    public Player Player
    {
        // Player를 반환하는 속성
        get { return _player; }
        // Player를 설정하는 속성
        set {  _player = value; }
    }

    private void Awake()
    {
        // 싱글톤 패턴을 사용하여 인스턴스를 초기화
        if (_instance == null)
        {
            _instance = this;
            // 이 게임 오브젝트가 로드된 씬이 변경되어도 파괴되지 않도록 설정
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 이미 인스턴스가 존재하는 경우, 이 게임 오브젝트를 파괴
            if (_instance == this)
            {
                Destroy(gameObject);
            }
        }
    }
}
