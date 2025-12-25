using MathGame.MAUI.Models;

namespace MathGame.MAUI;

public partial class GamePage : ContentPage
{        public string GameType { get; set; }
        int firstNumber = 0;
        int secondNumber = 0;
        int score = 0;
        const int totalQuestions = 2;
    int gamesLeft = totalQuestions;
    public GamePage(string gameType)
    {
        InitializeComponent();
        GameType = gameType;
        BindingContext  = this;

        CreateNewQuestion();
    }

    private void CreateNewQuestion()
    {
        

        var random = new Random();
        
        firstNumber = GameType != "÷" ? random.Next(1, 9) : random.Next(1, 99);
        secondNumber = GameType != "÷" ? random.Next(1, 9) : random.Next(1, 99);

        if(GameType == "÷")
        {
            while (firstNumber <= secondNumber || firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }
        }

        QuestionLabel.Text = $"{firstNumber} {GameType} {secondNumber}";
    }

    private void OnAnswerSubmitted(object sender, EventArgs e)
    {
        var answer = Int32.Parse(Answer.Text);
        var isCorrect = false;

        switch (GameType)
        {
            case "+":
                isCorrect = answer == firstNumber + secondNumber;
                break;
            case "-":
                isCorrect = answer == firstNumber - secondNumber;
                break;
            case "x":
                isCorrect = answer == firstNumber * secondNumber;
                break;
            case "÷":
                isCorrect = answer == firstNumber / secondNumber;
                break;

                
        }
        ProcessAnswer(isCorrect);
        gamesLeft--;
        Answer.Text = "";

        if (gamesLeft > 0)
        {
            CreateNewQuestion();
        }
        else
        {
            GameOver();
        }
    }

    private void ProcessAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            score += 1;
        }
        AnswerLabel.Text = isCorrect ? "Correct!" : "Incorrect";
    }
    private void GameOver()
    {
        GameOperation gameOperation = GameType switch
        {
            "+" => GameOperation.Addition,
            "-" => GameOperation.Subtraction,
            "x" => GameOperation.Multiplication,
            "÷" => GameOperation.Division
        };


        QuestionArea.IsVisible = false;
        BackToMenuBtn.IsVisible = true;
        GameOverLabel.Text = $"Game over! You got  {score} out of {totalQuestions} right";

        App.GameRepository.Add(new Game
        {
            DatePlayed = DateTime.Now,
            Type = gameOperation,
            Score = score
        });
    }
    private void OnBackToMenu(object sender, EventArgs e)
    {
        score = 0;
        gamesLeft = totalQuestions;
        Navigation.PushAsync(new MainPage());
    }
}