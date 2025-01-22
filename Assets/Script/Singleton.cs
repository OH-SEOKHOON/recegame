using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    //유일한 인스턴스를 저장하는 정적(static) 변수.
    //static: 모든 객체가 공유하는 전역 변수로, 하나의 값만 존재

    //Singleton 객체를 반환하거나, 없으면 생성하는 함수
    public static T Instance
    {
        get
        {
            // instance가 비어 있다면
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                //현재 씬에서 T 타입의 오브젝트를 찾는다.
            }


            // 그래도 없다면
            if (instance == null)
            {
                GameObject obj = new GameObject();
                //새 게임 오브젝트를 생성.
                
                obj.name = typeof(T).Name;
                //오브젝트의 이름을 T 타입 이름으로 설정.
                
                obj.AddComponent<T>();
                //오브젝트에 T 컴포넌트를 추가하고 instance로 저장.
            }
            
            return instance;
            //instance 반환
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    //게임이 시작될 때 특정 시점에서 호출 (씬이 로드되기 전에 실행)
    public static void OnBeforeSceneLoadRuntimeMethod()
    {
        
    }

    private void Awake()
    {
        //현재 instance가 없다면
        if (instance == null)
        {
            //이 오브젝트를 instance로 설정
            instance = this as T;
        }
		
        //추상 메서드 OnAwake()는 하위 클래스에서 구현하도록 설계
        OnAwake();
    }

    public virtual void OnAwake()
    {
    }
}
