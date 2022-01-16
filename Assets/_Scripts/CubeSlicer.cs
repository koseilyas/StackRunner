using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSlicer : MonoBehaviour
{
	/// <summary>
	/// This script taken from web and modified
	/// </summary>
	public static void Slice(Transform slicingCube,Vector3 _pos, bool isLeft)
    {
        Vector3 pos = new Vector3(_pos.x, slicingCube.position.y, slicingCube.position.z);
        Vector3 slicingCubeScale = slicingCube.localScale;
        float distance = Vector3.Distance(slicingCube.position, pos);
        if (distance >= slicingCubeScale.x / 2) 
	        return;
		
        Vector3 leftPoint = slicingCube.position - Vector3.right * slicingCubeScale.x/2;
        Vector3 rightPoint = slicingCube.position + Vector3.right * slicingCubeScale.x/2;
        Material mat = slicingCube.GetComponent<MeshRenderer>().material;

        if (!isLeft)
        {
	        GameObject rightObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
	        rightObj.transform.position = (rightPoint + pos) /2;
	        float rightWidth = Vector3.Distance(pos,rightPoint);
	        rightObj.transform.localScale = new Vector3( rightWidth ,slicingCubeScale.y ,slicingCubeScale.z );
	        
	        var rb = rightObj.AddComponent<Rigidbody>();
	        rb.mass = 1f;
	        rb.AddForce(Vector3.right*150);
	        rightObj.GetComponent<MeshRenderer>().material = mat;
	        Destroy(rightObj,5);
	        
	        slicingCube.transform.position = (leftPoint + pos)/2;
	        float leftWidth = Vector3.Distance(pos,leftPoint);
	        slicingCube.transform.localScale = new Vector3( leftWidth ,slicingCubeScale.y ,slicingCubeScale.z );
        }

        if (isLeft)
        {
	        GameObject leftObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
	        leftObj.transform.position = (leftPoint + pos)/2;
	        float leftWidth = Vector3.Distance(pos,leftPoint);
	        leftObj.transform.localScale = new Vector3( leftWidth ,slicingCubeScale.y ,slicingCubeScale.z );
	        
	        var rb = leftObj.AddComponent<Rigidbody>();
	        rb.mass = 1f;
	        rb.AddForce(Vector3.left*150);
	        leftObj.GetComponent<MeshRenderer>().material = mat;
	        Destroy(leftObj,5);
	        
	        slicingCube.transform.position = (rightPoint + pos) /2;
	        float rightWidth = Vector3.Distance(pos,rightPoint);
	        slicingCube.transform.localScale = new Vector3( rightWidth ,slicingCubeScale.y ,slicingCubeScale.z );
        }
    }
}
