
using System.Collections.Generic;

using ChessMaster.PgnParsing;

namespace ChessMaster.Services
{
    public static class GameService
    {
        public static List<PgnGame> Games { get; set; } = new List<PgnGame>();
    }
}
