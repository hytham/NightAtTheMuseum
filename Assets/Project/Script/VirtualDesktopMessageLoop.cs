using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VirtualDesktop.Draw
{
	public class VirtualDesktopDrawer
	{

		private const string TAG = "UIElemnsts";
		 /// <summary>
		 /// Take a URL Parameterstring and execute its content based on it
		 /// </summary>
		 /// <param name="render_parameters"></param>
		public static void Render(string render_parameters)
		{

		}


		#region Shape Commands

		/// <summary>
		/// Render a box in the 3d scene
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="sx"></param>
		/// <param name="sy"></param>
		/// <param name="sz"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public static void RenderBox(string name, float x, float y, float z, float rx, float ry, float rz, float sx, float sy, float sz, float r, float g, float b)
		{
			GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
			o.name = name;
			o.transform.position = new Vector3(x, y, z);
			o.transform.Rotate(rx, ry, rz);
			o.transform.localScale = new Vector3(sx, sy, sz);
			o.GetComponent<Renderer>().material.color = new Color(r, g, b);

			o.tag = TAG;
		}

		/// <summary>
		/// Render a ball 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="sx"></param>
		/// <param name="sy"></param>
		/// <param name="sz"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public static void RenderBall(string name, float x, float y, float z, float rx, float ry, float rz, float sx, float sy, float sz, float r, float g, float b)
		{
			GameObject o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			o.name = name;
			o.transform.position = new Vector3(x, y, z);
			o.transform.Rotate(rx, ry, rz);
			o.transform.localScale = new Vector3(sx, sy, sz);
			o.GetComponent<Renderer>().material.color = new Color(r, g, b);
			o.tag = TAG;

		}

		 /// <summary>
		 /// Render a 3d sgape
		 /// </summary>
		 /// <param name="name"></param>
		 /// <param name="Vertex"></param>
		 /// <param name="UV_MaterialDisplay"></param>
		 /// <param name="Triangles"></param>
		 /// <param name="x"></param>
		 /// <param name="y"></param>
		 /// <param name="z"></param>
		 /// <param name="r"></param>
		 /// <param name="g"></param>
		 /// <param name="b"></param>
		public static void RenderShape (string name,List<Vector3> Vertex, List<Vector2> UV_MaterialDisplay, List<int> Triangles, Vector3 org,Color C)
		{
			GameObject o = new GameObject();
		    Mesh mesh = new Mesh();
			o.transform.GetComponent<MeshFilter>();
			if (!o.transform.GetComponent<MeshFilter>() || !o.transform.GetComponent<MeshRenderer>()) 
			{
				o.transform.gameObject.AddComponent<MeshFilter>();
				o.transform.gameObject.AddComponent<MeshRenderer>();
			}

			o.transform.GetComponent<MeshFilter>().mesh = mesh;

			mesh.name = name + " - mesh";
			mesh.vertices = Vertex.ToArray(); 
			mesh.triangles = Triangles.ToArray();
			mesh.uv = UV_MaterialDisplay.ToArray();	
			mesh.RecalculateNormals();
			o.GetComponent<MeshRenderer>().material.color = new Color(C.r, C.g, C.b,1);

			o.transform.position = org;
			
		}


		/// <summary>
		/// Draw a filled Rectangle
		/// </summary>
		/// <param name="name"></param>
		/// <param name="P1"></param>
		/// <param name="P2"></param>
		/// <param name="P3"></param>
		/// <param name="Org"></param>
		/// <param name="C"></param>
		public static  void RenderFilledTriangle(string name,Vector3 P1,Vector3 P2,Vector3 P3,Vector3 Org,Color C)
		{
			VirtualDesktopDrawer.RenderShape(name, new List<Vector3> {
				 P1,
				 P2,
				 P3
		}, new List<Vector2> {
			   new Vector2(1,0),
			   new Vector2(1,0),
			   new Vector2(1,0)
		}, new List<int> {
		   1,2,3
		}, Org, C);
		}

		/// <summary>
		/// Drawa filled circule
		/// </summary>
		/// <param name="name"></param>
		/// <param name="Center"></param>
		/// <param name="Rad"></param>
		/// <param name="C"></param>
		public static void RenderFilledCircule(string name,Vector3 Center,Color C,int Rad)
		{ float theta = 0;
			List<Vector3> p = new List<Vector3>();
			List<Vector2> uv = new List<Vector2>();
			List<int> t = new List<int>();
			for (int i = 0; i < 300; i++)
			{
				theta += (2.0f * Mathf.PI * 1);
				float x = Rad * Mathf.Cos(theta);
				float y = Rad * Mathf.Sin(theta);
				p.Add(new Vector3(Center.x + x, Center.y + y, Center.z));
				uv.Add(new Vector2(1, 0));
				t.Add(i);
			}

			RenderShape(name, p, uv, t, Center, C);
		}

		/// <summary>
		/// Render a text
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="a"></param>
		/// <param name="fr"></param>
		/// <param name="fg"></param>
		/// <param name="fb"></param>
		/// <param name="fa"></param>
		/// <param name="text"></param>
		/// <param name="fontname"></param>
		/// <param name="fontsize"></param>
		/// <param name="fontawait"></param>
		public static void RenderText(string name, float x, float y, float z, float rx, float ry, float rz, float r, float g, float b, float fr, float fg, float fb, float fa, string text, string fontname, int fontsize, string fontawaitfontstyle)
		{
			GameObject o = new GameObject();
			o.name = name;
			o.transform.position = new Vector3(x, y, z);
			o.transform.Rotate(rx, ry, rz);
			o.transform.localScale = new Vector3(0, 0, 0);
			o.AddComponent<MeshRenderer>();
			o.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
			o.tag = TAG;

			TextMesh m = o.AddComponent<TextMesh>();
			m.text = text;
			m.fontSize = fontsize;
			m.color = new Color(fr, fg, fb, fa);

			
		}

		/// <summary>
		/// Render an Image
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="sx"></param>
		/// <param name="sy"></param>
		/// <param name="sz"></param>
		/// <param name="circule"></param>
		/// <param name="image64"></param>
		public static  void RenderImage(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float sy, float sz, bool circule, string image64)
		{
			GameObject o = GameObject.CreatePrimitive(PrimitiveType.Plane);

			o.tag = TAG;
		}
		  /// <summary>
		  /// Render an image from its row bytes
		  /// </summary>
		  /// <param name="id"></param>
		  /// <param name="x"></param>
		  /// <param name="y"></param>
		  /// <param name="z"></param>
		  /// <param name="rx"></param>
		  /// <param name="ry"></param>
		  /// <param name="rz"></param>
		  /// <param name="sx"></param>
		  /// <param name="sy"></param>
		  /// <param name="sz"></param>
		  /// <param name="circule"></param>
		  /// <param name="imagebin"></param>
		public static void RenderImage(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float sy, float sz, bool circule, Byte[] imagebin
			)
		{
			GameObject o = GameObject.CreatePrimitive(PrimitiveType.Plane);

			o.tag = TAG;
		}

		/// <summary>
		/// Render a Rectangle
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="sx"></param>
		/// <param name="sy"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public static void RenderRectangle(string name, float x, float y, float z, float w, float h, float ry, float rx, float rz,float r, float g, float b)
		{

			Vector3[] p = new Vector3[5];
			p[0] = new Vector3(x, y, z);
			p[1] = new Vector3(x+w, y, z);
			p[2] = new Vector3(x+ w, y+h, z);
			p[3] = new Vector3(x , y + h, z);
			p[4] = new Vector3(x, y , z);
			RenderPolyline(name,new List<Vector3>(), rx, ry, rz, r, g, b);
		}

		
		/// <summary>
		/// Draw a Circule
		/// </summary>
		/// <param name="name"></param>
		/// <param name="sx"></param>
		/// <param name="sy"></param>
		/// <param name="sz"></param>
		/// <param name="radius"></param>
		/// <param name="theta_scale"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public static void RenderCircule(string name, float sx, float sy, float sz,float rx,float ry,float rz, float radius, float theta_scale,float theta , float r, float g, float b,Boolean fill)
		{
			
			List<Vector3> p = new List<Vector3>();	
			for (int i = 0; i < p.Count; i++)
			{
				theta += (2.0f * Mathf.PI * theta_scale);
				float x = radius * Mathf.Cos(theta);
				float y = radius * Mathf.Sin(theta); 
				p.Add(new Vector3(sx+x,sy+y,sz));
			}
			RenderPolyline(name, p, rx, ry, rz, r, g, b);
			
			
		}

		/// <summary>
		/// Render a line
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="sx"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public static void RenderLine(string name, float x, float y, float z, float rx, float ry, float rz, float sx, float r, float g, float b)
		{

			GameObject myLine = new GameObject();
			myLine.tag = TAG;
			myLine.name = name;
			myLine.transform.position = new Vector3(x,y,z);
			myLine.AddComponent<LineRenderer>();
			LineRenderer lr = myLine.GetComponent<LineRenderer>();
			lr.material.color = new Color(r, g, b);
			lr.startWidth = lr.endWidth = 0.01f;
			
			
			lr.SetPosition(0, new Vector3(x,y,z));
			lr.SetPosition(1, new Vector3(rx,ry,rz));
			
		}
		

		/// <summary>
		/// Render a point
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		public static void RenderPoint(string name, float x, float y, float z, float r, float g, float b) {
			GameObject myLine = new GameObject();
			myLine.tag = TAG;
			myLine.name = name;
			myLine.transform.position = new Vector3(x, y, z);
			myLine.AddComponent<LineRenderer>();
			LineRenderer lr = myLine.GetComponent<LineRenderer>();
			lr.material.color = new Color(r, g, b);
			lr.startWidth = 0.01f;
			lr.endWidth = 0.01f; 
			lr.SetPosition(0, new Vector3(x, y, z)); 
		}

		/// <summary>
		/// Render area
		/// </summary>
		/// <param name="id"></param>
		/// <param name="points"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="fill"></param>
		public static void RenderPolyline(string name, List<Vector3> points, float rx, float ry, float rz, float r, float g, float b) {
			GameObject myLine = new GameObject();
			myLine.tag = TAG;
			myLine.name = name;
			myLine.transform.position = new Vector3(rx, ry,rz);
			myLine.AddComponent<LineRenderer>();
			LineRenderer lr = myLine.GetComponent<LineRenderer>();
			lr.material.color = new Color(r, g, b);
			lr.startWidth = 0.01f;
			lr.endWidth = 0.01f;
			int size = points.Count;

			lr.numPositions = size;
			
			for (int i = 0; i < size; i++)
			{  
				lr.SetPosition(i, new Vector3(rx + points[i].x, ry + points[i].y, rz + points[i].z));
			}

			

			
		}
		/// <summary>
		/// Clear all UIElement Object from the scene
		/// </summary>
		public static void ClearAll() {
			var o = GameObject.FindGameObjectsWithTag(TAG);
			foreach(var x in o)
			{
				GameObject.Destroy(x);
			}
		}

		/// <summary>
		/// Set new Origen for the user
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		void SetOrigin(float x, float y, float z) {
			
		}

		/// <summary>
		/// Remove a game object from the scene
		/// </summary>
		/// <param name="id"></param>
		public static void Remove(string name) {
			GameObject.Destroy(GameObject.Find(name));
		}

		/// <summary>
		/// Move an Object with id to a new location
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public static void Move(string name, float x, float y, float z) { GameObject.Find(name).transform.Translate(x, y, z); }

		/// <summary>
		/// Rotate an Object with a specific angle
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public static void Rotate(string id, float x, float y, float z) { GameObject.Find(id.ToString()).transform.Rotate(x, y, z); }

		/// <summary>
		/// Scale an Object
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public static void Scale(string id, float x, float y, float z) { GameObject.Find(id.ToString()).transform.localScale = new Vector3(x, y, z); }
	
		#endregion

	}
}

