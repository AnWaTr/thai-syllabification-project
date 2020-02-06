using System;
using System.IO;
using System.Text;
using System.Linq; // For contains extension method. 

namespace Ling473Project3
{
	class MainClass
	{
		// This one is for PATAS
		// static string inputFileLocation = "/opt/dropbox/15-16/473/project3/fsm-input.utf8.txt";

		// This one for local (in bin/debug).
		static string inputFileLocation = "fsm-input.utf8.txt";

		static bool usingLambda = false;

		public static void Main (string[] args)
		{
			IThaiSyllabifier breaker = null;
			breaker = BreakerFactoryMethod (args);

			// This will hold the output HTML text. 
			StringBuilder htmlOutput = new StringBuilder ();

			// Say hello. 
			EmitHelloMessage(htmlOutput);

			// Emit the opening <html>, <meta/> and opening <body> tags. 
			htmlOutput.Append("<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><body>");

			// Now loop over each line in the input file and write it out. 
			foreach (var currLine in File.ReadAllLines(inputFileLocation))
			{
				breaker.SyllabifyString (currLine);
				htmlOutput.Append(breaker.GetOutputString());
				htmlOutput.Append("<br/>");
			}

			// Emit the closing message / tags. 
			EmitClosingMessage(htmlOutput);
			htmlOutput.Append("</body></html>");

			// Dump to file. 
			File.WriteAllText ("myOutput.html", htmlOutput.ToString ());
			Console.WriteLine ("Please load myOutput.html into a web browser to see program results.");
		}

		#region Open / Close Message
		static void EmitHelloMessage(StringBuilder sb)
		{
			sb.Append ("<font color = \"blue\">");
			sb.Append ("*************************************<br/>");
			sb.Append ("LING 473 - Thai Syllable Breaker<br/>");
			sb.Append ("Summer 2015<br/>");
			sb.Append ("Andrew Troelsen - CLMS Student<br/>");
			sb.Append ("*************************************<br/>");
			sb.Append ("</font>");

			sb.Append ("<font color = \"red\">");
			if (!usingLambda)
				sb.Append ("Using case logic implementation<br/><br/>");
			else
				sb.Append ("Using lambda logic implementation<br/><br/>");

			sb.Append ("</font>");
		}

		static void EmitClosingMessage(StringBuilder sb)
		{
			sb.Append ("<font color = \"blue\">");
			sb.Append ("<br/>*************************************<br/>");
			sb.Append ("All Done!  Thanks for playing.<br/>");
			sb.Append ("*************************************<br/>");
			sb.Append ("</font>");
		}
		#endregion

		#region Simple factory
		static IThaiSyllabifier BreakerFactoryMethod(string[] args)
		{
			// See if user wants to use lambda version.
			if (args.Contains ("-lambda"))
				usingLambda = true;

			// Create the buster.
			IThaiSyllabifier breaker = null;
			if (!usingLambda)
				breaker = new ThaiSyllabifierCaseLogic ();   
			else
				breaker = new ThaiSyllabifierLambdaLogic ();

			return breaker;
		}
		#endregion
	}
}
