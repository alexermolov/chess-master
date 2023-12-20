
ChessMaster:
    Core:                               Contains the Chess board engine
        BoardEvaluationBasic.cs         Basic board evaluation
                                        Used for all level above very easy
        BoardEvaluationTest.cs          Board evaluation used for testing.
        BoardEvaluationUtil.cs          Used to select a board evaluation.
        BoardEvaluationWeak.cs          Weak board evaluation
                                        Used if difficulty level is set to very easy
        Book.cs:                        Hold a start game book
                                        Two start game books are included as resources:
                                            BookUnrated.bin and Book2500.bin (ELO above 2500)
        ChessBoard.cs                   Implementation of the chess board without UI
        ChessGameBoardAdaptor.cs        Adaptor used by the generic search engine to get information
                                        about the chess game
        ChessSearchSetting.cs           Inherit from the generic search engine setting to add setting
                                        specific to the chess game
        GameTimer.cs                    Handle the game time used by each player
        IBoardEvaluation.cs             Board evaluation contract
        Move.cs                         Defines a player. Used by the search engine
        MoveExt.cs                      Extension to the move adding game information which are not
                                        needed for the search engine
        MoveHistory.cs                  Move history to keep track of the fifty-move rule and the
                                        threeefold repetition rule
        MovePosStack.cs                 Maintains the list of ply which has been played
        ZobristKey.cs                   Zobrist key Implementation
    FicsInterface:                      Interface to the Free Internet Chess Server
        FicsConnection.cs               Handle the connection with the FicsConnection
        FicsConnectionSetting.cs        Connection string
        FicsGame.cs                     Handle a FICS games
        FicsTester.cs                   Use to test FICS. Not used
        FrmConnectToFics.xaml           XAML interface to connect FICS
        FrmConnectToFics.xaml.cs        Code for the interface to connect FICS
        FrmFindBlitzGame.xaml           Interface to find a blitz
        FrmFindBlitzGame.xaml.cs        Code for the interface to find blitz
        SearchCriteria.cs               Game search SearchCriteria
        Style12MoveLine.cs              Represent a parsed line of observed game move in style 12 (raw for interface)
        TelnetConnection.cs             Telnet handler
    GenericSearchEngine:                Implementation of generic MinMax and Alpha Beta search engine
        AttackPosInfo.cs                Position information
        IGameBoard.cs                   Adaptor contract for the search engine
        ISearchTrace.cs                 Contract to define a trace for the search engine
        MinMaxInfo.cs                   Information used by the MinMax and AlphaBeta engine
        MinMaxResult.cs                 Result returned by the MinMax and AlphaBeta engine
        RandomMode.cs                   Random mode enum
        SearchEngine.cs                 Base class for SearchEngineAlphaBeta and SearchEngineMinMax classes
        SearchEngineAlphaBeta.cs        Alpha Beta search engine implementation
        SearchEngineMinMax.cs           MinMax search engine implementation
        SearchEngineSetting.cs          Search engine setting use by MinMax and AlphaBeta
        SearchOption.cs                 Enum defining the search mode
        ThreadingMode.cs                Enum for threading mode
        TransEntry.cs                   Translation table entry
        TransTable.cs                   Translation table implementation
    PgnParsing:                         Parser of PGN files
        PgnGame.cs                      PGN raw game representation
        PgnLexical.cs                   Parser lexical analyser
        PgnParser.cs                    PGN Parser
    PieceSets:                          Pieces set definition in XAML

    Root:
        app.config                      Definition of the game setting
        app.xaml                        WPF application
        Book2500.bin                    Opening book of OLE ratings with 2500 or more
        BookUnrated.bin                 Unrated opening book
        ChessBoardControl.xaml          Chess board ChessBoardControl
        ChessToolBar.xaml               Chess tool board
        CircularProgressBar.xaml        Circular progress bar implementation
        CustomColorPicker.xaml          Custom color picker implementation
        CustomColorSelector.xaml        Custom color selector implementation
        FicsGameIntf.cs                 Interface to FICS
        FrmAbout.xaml                   About box
        FrmBoardSetting.xaml            Permit to change the piece set and the colors of the board
        FrmCreateBookFromPgn.xaml       Process a file with a list of PGN games to create a starting book
        FrmCreatePgnGame.xaml           Create a game by pasting a PGN text
        FrmGameParameter.xaml           Defines the game's main parameters
        FrmLoadPgnGames.xaml            Splash screen while processing PGN games
        FrmLoadPuzzle.xaml              Selection of games puzzle (mate in x moves)
        FrmPgnFilter.xaml               Defines filters when creating a starting book
        FrmPgnGamePicker.xaml           Let the user select a PGN game when there is more than one
        FrmQueryPawnPromotionType.xaml  Let the user select the pawn FrmQueryPawnPromotionType
        FrmSearchMode.xaml              Let the user change the manual mode setting
        FrmTestBoardEval.xaml           Start a comparaison of board evaluation
        LocalChessBoardControl.cs       Inherit from ChessBoardControl to add information while saving a board
        LostPiecesControl.xaml          Show the lost pieces for a player
        MainWindow.xaml                 Main game window
        MoveViewer.xaml                 Show the list of moves which has been played
        PgnUtil.cs                      Help filtering PGN files or creating one from an existing board
        PieceSet.cs                     Base class to Define a piece set
        PieceSetStandard.cs             Piece set included in the assembly. Inherit from PieceSet class
        SettingAdaptor.cs               Interface between the program setting and the chess game
        Settings.cs                     Handling specific setting sink. Not used.
