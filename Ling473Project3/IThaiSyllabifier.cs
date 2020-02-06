using System;

namespace Ling473Project3
{
	public interface IThaiSyllabifier
	{
		void SyllabifyString(string input);
		string GetOutputString();
	}

	// I made a sub-interface- because the GetOutputString()
	// already works for the case logic by returning a string.
	// Do I need this? 
	// Currently not used!!
	public interface ILambdaSupport : IThaiSyllabifier
	{
		StateReturnData SyllabifyStringLambda(string input);
	}
}

