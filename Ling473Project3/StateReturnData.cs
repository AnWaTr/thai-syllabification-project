using System;
using System.Text;

namespace Ling473Project3
{
	/* First attempt...
	public class StateReturnData
	{
		// The lambda version of the machine requires multiple
		// return values- so using this class type. 
		public ThaiSyllabifierLambdaLogic.State newState;
		public StringBuilder outputString;

		public StateReturnData(ThaiSyllabifierLambdaLogic.State newState, StringBuilder outputString) 
		{ 
			this.newState = newState;
			this.outputString = outputString;
		}
	}
	*/

	public class StateReturnData
	{
		// The lambda version of the machine requires multiple
		// return values- so using this class type. 
		public ThaiSyllabifierLambdaLogic.State newState;
		public StringBuilder outputString = new StringBuilder();

		public StateReturnData(ThaiSyllabifierLambdaLogic.State newState, string outputString) 
		{ 
			this.newState = newState;
			this.outputString.Append(outputString);
		}
	}
}

