using UnityEngine;

public class AutoCreateWater : MonoBehaviour
{
    [Header("Cài đặt kích thước nước")]
    [Tooltip("Khoảng cách từ tâm lu lên đến mặt nước")]
    public float waterHeight = 0.5f; 
    
    [Tooltip("Độ rộng của mặt nước")]
    public float waterRadius = 0.8f; 
    
    [Header("Tùy chọn vật lý")]
    [Tooltip("Luôn giữ mặt nước nằm ngang (song song mặt đất) ngay cả khi lu bị nghiêng?")]
    public bool alwaysKeepHorizontal = true;

    [Header("Chất liệu")]
    [Tooltip("Kéo Material nước của bạn vào đây. Nếu để trống, code sẽ tự tạo.")]
    public Material waterMaterial;

    private GameObject water;

    void Start()
    {
        GenerateWaterSurface();
    }

    void GenerateWaterSurface()
    {
        water = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        water.name = "WaterSurface_Auto";
        
        Destroy(water.GetComponent<Collider>());
        
        water.transform.SetParent(transform);

        // 1. Đặt vị trí nước theo trục Y của lu
        water.transform.localPosition = new Vector3(0f, 0f, waterHeight);
        
        // 2. Ép dẹp thành mặt phẳng
        water.transform.localScale = new Vector3(waterRadius, 0.001f, waterRadius);

        // 3. Xử lý Material
        Renderer waterRenderer = water.GetComponent<Renderer>();
        if (waterMaterial != null)
        {
            waterRenderer.material = waterMaterial;
        }
        else
        {
            Material autoMat = new Material(Shader.Find("Standard"));
            autoMat.color = new Color(0.2f, 0.5f, 0.4f, 0.7f); 
            
            autoMat.SetFloat("_Mode", 3);
            autoMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            autoMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            autoMat.SetInt("_ZWrite", 0);
            autoMat.DisableKeyword("_ALPHATEST_ON");
            autoMat.EnableKeyword("_ALPHABLEND_ON");
            autoMat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            autoMat.renderQueue = 3000;
            
            waterRenderer.material = autoMat;
        }
    }

    void LateUpdate()
    {
        // 4. Giữ mặt nước luôn nằm ngang bất chấp việc lu bị nghiêng hay xoay
        if (water != null && alwaysKeepHorizontal)
        {
            // Quaternion.Euler(0, 0, 0) ép mặt phẳng luôn hướng thẳng lên trời
            water.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}