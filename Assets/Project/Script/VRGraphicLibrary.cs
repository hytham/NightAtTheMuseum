using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace VRGraphicLib
{
	/// <summary>
	/// Send VRAR commands to the VRDisplayServer
	/// </summary>
    public class VRGraphicLibrary
    {
		/// <summary>
		/// Constract the string to send
		/// </summary>
		/// <param name="cmd">Cmd.</param>
		/// <param name="D">D.</param>
		public static String Send(string cmd, Dictionary<string, string> D){

			string StringBuilde = "";
			D.Add("name",cmd);
			foreach (var x in D) {
				StringBuilde += (x.Key + "=" + x.Value);
			}
				
			return StringBuilde;

		}
		#region Drawing commands
		/// <summary>
		/// Render a 3d box
		/// </summary>
		/// <param name="id">The id of the shape </param>
		/// <param name="x">X Location in 3d space</param>
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
		public static string  RenderBox(string id,float x,float y,float z,float rx,float ry,float rz,float sx,float sy,float sz,float r,float g,float b)
		{
			
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());

			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

			D.Add("size.x", sx.ToString());
			D.Add("size.y", sy.ToString());
			D.Add("size.z", sz.ToString());

			D.Add("color.r", r.ToString());
			D.Add("color.g", g.ToString());
			D.Add("color.b", b.ToString());
			D.Add("color.a", "1");

			D.Add("id", id);

			return Send("box", D);

		}

		/// <summary>
		/// Render a 3d ball
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
		public static string  RenderBall(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float sy, float sz, float r, float g, float b)
		{

			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());

			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

			D.Add("size.x", sx.ToString());
			D.Add("size.y", sy.ToString());
			D.Add("size.z", sz.ToString());

			D.Add("color.r", r.ToString());
			D.Add("color.g", g.ToString());
			D.Add("color.b", b.ToString());

			D.Add("id", id);

			return Send("ball", D);

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
		public static string  RenderText(string id, float x, float y, float z, float rx, float ry, float rz,  float r, float g, float b,float a, float fr, float fg, float fb, float fa, string text,string fontname,int fontsize,string fontawait)
		{

			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());

			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

		

			D.Add("background.r", r.ToString());
			D.Add("background.g", g.ToString());
			D.Add("background.b", b.ToString());
			D.Add("background.a", a.ToString());

			D.Add("forground.r", fr.ToString());
			D.Add("forground.g", fg.ToString());
			D.Add("forground.b", fb.ToString());
			D.Add("forground.a", fa.ToString());



			D.Add("font.name", fontname);
			D.Add("font.size", fontsize.ToString());
			D.Add("font.weight", fontawait);

			D.Add("text", text);

			D.Add("id", id);

			return Send("text", D);

		}

		/// <summary>
		/// Render a an Image
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
		/// <param name="image64"></param>
		public static string RenderImage(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float sy,float sz,bool circule, String image64 )
		{

			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());
			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

			D.Add("size.x", sx.ToString());
			D.Add("size.y", sy.ToString());
			D.Add("size.z", sz.ToString());

			D.Add("circule", circule.ToString()); // render the image ina circule prinative (true) or cube prinative	 (false) 
			

			D.Add("image", image64);
			

			D.Add("id", id);

			return Send("img", D);

		}


		public static string RenderPlaneImage(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float sy,  String image64)
		{
			bool circule = false;
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());
			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

			D.Add("size.x", sx.ToString());
			D.Add("size.y", sy.ToString());
			D.Add("size.z", "0");
			D.Add("circule", circule.ToString()); // render the image ina circule prinative (true) or cube prinative	 (false) 


			D.Add("image", image64);


			D.Add("id", id);

			return Send("img", D);

		}

		/// <summary>
		/// Render a rectangle in 3d space
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
		public static string RenderRectangle(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float sy, float r, float g, float b)
		{

			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());

			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

			D.Add("size.x", sx.ToString());
			D.Add("size.y", sy.ToString());
			D.Add("size.z", "0.01");

			D.Add("color.r", r.ToString());
			D.Add("color.g", g.ToString());
			D.Add("color.b", b.ToString());
			D.Add("color.a", "1");

			D.Add("id", id);

			return Send("box", D);

		}

	
		/// <summary>
		/// Render a Circule/Eliptical
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
		public static string RenderCircule(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float sy, float r, float g, float b)
		{

			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());

			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

			D.Add("size.x", sx.ToString());
			D.Add("size.y", sy.ToString());
			

			D.Add("color.r", r.ToString());
			D.Add("color.g", g.ToString());
			D.Add("color.b", b.ToString());

			D.Add("id", id);

			return Send("ball", D);

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
		public static string RenderLine(string id, float x, float y, float z, float rx, float ry, float rz, float sx, float r, float g, float b)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());

			D.Add("rot.x", rx.ToString());
			D.Add("rot.y", ry.ToString());
			D.Add("rot.z", rz.ToString());

			D.Add("size.x", sx.ToString());
			D.Add("size.y", "0.01");
			D.Add("size.z", "0.01");

			D.Add("color.r", r.ToString());
			D.Add("color.g", g.ToString());
			D.Add("color.b", b.ToString());
			D.Add("color.a", "1");

			D.Add("id", id);

			return Send("box", D);
		}
		 /// <summary>
		 /// Render a single point
		 /// </summary>
		 /// <param name="id"></param>
		 /// <param name="x"></param>
		 /// <param name="y"></param>
		 /// <param name="z"></param>
		 /// <param name="r"></param>
		 /// <param name="g"></param>
		 /// <param name="b"></param>
		public static string RenderPoint(string id, float x, float y, float z, float r, float g, float b)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("pos.x", x.ToString());
			D.Add("pos.y", y.ToString());
			D.Add("pos.z", z.ToString());

		

			D.Add("size.x", "0.01");
			D.Add("size.y", "0.01");
			D.Add("size.z", "0.01");

			D.Add("color.r", r.ToString());
			D.Add("color.g", g.ToString());
			D.Add("color.b", b.ToString());
			D.Add("color.a", "1");

			D.Add("id", id);

			return Send("ball", D);
		}
		
		/// <summary>
		/// Render a multiline , 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="points"></param>
		/// <param name="rx"></param>
		/// <param name="ry"></param>
		/// <param name="rz"></param>
		/// <param name="r"></param>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="fill">fil the are aunder the curve or not</param>
		public static string RenderArea(int id,List<Vector3> points, float rx, float ry, float rz, float r, float g, float b,bool fill)
		{
			return "";
		}

		

		#endregion
		#region Controle Commands

		/// <summary>
		/// Send clear all signal
		/// </summary>
		public static string SendClearAll()
		{
			var x = new Dictionary<string, string>();
			x.Add("nop", "1");
			return Send("clearall", x);
		}

		// Set the Camera to a new location
		public static string SetOrigin(float x,float y,float z)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("org.x", x.ToString());
			D.Add("org.y", y.ToString());
			D.Add("org.z", z.ToString());
			return Send("setorigen", D);
		}
		/// <summary>
		/// Remove n Item with Id
		/// </summary>
		/// <param name="id"></param>
		public static string Remove(int id)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("id", id.ToString());
			return Send("remove", D);
		}
		/// <summary>
		/// Douplicate 
		/// </summary>
		/// <param name="id"></param>
		public static string Douplicate(string orgid,string cloneid)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("id", orgid.ToString());
			D.Add("cid", cloneid.ToString());
			return Send("douplicate", D);
		}


		#endregion
		#region Motion Commands

		/// <summary>
		/// Move the object with a given Id 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public static string Move(string id, float x, float y, float z)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("id", id.ToString());
			D.Add("trans.x", id.ToString());
			D.Add("trans.y", id.ToString());
			D.Add("trans.z", id.ToString());
			return Send("move", D);
		}

		/// <summary>
		/// Rotate arroudn its access
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public static string Rotate(string id, float x, float y, float z)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("id", id.ToString());
			D.Add("rot.x", id.ToString());
			D.Add("rot.y", id.ToString());
			D.Add("rot.z", id.ToString());
			return Send("move", D);
		}

		/// <summary>
		/// Scale
		/// </summary>
		/// <param name="id"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public static string Scale(string id, float x, float y, float z)
		{
			Dictionary<string, string> D = new Dictionary<string, string>();
			D.Add("id", id.ToString());
			D.Add("scl.x", id.ToString());
			D.Add("scl.y", id.ToString());
			D.Add("scl.z", id.ToString());
			return Send("move", D);
		}

		#endregion		
		#region Mis Commands
		/// <summary>
		/// Send a NOP Signal ,NOP: No Process is just domy signal
		/// </summary>
		public static string NOP()
		{
			return Send("nop", new Dictionary<string, string>());
		}
		/// <summary>
		/// Shutdown the head set
		/// </summary>
		public static string Shutdown()
		{
			return Send("shutdown", new Dictionary<string, string>());
		}

		#endregion
	}
}
