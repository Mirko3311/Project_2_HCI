using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Media;
using System.Numerics;



namespace DrugiProjektniZadatakHCI
{
    public partial class MainWindow : Window
    {
        
        private TimeSpan pausedTime = TimeSpan.Zero;
        private bool isTimerRunning = false;
        private MediaPlayer mediaPlayer;



        private int gridSize = 4;
        private int pairsFound = 0;
        private int attempts = 0;
        private DispatcherTimer timer;
        private DateTime startTime;
        private List<Button> selectedCards = new List<Button>();
        private List<GameResult> gameResults = new List<GameResult>();

        private List<string> imagePaths = new List<string>
        {
            "Images/1.png",
            "Images/2.png",
            "Images/3.png",
            "Images/4.png",
            "Images/5.png",
            "Images/6.png",
            "Images/7.png",
            "Images/8.png",
             "Images/9.png",
            "Images/10.png",
            "Images/11.png",
            "Images/12.png",
            "Images/13.png",
            "Images/14.png",
            "Images/15.png",
            "Images/16.png",
            "Images/17.png",
            "Images/18.png",

        };
        private void CategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedCategory = selectedItem.Content.ToString();

                if (selectedCategory == "Voće")
                {
                    imagePaths = new List<string>
            {
              "Images/fruit1.png",
            "Images/fruit2.png",
            "Images/fruit3.png",
            "Images/fruit4.png",
            "Images/fruit5.png",
            "Images/fruit6.png",
            "Images/fruit7.png",
            "Images/fruit8.png",
             "Images/fruit9.png",
            "Images/fruit10.png",
            "Images/fruit11.png",
            "Images/fruit12.png",
            "Images/fruit13.png",
            "Images/fruit14.png",
            "Images/fruit15.png",
            "Images/fruit16.png",
            "Images/fruit17.png",
            "Images/fruit18.png"
            };
                }
                else if (selectedCategory == "Životinje")
                {
                    imagePaths = new List<string>
            { "Images/1.png",
            "Images/2.png",
            "Images/3.png",
            "Images/4.png",
            "Images/5.png",
            "Images/6.png",
            "Images/7.png",
            "Images/8.png",
             "Images/9.png",
            "Images/10.png",
            "Images/11.png",
            "Images/12.png",
            "Images/13.png",
            "Images/14.png",
            "Images/15.png",
            "Images/16.png",
            "Images/17.png",
            "Images/18.png"
            };
                }

