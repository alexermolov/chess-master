namespace GenericSearchEngine {

    /// <summary>
    /// Return result from the MinMax routine
    /// </summary>
    internal class MinMaxResult<TMove>
#if MOVEISCLASS
                where TMove : class {
#else
                where TMove : struct {
#endif
        /// <summary>Best move</summary>
#if MOVEISCLASS
        public TMove? BestMove { get; set; }
#else
        public TMove BestMove { get; set; }
#endif
        /// <summary>true if a best move has been found</summary>
        public bool BestMoveFound { get; set; } = false;
        /// <summary>Point given for this move</summary>
        public int Pts { get; set; }
        /// <summary>Number of permutations evaluated</summary>
        public int PermCount { get; set; } = 0;
        /// <summary>Maximum search depth</summary>
        public int MaxDepth { get; set; } = -1;
    }
}
