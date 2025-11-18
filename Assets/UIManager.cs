using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private uint selectedOption = 0;
    [SerializeField] private MenuOptions[] options;

    private void Awake()
    {
       if (!Instance)
        {
            Instance = this;
        }
       else
        {
            Destroy(gameObject);
        }
    }

}
