using System;
using System.Diagnostics;

namespace Tetris
{ 
    class Tetris
    {      

        private static void Main()
        {
            Game game = new Game();
            UI ui = new UI(game);
            Statistic statistic = new Statistic();

            game.Initialize(statistic);

            Sound.PlaySound("ChePiK01.wav");

            ui.DrawGlass();
            ui.OnStart("Press any key");

            Sound.PlaySound("LoungeGame2.wav");


            #region Timer Settings 
            game.TimerSettings();
            #endregion

            game.NextFigure = new Figure(game, ui);
            game.Figure = game.NextFigure;
            game.Figure.Spawn();
            game.NextFigure = new Figure(game, ui);

            ui.Resume(); //show game result at the current time

            game.Update(game, ui);// update 

            if (ui.IsReplay(statistic))
            {
                Sound.PlaySound("GameOver.mp3");
                Main();
            };
        }
      
    }
}
