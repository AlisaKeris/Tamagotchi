using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Tamagotchi
{
    public partial class MainPage : ContentPage
    {
        Stopwatch sWatch;
        ProgressBar progressBartervis, progressBarroom, progressBarkullastus;
        Timer timer1;
        Button button1, button2, button3, button5;


        int eatCount = 0;
        int healCount = 0;
        int playCount = 0;

        Loom Pet;

        private void button5_Clicked(object sender, EventArgs e)
        {
            try
            {
                eatCount = 0;
                healCount = 0;
                playCount = 0;
                label1.Text = "Котик воскрешен";
                Pet.Voskresit();//воскрешаем

                sWatch.Start();//время жизни котика

            }
            catch (Exception) { }
        }


        private void button3_Clicked_1(object sender, EventArgs e)
        {
            label1.Text = "Котик вылечен";
            healCount++;
            if (Pet.Ztervis() < 90)
            {
                Pet.Vulechit();
                progressBartervis.Progress = Pet.Ztervis();
            }
            
        }

        private void button2_Clicked_1(object sender, EventArgs e)
        {
            label1.Text = "Котик рад";
            playCount++;
            if (Pet.Zroom() < 90)
            {
                Pet.Poigrat();
                progressBarroom.Progress = Pet.Zroom();
            }
            
        }
        
        public MainPage()
        {
            InitializeComponent();
            
            sWatch = new Stopwatch();
            sWatch.Start();
            
            Pet = new Loom();
            
          
            List<String> lifeTimeOfEachKitty = new List<string>();
            
            label1.Text = Pet.Checkstate();
            progressBartervis.Progress = Pet.Ztervis();
            progressBarroom.Progress = Pet.Zroom();
            progressBarkullastus.Progress = Pet.Zkullastus();
            if (label1.Text == "Здоров")
            {
                img1.ImageSource = "r.png";
                return;
            }
            if (label1.Text != "Мертв" && label1.Text != "Здоров")
            {
                img1.ImageSource = "h.jpg";
                return;
            }
            if (label1.Text == "Мертв")
            {
                
                img1.ImageSource = "s.jpg";
                sWatch.Stop();

                #region add to list
                lifeTimeOfEachKitty.Add(
                    "Общее время жизни питомца " + sWatch.Elapsed.ToString() + " " +
                    "Количество игр с любимчиком " + playCount.ToString() + " " +
                    "Количество лечений любимчика от болезни " + healCount.ToString() + " " +
                    "Количество кормежек любимчика " + eatCount.ToString() + " ");
                #endregion
                return;

            }
            /*StackLayout stack = new StackLayout();
            stack.Children.Add(label1);
            stack.Children.Add(img1);
            stack.Children.Add(button1);
            stack.Children.Add(progressBarkullastus);
            stack.Children.Add(button2);
            stack.Children.Add(progressBarroom);
            stack.Children.Add(button3);
            stack.Children.Add(progressBartervis);
            stack.Children.Add(button5);
            Content = stack;*/

        }

        private void button1_Clicked_1(object sender, EventArgs e)
        {
            label1.Text = "Котик сыт";
            eatCount++;
            if (Pet.Zkullastus() < 90)
            {
                Pet.Nakormit();
                progressBarkullastus.Progress = Pet.Zkullastus();
            }
            
        }

      

 

        
    }
}
