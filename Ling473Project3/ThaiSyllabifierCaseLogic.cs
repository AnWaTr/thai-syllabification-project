using System;

// Need this for HashSet<> object. 
using System.Collections.Generic;
using System.Text;

namespace Ling473Project3
{
	public class ThaiSyllabifierCaseLogic : IThaiSyllabifier
	{
		#region Vowels, consonants and tones! 
		// These HashSet objects contain the possible characters which can correspond to the
		// following input pattern:
		// [V1]C1[C2][V2][T][V3][C3]
		private HashSet<char> vowelSet1 = new HashSet<char>("เแโใไ");
		private HashSet<char> conSet1 = new HashSet<char>("กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรฤลฦวศษสหฬอฮ"); 
		private HashSet<char> conSet2 = new HashSet<char>("รลวนม");
		private HashSet<char> vowleSet2 = new HashSet<char>("◌◌ิ ◌ี ◌ึ ◌ื ◌ุ ◌ู ◌ั ็");
		private HashSet<char> toneSet = new HashSet<char> { '\u0E48', '\u0E49', '\u0E4A', '\u0E4B' };
		private HashSet<char> vowelSet3 = new HashSet<char>("าอยว");
		private HashSet<char> conSet3 = new HashSet<char>("งนมดบกยว");
		#endregion

		// This enum defines the various states the machine can be in. 
		public enum State {Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Error};

		private StringBuilder outputString = null;

		#region IThaiSyllabifier implementation
		public void SyllabifyString (string input)
		{
			State currentState = State.Zero; 

			outputString = new StringBuilder(input);

			// Loop over each character in the input. 
			for(int currCharPos = 0; currCharPos < outputString.Length; currCharPos++)
			{
				// Switch on the current state.
				// When in a state, we will check the current character's membership 
				// in a given HashSet<> and then transition to next state. 
				switch (currentState)
				{

				#region Starting State
				case State.Zero: // Start state can contain either V1 or C1. 
					if (vowelSet1.Contains (outputString[currCharPos]))
						currentState = State.One;
					else if (conSet1.Contains (outputString[currCharPos]))
						currentState = State.Two;
					break;
				#endregion

				#region Intermentent states
				case State.One:
					if (conSet1.Contains (outputString[currCharPos]))
						currentState = State.Two;
					break;

				case State.Two:

					if (conSet2.Contains (outputString[currCharPos]))
						currentState = State.Three;
					else if (vowleSet2.Contains (outputString[currCharPos]))
						currentState = State.Four;
					else if (toneSet.Contains (outputString[currCharPos]))
						currentState = State.Five;
					else if (vowelSet3.Contains (outputString[currCharPos]))
						currentState = State.Six;
					else if (conSet3.Contains (outputString[currCharPos]))
						currentState = State.Nine;
					else if (vowelSet1.Contains (outputString[currCharPos]))
						currentState = State.Seven;
					else if (conSet1.Contains (outputString[currCharPos]))
						currentState = State.Eight;
					break;

				case State.Three:
					if (vowleSet2.Contains (outputString[currCharPos]))
						currentState = State.Four;
					else if (toneSet.Contains (outputString[currCharPos]))
						currentState = State.Five;
					else if (vowelSet3.Contains (outputString[currCharPos]))
						currentState = State.Six;
					else if (conSet3.Contains (outputString[currCharPos]))
						currentState = State.Nine;
					break;

				case State.Four:
					if (toneSet.Contains (outputString[currCharPos]))
						currentState = State.Five;
					else if (vowelSet3.Contains (outputString[currCharPos]))
						currentState = State.Six;
					else if (conSet3.Contains (outputString[currCharPos]))
						currentState = State.Nine;
					else if (vowelSet1.Contains (outputString[currCharPos]))
						currentState = State.Seven;
					else if (conSet1.Contains (outputString[currCharPos]))
						currentState = State.Eight;
					break;

				case State.Five:
					if (vowelSet3.Contains (outputString[currCharPos]))
						currentState = State.Six;
					else if (conSet3.Contains (outputString[currCharPos]))
						currentState = State.Nine;
					else if (vowelSet1.Contains (outputString[currCharPos]))
						currentState = State.Seven;
					else if (conSet1.Contains (outputString[currCharPos]))
						currentState = State.Eight;
					break;

				case State.Six:
					if (conSet3.Contains (outputString[currCharPos]))
						currentState = State.Nine;
					else if (vowelSet1.Contains (outputString[currCharPos]))
						currentState = State.Seven;
					else if (conSet1.Contains (outputString[currCharPos]))
						currentState = State.Eight;
					break;
				#endregion

				#region Final / Accepting States
				case State.Seven: // Syllable break! 
					currentState = State.One;
					outputString = outputString.Insert (currCharPos - 1, " ");
					break;

				case State.Eight: // Syllable break! 
					currentState = State.Two;
					outputString = outputString.Insert (currCharPos - 1, " ");
					break;

				case State.Nine: // Syllable break! 
					currentState = State.Zero;
					outputString = outputString.Insert (currCharPos, " ");
					break;
				#endregion

				}
			}
		}

		public string GetOutputString()
		{
			return outputString.ToString();
		}
		#endregion
	}
}

