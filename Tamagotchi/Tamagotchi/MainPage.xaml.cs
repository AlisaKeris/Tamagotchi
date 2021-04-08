using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using Xamarin.Forms;
using Microsoft.VisualBasic;


namespace Tamagotchi
{
    public partial class MainPage : ContentPage
    {
        Stopwatch sWatch;
        ProgressBar progressBartervis, progressBarroom, progressBarkullastus;
        Label lbl1;
        Button button1, button2, button3, button5;
        Random rnd = new Random();

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
                progressBartervis.Progress = Pet.Ztervis();
                progressBarroom.Progress = Pet.Zroom();
                progressBarkullastus.Progress = Pet.Zkullastus();
                sWatch.Start();//время жизни котика
                button1.IsVisible = true;
                button2.IsVisible = true;
                button3.IsVisible = true;
                button5.IsVisible = false;
                progressBartervis.IsVisible = true;
                progressBarroom.IsVisible = true;
                progressBarkullastus.IsVisible = true;
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
                progressBartervis.Progress = Convert.ToDouble("0." + Pet.Ztervis().ToString());
                
            }
            if (progressBarkullastus.Progress != 0)
            {
                if (rnd.Next(0, 1) == 0)
                {
                    progressBarkullastus.Progress -= 0.2;
                }
                else if (rnd.Next(0, 1) == 1)
                {
                    progressBarkullastus.Progress -= 0.4;
                }
            }




            label1.Text = Pet.Checkstate();
            pilt();
            progressBartervis.Progress = Pet.Ztervis();
        }

        private void button2_Clicked_1(object sender, EventArgs e)
        {
            label1.Text = "Котик рад";
            playCount++;
            if (Pet.Zroom() < 90)
            {
                Pet.Poigrat();
                progressBarroom.Progress = Convert.ToDouble("0." + Pet.Zroom().ToString());
            }

            if (progressBartervis.Progress != 0)
            {
                if (rnd.Next(0, 1) == 0)
                {
                    progressBartervis.Progress -= 0.2;
                } else if (rnd.Next(0, 1) == 1)
                {
                    progressBartervis.Progress -= 0.4;
                }
                    
            }




            label1.Text = Pet.Checkstate();
            pilt();
            progressBarroom.Progress = Pet.Zroom();
        }
        public void pilt()
        {
            
            if (label1.Text == "Здоров")
            {
                button5.IsVisible = false;
                img1.ImageSource = "r.png";
                return;
            }
            if (label1.Text != "Мертв" && label1.Text != "Здоров")
            {
                button5.IsVisible = false;
                img1.ImageSource = "hal.jpg";
                return;
            }
            if (label1.Text == "Мертв")
            {
                button1.IsVisible = false;
                button2.IsVisible = false;
                button3.IsVisible = false;
                button5.IsVisible = true;
                progressBartervis.IsVisible = false;
                progressBarroom.IsVisible = false;
                progressBarkullastus.IsVisible = false;
                img1.ImageSource = "s.jpg";
                sWatch.Stop();
                lbl1.Text = "Общее время жизни питомца " + sWatch.Elapsed.ToString() + " " + " " +
                    "Количество игр с любимчиком " + playCount.ToString() + " " +" "+
                    "Количество лечений любимчика от болезни " + healCount.ToString() + " " + " " +
                    "Количество кормежек любимчика " + eatCount.ToString() + " ";



                return;

            }
        }
        
        public MainPage()
        {
            InitializeComponent();
            
            sWatch = new Stopwatch();
            sWatch.Start();
            
            Pet = new Loom();
            
          
            
            
           
            progressBartervis.Progress = Pet.Ztervis();
            progressBarroom.Progress = Pet.Zroom();
            progressBarkullastus.Progress = Pet.Zkullastus();
            pilt();
            
        }
        
        private void button1_Clicked_1(object sender, EventArgs e)
        {
            
            label1.Text = "Котик сыт";
            eatCount++;
            if (Pet.Zkullastus() < 90)
            {
                Pet.Nakormit();
                progressBarkullastus.Progress = Convert.ToDouble("0." + Pet.Zkullastus().ToString());
            }
            
                if (progressBarroom.Progress != 0)
            {
                if (rnd.Next(0, 1) == 0)
                {
                    progressBarroom.Progress -= 0.2;
                }
                else if (rnd.Next(0, 1) == 1)
                {
                    progressBarroom.Progress -= 0.4;
                }
            }
            
                
            
            label1.Text = Pet.Checkstate();
            pilt();
            progressBarkullastus.Progress = Pet.Zkullastus();
        }

      

 

        
    }
}
