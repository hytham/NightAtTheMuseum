using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using VirtualDesktop.Draw;

namespace VirtualDesktop
{
	public class GraphicDsiplayBuilder
	{
		/// <summary>
		/// Execute a Single line drawing
		/// </summary>
		/// <param name="Message"></param>
		public static void Execute(string Message)
		{
			var p = GetParameters(Message);
			string cmd = p["name"];
			switch (cmd)
			{
				case ("box"): // Draw a 3d cube
						  // Cube
					break;
				case ("ball"): // Draw a 3d cube
						  // Sphear
					break;
				case ("text"): // Draw a 3d cube
						 // Text
					break;

				case ("point"):
					// A single point
					break;
				case ("line"):
					// line
					break;
				case ("triangle"):
					// Triangle
					break;
				case ("rectangle"): // Draw a 3d cube
						 // rectangle
					break;
				case ("circule"): // Draw a 3d cube
						// Circule
					break;
				case ("ftriangle"):
					break;
				case ("frectangle"): // Draw a 3d cube
						// Filled rectangle
					break;
				case ("fcircule"): // Draw a 3d cube
						// filled circule
					break;
				case ("image"): // Draw a 3d cube
						// Image
					break;
				case ("bimage"): // Draw a 3d cube
						// Binary Image
					break;

				case ("remove"):
					// remove an elemnt
					break;

				case ("clear"):
					// Clean all the scene
					break;

				case ("switchscene"):
					// change the scene
					break;
			}
		}

		/// <summary>
		/// Execute a multiline drawing
		/// </summary>
		/// <param name="Message"></param>
		public static void Execute(List<string> Message)
		{
			   for(int i = 0; i < Message.Count; i++)
			{
				Execute(Message[i]);
			}
		}

		/// <summary>
		/// Parse the command line message and retuen a string of its parameters
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private  static Dictionary<string,string> GetParameters(string line)
		{
			Dictionary<string, string> s = new Dictionary<string, string>();
			String[] parts = line.Split('&');
			for(int i = 0; i < parts.Length; i++)
			{
				String[] sparts = parts[i].Split('=');
				s.Add(sparts[0], sparts[1]);
			} 
			return s;
		}
		/// <summary>
		/// Return Vector3 Object by parsinga coma seperated string
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private static Vector3 GetVector3(string line)
		{
			String[] x = line.Split(',');
			return new Vector3(
				(float)Convert.ToDouble(x[0]),
				(float)Convert.ToDouble(x[1]),
				(float)Convert.ToDouble(x[2])
				);
		}
		/// <summary>
		/// Return a vector2 from parsing aline
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		private static Vector2 GetVector2(string line)
		{
			String[] x = line.Split(',');
			return new Vector2(
				(float)Convert.ToDouble(x[0]),
				(float)Convert.ToDouble(x[1])
				);
		}

	}
}
