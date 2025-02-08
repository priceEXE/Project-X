using UnityEngine;

public class MousePositionManager : MonoBehaviour
{
    // 单例实例
    private static MousePositionManager _instance;
    
    // 主相机缓存（优化性能）
    private Camera _mainCamera;
    
    // 公共访问点
    public static MousePositionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MousePositionManager instance not found! Please ensure one exists in the scene.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // 单例模式初始化
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        Initialize();
    }

    private void Initialize()
    {
        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.LogError("Main camera not found! Please ensure your scene has a camera tagged as MainCamera.");
        }
    }

    /// <summary>
    /// 获取当前鼠标的世界坐标（适用于2D）
    /// </summary>
    public Vector2 MouseWorldPosition
    {
        get
        {
            if (_mainCamera == null) return Vector2.zero;
            
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -_mainCamera.transform.position.z; // 适配正交相机的深度值
            return _mainCamera.ScreenToWorldPoint(mousePos);
        }
    }

    /// <summary>
    /// 获取鼠标位置的屏幕坐标
    /// </summary>
    public Vector2 MouseScreenPosition => Input.mousePosition;

    /// <summary>
    /// 判断鼠标是否在游戏窗口内
    /// </summary>
    public bool IsMouseInGameWindow
    {
        get
        {
            Vector2 mousePos = Input.mousePosition;
            return !(mousePos.x < 0 || mousePos.y < 0 || 
                   mousePos.x > Screen.width || 
                   mousePos.y > Screen.height);
        }
    }
}

/// <summary>
/// 单例使用方法
/// 
/// 获取鼠标世界坐标
/// Vector2 currentMousePos = MousePositionManager.Instance.MouseWorldPosition;

/// 获取屏幕坐标
/// Vector2 screenPos = MousePositionManager.Instance.MouseScreenPosition;

/// 检查鼠标是否在窗口内
/// if(MousePositionManager.Instance.IsMouseInGameWindow)
/// {
/// 执行操作
/// }
/// </summary>
