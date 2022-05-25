using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWithMouse : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Shader drawShader;

    RenderTexture splatMap;
    Material currentMaterial, drawMaterial;
    RaycastHit hit;

    [SerializeField] [Range(1,500)] float size;
    [SerializeField] [Range(0,1)] float strength;

    void Start()
    {
        drawMaterial = new Material(drawShader);
        drawMaterial.SetVector("_Color",Color.red);

        currentMaterial = GetComponent<MeshRenderer>().material;

        splatMap = new RenderTexture(1024,1024,0,RenderTextureFormat.ARGBFloat);
        currentMaterial.SetTexture("SplatMap",splatMap);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),out hit))
            {
                Debug.Log(hit.transform.name);
                drawMaterial.SetVector("_Coordinates",new Vector4(hit.textureCoord.x,hit.textureCoord.y,0,0));
                drawMaterial.SetFloat("_Strebgrh",strength);
                drawMaterial.SetFloat("_Size",size);
                RenderTexture temp = RenderTexture.GetTemporary(splatMap.width,splatMap.height,0,RenderTextureFormat.ARGBFloat);
                Graphics.Blit(splatMap,temp);
                Graphics.Blit(temp,splatMap,drawMaterial);
                RenderTexture.ReleaseTemporary(temp);
            }
        }
        
    }
}