                StartNewGame(); // Restart igre sa novim slikama
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            StartNewGame();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"E:\PrviProjektniZadatakHCI\DrugiProjektniZadatakHCI\Sounds\victory.wav"));
         

        }



        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

      /*  private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            TimeText.Text = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
        }*/
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                TimeText.Text = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
            }
        }


        private void StartNewGame()
        {
            pairsFound = 0;
            attempts = 0;
            AttemptsText.Text = "0";
            startTime = DateTime.Now;
            TimeText.Text = "00:00";

            // Pokreni tajmer
            timer.Start();

            GenerateCards(GameBoard, gridSize);
        }

        private void GenerateCards(Grid gameGrid, int gridSize)
        {
            int numberOfPairs = (gridSize * gridSize) / 2;
            var selectedImages = imagePaths.Take(numberOfPairs).ToList();
            selectedImages.AddRange(selectedImages);

            // Mešanje slika
            Random rng = new Random();
            selectedImages = selectedImages.OrderBy(x => rng.Next()).ToList();

            // Čišćenje grida i postavljanje novih kolona i redova
            gameGrid.Children.Clear();
            gameGrid.RowDefinitions.Clear();
            gameGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < gridSize; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int imageIndex = 0;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button cardButton = new Button
                    {
                        Background = Brushes.YellowGreen,
                        Margin = new Thickness(5),
                        Tag = selectedImages[imageIndex] // Spremanje putanje do slike
                    };

                    cardButton.Click += CardButton_Click;

                    Grid.SetRow(cardButton, i);
                    Grid.SetColumn(cardButton, j);
                    gameGrid.Children.Add(cardButton);

                    imageIndex++;
                }
            }
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCards.Count == 2) return;

            Button clickedCard = sender as Button;

            if (clickedCard.Content != null) return; // Ako je kartica već otvorena, ništa ne radimo

            string imagePath = clickedCard.Tag as string;

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                    Image imageControl = new Image
                    {
                        Source = bitmapImage,
                        Stretch = Stretch.Uniform
                    };

                    clickedCard.Content = imageControl;
                    selectedCards.Add(clickedCard);

                    if (selectedCards.Count == 2)
                    {
                        attempts++;
                        AttemptsText.Text = attempts.ToString();

                        if (IsMatch(selectedCards[0], selectedCards[1]))
                        {
                            selectedCards[0].IsEnabled = false;
                            selectedCards[1].IsEnabled = false;
                            pairsFound++;

                          
                                if (pairsFound == (gridSize * gridSize) / 2)
                                {
                                    timer.Stop();
                                    WCustomWindow inputDialog = new WCustomWindow();
                                    bool? result = inputDialog.ShowDialog();
                                    mediaPlayer.Position = TimeSpan.Zero;
                                    mediaPlayer.Play();
                                if (result == true)
                                    {
                                        string userInput = inputDialog.UserInput;

                                        // Dodajte rezultat u listu
                                        gameResults.Add(new GameResult
                                        {
                                            PlayerName = userInput,
                                            Attempts = attempts,
                                            TimeElapsed = TimeText.Text
                                        });

                                     
                                    }
                                    else
                                    {
                                        MessageBox.Show("Niste uneli ime! Igra neće početi bez unosa.", "Greška");
                                    }

                                    MessageBox.Show($"Čestitamo! Završili ste igru za {TimeText.Text} sa {attempts} pokušaja.");
                                }


                      



                            selectedCards.Clear();
                        }
                        else
                        {
                            // Okreni kartice nazad nakon 1 sekunde
                            DispatcherTimer flipBackTimer = new DispatcherTimer
                            {
                                Interval = TimeSpan.FromSeconds(1)
                            };

                            flipBackTimer.Tick += (s, args) =>
                            {
                                foreach (Button card in selectedCards)
                                {
                                    card.Content = null;
                                    card.Background = Brushes.YellowGreen;
                                  
                                }
                                selectedCards.Clear();
                                flipBackTimer.Stop();
                            };

                            flipBackTimer.Start();
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show($"Greška pri učitavanju slike: {ex.Message}", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                
                MessageBox.Show("Greška pri učitavanju slike.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    
        private bool IsMatch(Button card1, Button card2)
        {
            string path1 = card1.Tag as string;
            string path2 = card2.Tag as string;
            return path1 == path2;
        }

        private void ResetGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetEasy_Click(object sender, RoutedEventArgs e)
        {
            gridSize = 2;
            StartNewGame();
        }

        private void SetMedium_Click(object sender, RoutedEventArgs e)
        {
            gridSize = 4;
            StartNewGame();
        }

        private void SetHard_Click(object sender, RoutedEventArgs e)
        {
            gridSize = 6;
            StartNewGame();
        }
        private void Start_Timer(object sender, RoutedEventArgs e)
        {
            if (!isTimerRunning)
            {
               
                startTime = DateTime.Now - pausedTime; 
                timer.Start();
                isTimerRunning = true;
            }
        }


        private void Pause_Timer(object sender, RoutedEventArgs e)
        {
            if (isTimerRunning)
            {
                
                pausedTime = DateTime.Now - startTime;
                timer.Stop();
                isTimerRunning = false;
            }
        }   private void ShowResults_Click(object sender, RoutedEventArgs e)
        {
            if (gameResults.Count == 0)
            {
                MessageBox.Show("Još uvek nema rezultata.", "Rezultati");
                return;
            }

            string resultText = "Rezultati:\n";
            foreach (var result in gameResults)
            {
                resultText += $"Ime: {result.PlayerName}, Pokušaji: {result.Attempts}, Vrijeme:  {result.TimeElapsed}\n";
            }

            MessageBox.Show(resultText, "Rezultati");
        }

    }
}
