namespace ChessMaster.PgnParsing
{
    internal class ParseResult
    {
        public PgnGame? PgnGame { get; set; }
        public bool IsBadMoveFound { get; set; }
    }
}
