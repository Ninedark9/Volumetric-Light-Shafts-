float RayMarching(float3 rayOrigin, float3 rayDir, float density, int stepCount, float3 lightPos, UNITY_SHADOW_COORDS(0))
{
    float stepSize = 1.0 / stepCount;
    float illumination = 0;

    for (int i = 0; i < stepCount; i++)
    {
        float distanceAlongRay = i * stepSize * 10.0;
        float3 samplePos = rayOrigin + rayDir * distanceAlongRay;

        if (samplePos.y > 5.0)
            
        float shadow = SampleShadow(_ShadowMapTexture, _ShadowCoord);

        illumination += density * shadow * stepSize;
    }

    return illumination;
}
