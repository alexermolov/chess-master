using System;
using System.Runtime.Serialization;

namespace ChessMaster.PgnParsing
{
    /// <summary>
    /// Parser exception
    /// </summary>
    [Serializable]
    public class PgnParserException : Exception
    {
        /// <summary>Code which is in error</summary>
        public string? CodeInError { get; }
        /// <summary>Array of move position</summary>
        public short[]? MoveList { get; set; } = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errTxt">      Error Message</param>
        /// <param name="codeInError"> Code in error</param>
        /// <param name="ex">          Inner exception</param>
        public PgnParserException(string? errTxt, string? codeInError, Exception? ex) : base(errTxt, ex) { CodeInError = codeInError; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errTxt">       Error Message</param>
        /// <param name="codeInError">  Code in error</param>
        public PgnParserException(string? errTxt, string? codeInError) : this(errTxt, codeInError, ex: null) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errTxt">       Error Message</param>
        public PgnParserException(string? errTxt) : this(errTxt, codeInError: "", ex: null) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public PgnParserException() : this(errTxt: "", codeInError: "", ex: null) { }

        /// <summary>
        /// Unserialize additional data
        /// </summary>
        /// <param name="info">    Serialization Info</param>
        /// <param name="context"> Context Info</param>
        protected PgnParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            CodeInError = info.GetString("CodeInError");
            MoveList = info.GetValue("MoveList", typeof(short[])) as short[];
        }

        /// <summary>
        /// Serialize the additional data
        /// </summary>
        /// <param name="info">    Serialization Info</param>
        /// <param name="context"> Context Info</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("CodeInError", CodeInError);
            info.AddValue("MoveList", MoveList);
        }
    } // Class PgnParserException
} // Namespace
