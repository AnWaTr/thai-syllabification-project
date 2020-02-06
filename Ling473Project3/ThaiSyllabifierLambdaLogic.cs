using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ling473Project3
{
	public class ThaiSyllabifierLambdaLogic : IThaiSyllabifier
	{
		#region Vowels, consonants and tones! 
		// These HashSet objects contain the possible characters which can correspond to the
		// following input pattern:
		// [V1]C1[C2][V2][T][V3][C3]
		private static HashSet<char> vowelSet1 = new HashSet<char>("เแโใไ");
		private static HashSet<char> conSet1 = new HashSet<char>("กขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรฤลฦวศษสหฬอฮ"); 
		private static HashSet<char> conSet2 = new HashSet<char>("รลวนม");

		private static HashSet<char> vowleSet2 = new HashSet<char>("◌◌ิ ◌ี ◌ึ ◌ื ◌ุ ◌ู ◌ั ็");
		private static HashSet<char> toneSet = new HashSet<char> { '\u0E48', '\u0E49', '\u0E4A', '\u0E4B' };
		private static HashSet<char> vowelSet3 = new HashSet<char>("าอยว");
		private static HashSet<char> conSet3 = new HashSet<char>("งนมดบกยว");
		#endregion

		// This enum defines the various states the machine can be in. 
		public enum State {Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Error};

		private static StringBuilder outputString = new StringBuilder();

		#region Take One
		/* Take one...
		#region MASSIVE Dictionary of states and transitions! 
		// This dictionary holds a list of Func<> objects, which take the current character as input, and return the 
		// new state. 
		private Dictionary<State, Func<char, State>> stateMachine = new Dictionary<State, Func<char, State>>
		{
			{State.Zero, (ch) => {
										if (vowelSet1.Contains (outputString[ch]))
											return State.One;
										else if (conSet1.Contains (outputString[ch]))
											return State.Two; 
										else return State.Error; } },

			{State.One, (ch) => {
					if (conSet1.Contains (outputString[ch]))
						return State.Two; 
					else return State.Error; }},

			{State.Two, (ch) => {
					if (conSet2.Contains (outputString[ch]))
						return State.Three;
					else if (vowleSet2.Contains (outputString[ch]))
						return State.Four;
					else if (toneSet.Contains (outputString[ch]))
						return State.Five;
					else if (vowelSet3.Contains (outputString[ch]))
						return State.Six;
					else if (conSet3.Contains (outputString[ch]))
						return State.Nine;
					else if (vowelSet1.Contains (outputString[ch]))
						return State.Seven;
					else if (conSet1.Contains (outputString[ch]))
						return State.Eight; 
					else return State.Error; }},

			{State.Three, (ch) => {
					if (vowleSet2.Contains (outputString[ch]))
						return State.Four;
					else if (toneSet.Contains (outputString[ch]))
						return State.Five;
					else if (vowelSet3.Contains (outputString[ch]))
						return State.Six;
					else if (conSet3.Contains (outputString[ch]))
						return State.Nine; 
					else return State.Error; }},


			{State.Four, (ch) => {
					if (toneSet.Contains (outputString[ch]))
						return State.Five;
					else if (vowelSet3.Contains (outputString[ch]))
						return State.Six;
					else if (conSet3.Contains (outputString[ch]))
						return State.Nine;
					else if (vowelSet1.Contains (outputString[ch]))
						return State.Seven;
					else if (conSet1.Contains (outputString[ch]))
						return State.Eight;					
					else return State.Error; }},

			{State.Five, (ch) => {
					if (vowelSet3.Contains (outputString[ch]))
						return State.Six;
					else if (conSet3.Contains (outputString[ch]))
						return State.Nine;
					else if (vowelSet1.Contains (outputString[ch]))
						return State.Seven;
					else if (conSet1.Contains (outputString[ch]))
						return State.Eight;					
					else return State.Error; }},
		
			{State.Six, (ch) => {
					if (conSet3.Contains (outputString[ch]))
						return State.Nine;
					else if (vowelSet1.Contains (outputString[ch]))
						return State.Seven;
					else if (conSet1.Contains (outputString[ch]))
						return State.Eight;				
					else return State.Error; }},


			{State.Seven, (ch) => {
					outputString = outputString.Insert (ch - 1, " ");
					return State.One;}},

			{State.Eight, (ch) => {
					outputString = outputString.Insert (ch - 1, " ");
					return State.Two;}},

			{State.Nine, (ch) => {
					outputString = outputString.Insert (ch, " ");
					return State.Zero;}}
		};
		#endregion
		*/
		#endregion

		#region Take Two
		/* Take two....
		// This dictionary holds a list of Func<> objects, which take the current character as input, and return the 
		// new state. 
		private Dictionary<State, Func<char, StateReturnData>> stateMachine = new Dictionary<State, Func<char, StateReturnData>>
		{
			{State.Zero, (ch) => {
					if (vowelSet1.Contains (outputString[ch]))
						return new StateReturnData(State.One, outputString);
					else if (conSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Two, outputString); 
					else return new StateReturnData(State.Error, outputString); } },

			{State.One, (ch) => {
					if (conSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Two, outputString); 
					else return new StateReturnData(State.Error, outputString); }},

			{State.Two, (ch) => {
					if (conSet2.Contains (outputString[ch]))
						return new StateReturnData(State.Three, outputString);
					else if (vowleSet2.Contains (outputString[ch]))
						return new StateReturnData(State.Four, outputString);
					else if (toneSet.Contains (outputString[ch]))
						return new StateReturnData(State.Five, outputString);
					else if (vowelSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Six, outputString);
					else if (conSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Nine, outputString);
					else if (vowelSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Seven, outputString);
					else if (conSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Eight, outputString); 
					else return new StateReturnData(State.Error, outputString); }},

			{State.Three, (ch) => {
					if (vowleSet2.Contains (outputString[ch]))
						return new StateReturnData(State.Four, outputString);
					else if (toneSet.Contains (outputString[ch]))
						return new StateReturnData(State.Five, outputString);
					else if (vowelSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Six, outputString);
					else if (conSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Nine, outputString); 
					else return new StateReturnData(State.Error, outputString); }},


			{State.Four, (ch) => {
					if (toneSet.Contains (outputString[ch]))
						return new StateReturnData(State.Five, outputString);
					else if (vowelSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Six, outputString);
					else if (conSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Nine, outputString);
					else if (vowelSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Seven, outputString);
					else if (conSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Eight, outputString);					
					else return new StateReturnData(State.Error, outputString); }},

			{State.Five, (ch) => {
					if (vowelSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Six, outputString);
					else if (conSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Nine, outputString);
					else if (vowelSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Seven, outputString);
					else if (conSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Eight, outputString);					
					else return new StateReturnData(State.Error, outputString); }},

			{State.Six, (ch) => {
					if (conSet3.Contains (outputString[ch]))
						return new StateReturnData(State.Nine, outputString);
					else if (vowelSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Seven, outputString);
					else if (conSet1.Contains (outputString[ch]))
						return new StateReturnData(State.Eight, outputString);				
					else return new StateReturnData(State.Error, outputString); }},


			{State.Seven, (ch) => {
					outputString = outputString.Insert (ch - 1, " ");
					return new StateReturnData(State.One, outputString);}},

			{State.Eight, (ch) => {
					outputString = outputString.Insert (ch - 1, " ");
					return new StateReturnData(State.Two, outputString);}},

			{State.Nine, (ch) => {
					outputString = outputString.Insert (ch, " ");
					return new StateReturnData(State.Zero, outputString);}}
		};
		*/
		#endregion

		#region Take Three
		/*
		// This dictionary holds a list of Func<> objects, which take the current character as input, and return the 
		// new state. 
		private Dictionary<State, Func<char, StateReturnData>> stateMachine = new Dictionary<State, Func<char, StateReturnData>>
		{
			{State.Zero, (ch) => {
					if (vowelSet1.Contains (ch))
						return new StateReturnData(State.One, ch.ToString());
					else if (conSet1.Contains (ch))
						return new StateReturnData(State.Two, ch.ToString()); 
					else return new StateReturnData(State.Error, ch.ToString()); } },

			{State.One, (ch) => {
					if (conSet1.Contains (ch))
						return new StateReturnData(State.Two, ch.ToString()); 
					else return new StateReturnData(State.Error, ch.ToString()); }},

			{State.Two, (ch) => {
					if (conSet2.Contains (ch))
						return new StateReturnData(State.Three, ch.ToString());
					else if (vowleSet2.Contains (ch))
						return new StateReturnData(State.Four, ch.ToString());
					else if (toneSet.Contains (ch))
						return new StateReturnData(State.Five, ch.ToString());
					else if (vowelSet3.Contains (ch))
						return new StateReturnData(State.Six, ch.ToString());
					else if (conSet3.Contains (ch))
						return new StateReturnData(State.Nine, ch.ToString());
					else if (vowelSet1.Contains (ch))
						return new StateReturnData(State.Seven, ch.ToString());
					else if (conSet1.Contains (ch))
						return new StateReturnData(State.Eight, ch.ToString()); 
					else return new StateReturnData(State.Error, ch.ToString()); }},

			{State.Three, (ch) => {
					if (vowleSet2.Contains (ch))
						return new StateReturnData(State.Four, ch.ToString());
					else if (toneSet.Contains (ch))
						return new StateReturnData(State.Five, ch.ToString());
					else if (vowelSet3.Contains (ch))
						return new StateReturnData(State.Six, ch.ToString());
					else if (conSet3.Contains (ch))
						return new StateReturnData(State.Nine, ch.ToString()); 
					else return new StateReturnData(State.Error, ch.ToString()); }},


			{State.Four, (ch) => {
					if (toneSet.Contains (ch))
						return new StateReturnData(State.Five, ch.ToString());
					else if (vowelSet3.Contains (ch))
						return new StateReturnData(State.Six, ch.ToString());
					else if (conSet3.Contains (ch))
						return new StateReturnData(State.Nine, ch.ToString());
					else if (vowelSet1.Contains (ch))
						return new StateReturnData(State.Seven, ch.ToString());
					else if (conSet1.Contains (ch))
						return new StateReturnData(State.Eight, ch.ToString());					
					else return new StateReturnData(State.Error, ch.ToString()); }},

			{State.Five, (ch) => {
					if (vowelSet3.Contains (ch))
						return new StateReturnData(State.Six, ch.ToString());
					else if (conSet3.Contains (ch))
						return new StateReturnData(State.Nine, ch.ToString());
					else if (vowelSet1.Contains (ch))
						return new StateReturnData(State.Seven, ch.ToString());
					else if (conSet1.Contains (ch))
						return new StateReturnData(State.Eight, ch.ToString());					
					else return new StateReturnData(State.Error, ch.ToString()); }},

			{State.Six, (ch) => {
					if (conSet3.Contains (ch))
						return new StateReturnData(State.Nine, ch.ToString());
					else if (vowelSet1.Contains (ch))
						return new StateReturnData(State.Seven, ch.ToString());
					else if (conSet1.Contains (ch))
						return new StateReturnData(State.Eight, ch.ToString());		 	
					else return new StateReturnData(State.Error, ch.ToString()); }},


			{State.Seven, (ch) => {
					//outputString = outputString.AppendFormat (" {0}", ch.ToString());
					return new StateReturnData(State.One, string.Format(" {0}", ch.ToString())); }},

			{State.Eight, (ch) => {
					//outputString = outputString.AppendFormat (" {0}", ch.ToString());
					return new StateReturnData(State.Two, string.Format(" {0}", ch.ToString())); }},

			{State.Nine, (ch) => {
					//outputString = outputString.AppendFormat ("{0} ", ch.ToString());
					return new StateReturnData(State.Zero, string.Format("{0}", ch.ToString())); }},

			{State.Error, (ch) => { return new StateReturnData(State.Error, "Error!");}}
		};
		*/
		#endregion

		#region IThaiSyllabifier Implementation

		/*
		public void SyllabifyString (string input)
		{
			StateReturnData state = new StateReturnData(State.Zero, "");
			int currChar = 0;

			while (currChar < input.Length)
			{
				state = this.stateMachine [state.newState] (input [currChar++]);
				outputString.Append (state.outputString);
			}
		}
*/

		public void SyllabifyString (string input)
		{
			// Make this visible to the whole method. 
			int currCharPos = 0;

			#region MASSIVE Dictionary of states and transitions! 
			// This dictionary holds a list of Func<> objects, which take the current character as input, and return the 
			// new state. 
			Dictionary<State, Func<char, State>> stateMachine = new Dictionary<State, Func<char, State>>
			{
				{State.Zero, (ch) => {
						if (vowelSet1.Contains (ch))
							return State.One;
						else if (conSet1.Contains (ch))
							return State.Two; 
						else return State.Error; } },

				{State.One, (ch) => {
						if (conSet1.Contains (ch))
							return State.Two; 
						else return State.Error; }},

				{State.Two, (ch) => {
						if (conSet2.Contains (ch))
							return State.Three;
						else if (vowleSet2.Contains (ch))
							return State.Four;
						else if (toneSet.Contains (ch))
							return State.Five;
						else if (vowelSet3.Contains (ch))
							return State.Six;
						else if (conSet3.Contains (ch))
							return State.Nine;
						else if (vowelSet1.Contains (ch))
							return State.Seven;
						else if (conSet1.Contains (ch))
							return State.Eight; 
						else return State.Error; }},

				{State.Three, (ch) => {
						if (vowleSet2.Contains (ch))
							return State.Four;
						else if (toneSet.Contains (ch))
							return State.Five;
						else if (vowelSet3.Contains (ch))
							return State.Six;
						else if (conSet3.Contains (ch))
							return State.Nine; 
						else return State.Error; }},


				{State.Four, (ch) => {
						if (toneSet.Contains (ch))
							return State.Five;
						else if (vowelSet3.Contains (ch))
							return State.Six;
						else if (conSet3.Contains (ch))
							return State.Nine;
						else if (vowelSet1.Contains (ch))
							return State.Seven;
						else if (conSet1.Contains (ch))
							return State.Eight;					
						else return State.Error; }},

				{State.Five, (ch) => {
						if (vowelSet3.Contains (ch))
							return State.Six;
						else if (conSet3.Contains (ch))
							return State.Nine;
						else if (vowelSet1.Contains (ch))
							return State.Seven;
						else if (conSet1.Contains (ch))
							return State.Eight;					
						else return State.Error; }},

				{State.Six, (ch) => {
						if (conSet3.Contains (ch))
							return State.Nine;
						else if (vowelSet1.Contains (ch))
							return State.Seven;
						else if (conSet1.Contains (ch))
							return State.Eight;				
						else return State.Error; }},


				{State.Seven, (ch) => {
						outputString = outputString.Insert (currCharPos - 1, " ");
						return State.One;}},

				{State.Eight, (ch) => {
						outputString = outputString.Insert (currCharPos - 1, " ");
						return State.Two;}},

				{State.Nine, (ch) => {
						outputString = outputString.Insert (currCharPos, " ");
						return State.Zero;}}
			};
			#endregion

			// StateReturnData state = new StateReturnData(State.Zero, "");
			State state = State.Zero;

			outputString = new StringBuilder(input);

			// Loop over each character in the input. 
			for (currCharPos = 0; currCharPos < outputString.Length; currCharPos++)
			{
				state = stateMachine [state] (outputString[currCharPos]);
			}
		}

		public string GetOutputString()
		{
			return outputString.ToString();
		}
		#endregion
	}
}

