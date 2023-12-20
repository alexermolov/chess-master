using System.Text;

using ChessMaster.PgnParsing;

namespace ChessMaster.Helpers
{
    public static class GameHelpers
    {
        public static string GameToText(this PgnGame game)
        {
            var result = new StringBuilder(1024);

            foreach (var attr in game.Attrs)
            {
                result.Append($"[{attr.Key} \"{attr.Value}\"]");
                result.AppendLine();
            }

            var index = 1;
            var cnt = 0;
            foreach (var move in game.SanMoves)
            {
                if (cnt % 2 == 0)
                {
                    result.Append(index++);
                    result.Append(". ");
                }

                result.Append(move);
                result.Append(" ");

                cnt++;
            }

            var str = result.ToString();

            return str;
        }
    }
}
