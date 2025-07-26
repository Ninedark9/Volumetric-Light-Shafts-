using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class VolumetricLightURPController : MonoBehaviour
{
    public Light directionalLight;
    [Range(0,1)] public float density = 0.5f;
    [Range(16, 64)] public int stepCount = 32;

    private Material material;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        material = rend.material;
    }

    void Update()
    {
        if (directionalLight == null)
            return;

        Vector3 lightPosWS = directionalLight.transform.position;
        material.SetVector("_LightPos", new Vector4(lightPosWS.x, lightPosWS.y, lightPosWS.z, 1));
        material.SetColor("_LightColor", directionalLight.color * directionalLight.intensity);
        material.SetFloat("_Density", density);
        material.SetInt("_StepCount", stepCount);
    }
}
